using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epolis.Models;
using Microsoft.AspNetCore.Http;

namespace Epolis.Controllers
{
    public class TbrokerController : Controller
    {
        private readonly EpolisContext _context;

        public TbrokerController(EpolisContext context)
        {
            _context = context;
        }

        // GET: Tbroker
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            List<Tpenutupan> penutupan = _context.Tpenutupan.ToList();
            List<Tpenutupandetil> penutupandetil = _context.Tpenutupandetil.ToList();
            List<Mlookup> mlookup = _context.Mlookup.ToList();
            List<Tnasabah> tnasabah = _context.Tnasabah.ToList();

            var result = from a in penutupan
                         join b in penutupandetil on a.ID equals b.TPENUTUPANID
                         join c in mlookup on a.STATUS equals c.ID
                         join d in tnasabah on a.tnasabahID equals d.ID
                         select new ViewModelPenutupan
                         {
                             Tpenutupan = a,
                             Tpenutupandetil = b,
                             Mlookup = c,
                             Tnasabah = d
                         };
            return View(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }

            List<Tpenutupan> penutupan = _context.Tpenutupan.Where(x => x.ID == id).ToList();
            List<Tpenutupandetil> penutupandetil = _context.Tpenutupandetil.ToList();
            List<Tkontrakasuransi> kontrakasuransi = _context.Tkontrakasuransi.ToList();
            List<Mperusahaanasuransi> perusahaanasuransi = _context.Mperusahaanasuransi.ToList();
            List<Mjenisasuransi> jenisasuransi = _context.Mjenisasuransi.ToList();
            List<Tnasabah> nasabah = _context.Tnasabah.ToList();
            List<Tperluasan> perluasan = _context.Tperluasan.ToList();
            List<Tpertanggungan> pertanggungan = _context.Tpertanggungan.ToList();
            List<Mokupasi> okupasi = _context.Mokupasi.ToList();
            List<Mlookup> lookup = _context.Mlookup.ToList();
            List<Tcatatan> catatan = _context.Tcatatan.ToList();

            var result = from a in penutupan
                         join b in penutupandetil on a.ID equals b.TPENUTUPANID
                         join c in kontrakasuransi on b.TKONTRAKASURANSIID equals c.ID
                         join d in perusahaanasuransi on c.MPERUSAHAANASURANSIID equals d.ID
                         join e in jenisasuransi on c.MJENISASURANSIID equals e.ID
                         join f in perluasan on b.ID equals f.TPENUTUPANDETILID
                         join g in nasabah on a.tnasabahID equals g.ID
                         join h in pertanggungan on b.ID equals h.TPENUTUPANDETILID
                         join i in okupasi on c.MOKUPASIID equals i.ID
                         join j in lookup on c.RESIKO equals j.ID
                         join k in catatan on a.ID equals k.TPENUTUPANID

                         select new AllrelationVm
                         {
                             Tpenutupan = a,
                             Tpenutupandetil = b,
                             Tkontrakasuransi = c,
                             Mperusahaanasuransi = d,
                             Mjenisasuransi = e,
                             Tperluasan = f,
                             Tnasabah = g,
                             Tpertanggungan = h,
                             Mokupasi = i,
                             Mlookup = j,
                             Tcatatan = k

                         };

            var user = _context.Muser
            .Select(x => new { Value = x.ID, Text = x.USERNAME });

            ViewBag.DDLUser = new SelectList(user, "Value", "Text");

            var asuransijenis = _context.Mjenisasuransi
            .Select(x => new { Value = x.ID, Text = x.JENISASURANSI });

            ViewBag.DDLJenisAsuransi = new SelectList(asuransijenis, "Value", "Text");

            var asuransiperusahaan = _context.Mperusahaanasuransi
            .Select(x => new { Value = x.ID, Text = x.NAMAPERUSAHAAN });

            ViewBag.DDLPerusahaanASuransi = new SelectList(asuransiperusahaan, "Value", "Text");

            if (id == null)
            {
                return NotFound();
            }

            var tpenutupan = await _context.Tpenutupan
               .FirstOrDefaultAsync(m => m.ID == id);

            if (tpenutupan != null)
            {
                //var listTpenutupandetil = await _context.Tpenutupandetil.Where(n => n.TPENUTUPANID == tpenutupan.ID).ToListAsync();
                //ViewData["listTpenutupandetil"] = listTpenutupandetil;

                //var listFiles = await _context.Tfile.Where(n => n.TPENUTUPANID == tpenutupan.ID).ToListAsync();
                //ViewData["listFiles"] = listFiles;

                return View(result.First());
            }
            return NotFound();
        }



        // GET: Tbroker/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbroker = await _context.Tbroker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbroker == null)
            {
                return NotFound();
            }

            return View(tbroker);
        }

        // GET: Tbroker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbroker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MBROKERID,MPERUSAHAANASURANSIID,MJENISASURANSIID,MOKUPASIID,NAMABROKER,ALAMATBROKER,EMAILBROKER,TELEPONBROKER,NAMAASURADUR,ALAMATASURADUR,EMAILASURADUR,TELEPONASURADUR,CONTACTPERSONASURADUR,NOMINALCBC,RESIKO,TANGGALMULAI,TANGGALSELESAI,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVED")] Tbroker tbroker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbroker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbroker);
        }

        // GET: Tbroker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbroker = await _context.Tbroker.FindAsync(id);
            if (tbroker == null)
            {
                return NotFound();
            }
            return View(tbroker);
        }

        // POST: Tbroker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MBROKERID,MPERUSAHAANASURANSIID,MJENISASURANSIID,MOKUPASIID,NAMABROKER,ALAMATBROKER,EMAILBROKER,TELEPONBROKER,NAMAASURADUR,ALAMATASURADUR,EMAILASURADUR,TELEPONASURADUR,CONTACTPERSONASURADUR,NOMINALCBC,RESIKO,TANGGALMULAI,TANGGALSELESAI,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVED")] Tbroker tbroker)
        {
            if (id != tbroker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbroker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbrokerExists(tbroker.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbroker);
        }

        // GET: Tbroker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbroker = await _context.Tbroker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tbroker == null)
            {
                return NotFound();
            }

            return View(tbroker);
        }

        // POST: Tbroker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbroker = await _context.Tbroker.FindAsync(id);
            _context.Tbroker.Remove(tbroker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbrokerExists(int id)
        {
            return _context.Tbroker.Any(e => e.ID == id);
        }
    }
}
