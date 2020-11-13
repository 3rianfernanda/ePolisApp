using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Epolis.Models;
using Epolis.Reports;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epolis.Controllers
{
    public class CetakPolisController : Controller
    {
        private readonly EpolisContext _context;
        private IWebHostEnvironment _oHostEnvironment;

        public CetakPolisController(EpolisContext context, IWebHostEnvironment oHostEnvironment)
        {
            _context = context;
            _oHostEnvironment = oHostEnvironment;
        }

        //GET: CetakPolis/Create
        public IActionResult CetakPolis()
        {
            return View();
        }

        // POST: CetakPolis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CetakPolisAsync(string searchnoreg)
        {
            
            if (String.IsNullOrEmpty(searchnoreg))
            {
                return View();
            }
            Tpenutupan searchResult = await _context.Tpenutupan.FirstOrDefaultAsync(m => m.NOREGPENUTUPAN == searchnoreg);

            if (searchResult == null)
            {
                ViewBag.Penutupan = "Data Tidak Ditemukan";
                return View();
            }
            return View("Details", searchResult);
        }

        public async Task<IActionResult> CetakSertifikatAsync(Tpenutupan searchResult)
        {

            if (searchResult == null)
            {
                return NotFound();
            }
            SertifikatReport rpt = new SertifikatReport(_context, _oHostEnvironment);
            return File(rpt.Report(searchResult), "application/pdf");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tpenutupan = await _context.Tpenutupan
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tpenutupan == null)
            {
                return NotFound();
            }

            return View(tpenutupan);
        }
    }
}
