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
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class KontrakAsuransiController : Controller
    {
        private readonly EpolisContext _context;

        public KontrakAsuransiController(EpolisContext context)
        {
            _context = context;
        }

        // GET: KontrakAsuransi

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            return View(await _context.Tkontrakasuransi.ToListAsync());
        }

        // GET: KontrakAsuransi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var tkontrakasuransi = await _context.Tkontrakasuransi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tkontrakasuransi == null)
            {
                return NotFound();
            }

            return View(tkontrakasuransi);
        }
        public ActionResult DDLOkupasi()
        {
            var okupasi = _context.Mokupasi
           .Select(s => new
           {
               Text = s.KODEOKUPASI + "-" + s.NAMAOKUPASI,
               Value = s.ID,
           })
           .ToList();
            ViewBag.DDLOkupasi = new SelectList(okupasi, "Value", "Text");
            return View();

        }
        //private List <Mokupasi> GetOkupasi()
        //{
        //    var listOkupasi = new List<Mokupasi>();
        //    var k1 = new Mokupasi();
        //    k1.KELAS1 = 2;
        //    var k2 = new Mokupasi();
        //    k2.KELAS2 = 2;
        //    var res = new Mokupasi();
        //    res.KELAS2 = 2;

        //    return listOkupasi;
        //}
        public ActionResult DDLResiko()
        {
            var sysparam = _context.Msysparam
           .Where(x => x.PARAMGROUP == "Resiko")
           .OrderBy(x => x.ORDERNO)
           .Select(x => new { Value = x.PARAMCODE, Text = x.PARAMVALUE });
            ViewBag.DDLResiko = new SelectList(sysparam, "Value", "Text");
            return View();

        }
        public ActionResult DDLJenisAsuransi()
        {
            var jenis = _context.Mjenisasuransi
          .Select(s => new
          {
              Text = s.KODEJENISASURANSI + "-" + s.JENISASURANSI,
              Value = s.ID
          })
          .ToList();
            ViewBag.DDLJenis = new SelectList(jenis, "Value", "Text");
            return View();
        }
        public ActionResult DDLPerusahaanAsuransi()
        {
            var perusahaan = _context.Mperusahaanasuransi
          .Select(s => new
          {
              Text = s.KODEPERUSAHAAN + "-" + s.NAMAPERUSAHAAN,
              Value = s.ID
          })
          .ToList();
            ViewBag.DDLPerusahaan = new SelectList(perusahaan, "Value", "Text");

            return View();
        }

        // GET: KontrakAsuransi/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            //Resiko
            DDLResiko();
            //ddjenis
            DDLJenisAsuransi();
            //ddlokupasi
            DDLOkupasi();
            //ddperusahaan
            DDLPerusahaanAsuransi();
            return View();
        }

        // POST: KontrakAsuransi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MPERUSAHAANASURANSIID,MJENISASURANSIID,MOKUPASIID,STDKELAS1,STDKELAS2,RESIKO,TANGGALMULAI,TANGGALSELESAI,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVED")] Tkontrakasuransi tkontrakasuransi)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            if (ModelState.IsValid)
            {
                _context.Add(tkontrakasuransi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tkontrakasuransi);
        }

        // GET: KontrakAsuransi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            if (id == null)
            {
                return NotFound();
            }

            var tkontrakasuransi = await _context.Tkontrakasuransi.FindAsync(id);
            if (tkontrakasuransi == null)
            {
                return NotFound();
            }
            //Resiko
            DDLResiko();
            //ddjenis
            DDLJenisAsuransi();
            //ddlokupasi
            DDLOkupasi();
            //ddperusahaan
            DDLPerusahaanAsuransi();
            return View(tkontrakasuransi);
        }

        // POST: KontrakAsuransi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MPERUSAHAANASURANSIID,MJENISASURANSIID,MOKUPASIID,STDKELAS1,STDKELAS2,RESIKO,TANGGALMULAI,TANGGALSELESAI,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVED")] Tkontrakasuransi tkontrakasuransi)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            if (id != tkontrakasuransi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tkontrakasuransi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TkontrakasuransiExists(tkontrakasuransi.ID))
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
            return View(tkontrakasuransi);
        }

        // GET: KontrakAsuransi/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tkontrakasuransi = await _context.Tkontrakasuransi
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (tkontrakasuransi == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tkontrakasuransi);
        //}

        // POST: KontrakAsuransi/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            var tkontrakasuransi = await _context.Tkontrakasuransi.FindAsync(id);
            _context.Tkontrakasuransi.Remove(tkontrakasuransi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TkontrakasuransiExists(int id)
        {
            return _context.Tkontrakasuransi.Any(e => e.ID == id);
        }

        public IActionResult GetOkupasi(int id)
        {
            var okupasi = _context.Mokupasi.FirstOrDefault(x => x.ID == id);
            return new JsonResult(okupasi.KELAS1);
        }
    }
}
