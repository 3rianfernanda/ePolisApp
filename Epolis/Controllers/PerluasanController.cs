using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epolis.Models;
using Newtonsoft.Json;
using Epolis.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Epolis.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PerluasanController : Controller
    {
        private readonly EpolisContext _context;

        public PerluasanController(EpolisContext context)
        {
            _context = context;
        }

        // GET: Perluasan
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Mperluasan.ToListAsync());
        //}
        //public ActionResult Index()
        //{

        //    List<Mperluasan> perluasan = _context.Mperluasan.ToList();
        //    List<Mokupasi> okupasi = _context.Mokupasi.ToList();
        //    List<Mlookup> lookup = _context.Mlookup.ToList();

        //    var result = from pr in perluasan
        //                 join o in okupasi on pr.MOKUPASIID equals o.ID
        //                 join r in lookup on pr.RESIKO equals r.ID
        //                 where pr.ISDELETED != true
        //                 select new ViewModel
        //                 {
        //                     perluasan = pr,
        //                     okupasi = o,
        //                     lookup = r

        //                 };
        //    return View(result);
        //}

        public IActionResult Index(LoadVM model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            {
                var data = new DataTableViewModel();

                try
                {
                    model.Column = "*";
                    model.Filter = "0=0";
                    model.Orderby = "ID";
                    model.Firstrow = 0;
                    model.Secondrow = 10;
                    var token = HttpContext.Session.GetString("TOKEN");
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mperluasan:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                        data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<Mperluasan> listMperluasan;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMperluasan = new JsonSerializer().Deserialize(reader, typeof(List<Mperluasan>)) as List<Mperluasan>;
                        }
                    }
                    ViewData["listMperluasan"] = listMperluasan;
                    return View(listMperluasan);

                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
        }
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mperluasan:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mperluasan>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: Perluasan/Create
        public ActionResult DDLRESIKO()
        {

            ViewBag.DDLResiko = new SelectList(GetLookupByType("RESIKO"), "id", "value");
            return View();
        }

        public List<RspDropdown> GetLookupByType(string type)
        {
            var list = new List<RspDropdown>();
            var model = new ReqDropdown();
            model.TYPE = type;

            var token = HttpContext.Session.GetString("TOKEN");
            var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Util:dropdown"];
            (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
            if (resultApi && !string.IsNullOrEmpty(result))
                list = JsonConvert.DeserializeObject<List<RspDropdown>>(result);
            return list;
        }
        public ActionResult DDLOkupasi()
        {

            ViewBag.DDLOkupasi = new SelectList(GetOkupasi(), "ID", "NAMAOKUPASI");
            return View();
        }

        public List<Mokupasi> GetOkupasi()
        {
            var list = new List<Mokupasi>();
            //var model = new ReqDropdown();
            //model.TYPE = type;

            var token = HttpContext.Session.GetString("TOKEN");
            var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:get"];
            (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, token);
            if (resultApi && !string.IsNullOrEmpty(result))
                list = JsonConvert.DeserializeObject<List<Mokupasi>>(result);
            return list;
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            //ddlresiko
            DDLRESIKO();
            //var lookup = _context.Mlookup
            //.Where(x => x.TYPE == "Resiko")
            //.OrderBy(x => x.ORDERBY)
            //.Select(x => new { Value = x.ID, Text = x.VALUE });

            //ViewBag.DDLResiko = new SelectList(lookup, "Value", "Text");

            //ddlokupasi
            //DDLOkupasi();
            var okupasi = _context.Mokupasi
           .Select(s => new
           {
               Text = s.KODEOKUPASI + "-" + s.NAMAOKUPASI,
               Value = s.ID
           })
           .ToList();
            ViewBag.DDLOkupasi = new SelectList(okupasi, "Value", "Text");

            return View();
        }

        // POST: Perluasan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,MOKUPASIID,KODEPERLUASAN,DESKRIPSI,RATEPERLUASAN,RESIKO,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID")] Mperluasan mperluasan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(mperluasan);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(mperluasan);
        //}
        public IActionResult Create(Mperluasan model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mperluasan:create"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                if (resultApi && !string.IsNullOrEmpty(result))
                    return RedirectToAction("Index");
                else
                    return Content("Failed Save");
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }
            ViewBag.EnableErrorSummary = true;
            return View();
        }
        // GET: Perluasan/Edit/5
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

            var mperluasan = await _context.Mperluasan.FindAsync(id);
            if (mperluasan == null)
            {
                return NotFound();
            }
            //ddlresiko
            //var lookup = _context.Mlookup
            //.Where(x => x.TYPE == "Resiko")
            //.OrderBy(x => x.ORDERBY)
            //.Select(x => new { Value = x.ID, Text = x.VALUE });

            //ViewBag.DDLResiko = new SelectList(lookup, "Value", "Text");
            DDLRESIKO();
            //ddlokupasi
            var okupasi = _context.Mokupasi
           .Select(s => new
           {
               Text = s.KODEOKUPASI + "-" + s.NAMAOKUPASI,
               Value = s.ID
           })
           .ToList();
            ViewBag.DDLOkupasi = new SelectList(okupasi, "Value", "Text");
            return View(mperluasan);
        }

        // POST: Perluasan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,MOKUPASIID,KODEPERLUASAN,DESKRIPSI,RATEPERLUASAN,RESIKO,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID")] Mperluasan mperluasan)
        //{
        //    if (id != mperluasan.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(mperluasan);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MperluasanExists(mperluasan.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(mperluasan);
        //}
        public IActionResult Edit(Mperluasan model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.Status == 1) model.IsActive = true;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mperluasan:edit"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                if (resultApi && !string.IsNullOrEmpty(result))
                    return RedirectToAction("Index");
                else
                    return Content("Failed Update");
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }
            ViewBag.EnableErrorSummary = true;
            return View("Index", model);
        }

        // GET: Perluasan/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var mperluasan = await _context.Mperluasan
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (mperluasan == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(mperluasan);
        //}

        // POST: Perluasan/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var mperluasan = await _context.Mperluasan.FindAsync(id);
        //    _context.Mperluasan.Remove(mperluasan);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mperluasan:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mperluasan>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private bool MperluasanExists(int id)
        {
            return _context.Mperluasan.Any(e => e.ID == id);
        }
    }
}
   