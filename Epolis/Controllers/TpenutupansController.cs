using Epolis.Models;
using Epolis.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class TpenutupansController : Controller
    {
        private readonly EpolisContext _context;
        private Tpenutupandetil tpenutupandetil;

        public TpenutupansController(EpolisContext context)
        {
            _context = context;
        }

        
        public void AddPenutupanDetil(SPenutupan sPenutupan)
        {
            sPenutupan.tpenutupandetil = new Tpenutupandetil();
        }

        [HttpPost]
        public async Task<IActionResult> InsertPenutupanDetil(SPenutupan sPenutupan)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            sPenutupan.penutupandetil.Add(sPenutupan.tpenutupandetil);
            return View(sPenutupan);
        }

        // GET: Tpenutupans

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

        // GET: Tpenutupans/Details/5
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

            var tpenutupan = await _context.Tpenutupan
                .FirstOrDefaultAsync(m => m.ID == id);

            if (tpenutupan != null)
            {
                var listTpenutupandetil = await _context.Tpenutupandetil.Where(n => n.TPENUTUPANID == tpenutupan.ID).ToListAsync();
                ViewData["listTpenutupandetil"] = listTpenutupandetil;

                var listFiles = await _context.Tfile.Where(n => n.TPENUTUPANID == tpenutupan.ID).ToListAsync();
                ViewData["listFiles"] = listFiles;

                return View(tpenutupan);
            }
            return NotFound();
        }

        public async Task<IActionResult> DownloadFileFromDatabase(int id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            var file = await _context.Tfile.Where(x => x.ID == id).FirstOrDefaultAsync();
            if (file == null) return null;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }

        // GET: Tpenutupans/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            var nasabah = _context.Tnasabah
            .Select(x => new { Value = x.ID, Text = x.NAMA });

            ViewBag.DDLNasabah = new SelectList(nasabah, "Value", "Text");
            //
            var cabang = _context.Mcabang
            .Select(x => new { Value = x.ID, Text = x.NAMACABANG });

            ViewBag.DDLCabang = new SelectList(cabang, "Value", "Text");
            //
            var jenisasuransi = _context.Mjenisasuransi
            .Select(x => new { Value = x.ID, Text = x.JENISASURANSI });

            ViewBag.DDLJenisAsuransi = new SelectList(jenisasuransi, "Value", "Text");
            //
            var perusahaanasuransi = _context.Mperusahaanasuransi
            .Select(x => new { Value = x.ID, Text = x.NAMAPERUSAHAAN });

            ViewBag.DDLPerusahaanAsuransi = new SelectList(perusahaanasuransi, "Value", "Text");
            //
            var kontrakasuransi = _context.Tkontrakasuransi
            .Select(x => new { Value = x.ID, Text = x.MOKUPASIID });

            ViewBag.DDLKontrakAsuransi = new SelectList(kontrakasuransi, "Value", "Text");

            var okupasi = _context.Mokupasi
            .Select(x => new { Value = x.ID, Text = x.NAMAOKUPASI });

            ViewBag.DDLOkupasi = new SelectList(okupasi, "Value", "Text");

            //
            var SysParam = _context.Msysparam
            .Where(x => x.PARAMGROUP == "Pembayaran Angsuran")
            .OrderBy(x => x.PARAMCODE)
            .Select(x => new { Value = x.ID, Text = x.PARAMVALUE });

            ViewBag.DDLSysParam = new SelectList(SysParam, "Value", "Text");

            return View();
        }

        // POST: Tpenutupans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> files, SPenutupan sPenutupan)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            //if (ModelState.IsValid)
            //{
            sPenutupan.penutupan.TGLINPUT = new System.DateTime();
            sPenutupan.penutupan.STATUS = 17;
            _context.Tpenutupan.Add(sPenutupan.penutupan);
            await _context.SaveChangesAsync();

            sPenutupan.tpenutupandetil.TPENUTUPANID = sPenutupan.penutupan.ID;
            sPenutupan.tpenutupandetil.TKONTRAKASURANSIID = 2;
             var objTpenutupandetil = sPenutupan.tpenutupandetil;
            _context.Tpenutupandetil.Add(objTpenutupandetil);
            await _context.SaveChangesAsync();
                
            sPenutupan.tpertanggungan.tpenutupandetilID = sPenutupan.tpenutupandetil.ID;

            var objTpertanggungan = sPenutupan.tpertanggungan;
            _context.Tpertanggungan.Add(objTpertanggungan);
            await _context.SaveChangesAsync();

            sPenutupan.tperluasan.TPENUTUPANDETILID = sPenutupan.tpenutupandetil.ID;

            var objTperluasan = sPenutupan.tperluasan;
            _context.Tperluasan.Add(objTperluasan);
            await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));
            //}
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileModel = new Tfile
                {
                    CreatedOn = DateTime.UtcNow,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    Description = sPenutupan.tfile.Description,
                    TPENUTUPANID = sPenutupan.penutupan.ID
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.Data = dataStream.ToArray();
                }
                _context.Tfile.Add(fileModel);
                _context.SaveChanges();
            }

            //UploadToDatabase(files, sPenutupan);

            return RedirectToAction("Index");
        }

        // GET: Tpenutupans/Edit/5
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

            var tpenutupan = await _context.Tpenutupan.FindAsync(id);
            if (tpenutupan == null)
            {
                return NotFound();
            }
            return View(tpenutupan);
        }

        // POST: Tpenutupans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,tnasabahID,JENISPENUTUPAN,NOREGPENUTUPAN,ORDERDARIKOTA,TGLINPUT,TGLOTORISASI,STATUS,NOSKK,TGLSKK,NOPK,CIF,ISBROKER,ISUPDATEPENUTUPANRENEWAL,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID")] Tpenutupan tpenutupan)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            if (id != tpenutupan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tpenutupan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TpenutupanExists(tpenutupan.ID))
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
            return View(tpenutupan);
        }

        // GET: Tpenutupans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
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

        // POST: Tpenutupans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            var tpenutupan = await _context.Tpenutupan.FindAsync(id);
            _context.Tpenutupan.Remove(tpenutupan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult CreateDetil()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            var nasabah = _context.Tnasabah
            .Select(x => new { Value = x.ID, Text = x.NAMA });

            ViewBag.DDLNasabah = new SelectList(nasabah, "Value", "Text");
            //
            var cabang = _context.Mcabang
            .Select(x => new { Value = x.ID, Text = x.NAMACABANG });

            ViewBag.DDLCabang = new SelectList(cabang, "Value", "Text");
            //
            var jenisasuransi = _context.Mjenisasuransi
            .Select(x => new { Value = x.ID, Text = x.JENISASURANSI });

            ViewBag.DDLJenisAsuransi = new SelectList(jenisasuransi, "Value", "Text");
            //
            var perusahaanasuransi = _context.Mperusahaanasuransi
            .Select(x => new { Value = x.ID, Text = x.NAMAPERUSAHAAN });

            ViewBag.DDLPerusahaanAsuransi = new SelectList(perusahaanasuransi, "Value", "Text");
            //
            var kontrakasuransi = _context.Tkontrakasuransi
            .Select(x => new { Value = x.ID, Text = x.MOKUPASIID });

            ViewBag.DDLKontrakAsuransi = new SelectList(kontrakasuransi, "Value", "Text");

            return View();
        }

        //[HttpPost]
        //public void Task<IActionResult> UploadToDatabase(List<IFormFile> files, SPenutupan sPenutupan)
        //{
        //    foreach (var file in files)
        //    {
        //        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
        //        var extension = Path.GetExtension(file.FileName);
        //        var fileModel = new Tfile
        //        {
        //            CreatedOn = DateTime.UtcNow,
        //            FileType = file.ContentType,
        //            Extension = extension,
        //            Name = fileName,
        //            Description = sPenutupan.tfile.Description,
        //            TPENUTUPANID = sPenutupan.penutupan.ID
        //        };
        //        using (var dataStream = new MemoryStream())
        //        {
        //            await file.CopyToAsync(dataStream);
        //            fileModel.Data = dataStream.ToArray();
        //        }
        //        _context.Tfile.Add(fileModel);
        //        _context.SaveChanges();
        //    }
        //    TempData["Message"] = "File successfully uploaded to Database";
        //    //return RedirectToAction("Index");
        //}

        private bool TpenutupanExists(int id)
        {
            return _context.Tpenutupan.Any(e => e.ID == id);
        }
    }
}
