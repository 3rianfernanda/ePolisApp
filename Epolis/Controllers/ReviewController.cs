using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epolis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epolis.Controllers
{
    public class ReviewController : Controller
    {
        private readonly EpolisContext _context;

        public ReviewController(EpolisContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }

            List<Tpenutupan> penutupan = _context.Tpenutupan.Where(m => m.STATUS == 18).ToList();
            List<Tpenutupandetil> penutupandetil = _context.Tpenutupandetil.ToList();
            List<Mlookup> mlookup = _context.Mlookup.ToList();
            List<Tnasabah> tnasabah = _context.Tnasabah.ToList();
            List<Tcatatan> tcatatan = _context.Tcatatan.ToList();
            List<Tfile> tfile = _context.Tfile.ToList();
            List<Toperator> toperator;
            var inid = HttpContext.Session.GetInt32("ID");
            if (inid != null)
                toperator = _context.Toperator.Where(x => x.REVIEWERID == inid).ToList();
            else
                toperator = _context.Toperator.ToList();

            var result = from a in penutupan
                         join b in penutupandetil on a.ID equals b.TPENUTUPANID
                         join c in mlookup on a.STATUS equals c.ID
                         join d in tnasabah on a.tnasabahID equals d.ID
                         join e in toperator on a.ID equals e.TPENUTUPANID
                         select new ViewModelPenutupan
                         {
                             Tpenutupan = a,
                             Tpenutupandetil = b,
                             Mlookup = c,
                             Tnasabah = d,
                             Toperator = e
                         };
            return View(result);
        }

        public async Task<IActionResult> Review(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var tpenutupan = await _context.Tpenutupan.FirstOrDefaultAsync(m => m.ID == id);
            var tcatatans = await _context.Tcatatan.Where(s => s.TPENUTUPANID == id).ToListAsync();

            var sreview = new ViewModelPenutupan();
            sreview.Tpenutupan = tpenutupan;
            sreview.Tcatatans = tcatatans;

            return View(sreview);
        }
        public async Task<IActionResult> Save(ViewModelPenutupan sreview)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }

            sreview.Tpenutupan.TGLINPUT = new DateTime();
            sreview.Tpenutupan.ISBROKER = false;

            var toperator = await _context.Toperator.FirstOrDefaultAsync(m => m.TPENUTUPANID == sreview.Tpenutupan.ID);
            if (toperator == null)
            {
                return NotFound();
            }
            toperator.REVIEWERSELESAI = new DateTime();
            _context.Update(toperator);

            _context.Update(sreview.Tpenutupan);
            if (sreview.Tcatatan != null || sreview.Tcatatan.CATATAN.Trim().Length > 0)
            {
                sreview.Tcatatan.TPENUTUPANID = sreview.Tpenutupan.ID;
                _context.Add(sreview.Tcatatan);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
