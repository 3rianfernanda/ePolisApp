using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epolis.Models;
using Epolis.ViewModels;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Epolis.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PertanggunganController : Controller
    {
        private readonly EpolisContext _context;

        public PertanggunganController(EpolisContext context)
        {
            _context = context;
        }

        //public ActionResult Index()
        //{

        //    List<Mpertanggungan> pertanggungan = _context.Mpertanggungan.ToList();
        //    List<Mokupasi> okupasi = _context.Mokupasi.ToList();
        //    //List<Msysparam> msysparams = _context.Msysparam.ToList();

        //    var result = from p in pertanggungan
        //                 join o in okupasi on p.MOKUPASIID equals o.ID
        //                 //join r in msysparams on p.RESIKO equals r.PARAMCODE
        //                 select new ViewModel
        //                 {
        //                     pertanggungan = p,
        //                     okupasi = o,
        //                     //sysparam = r

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
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mpertanggungan:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                        data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<Mpertanggungan> listMpertanggungan;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMpertanggungan = new JsonSerializer().Deserialize(reader, typeof(List<Mpertanggungan>)) as List<Mpertanggungan>;
                        }
                    }
                    ViewData["listMpertanggungan"] = listMpertanggungan;
                    return View(listMpertanggungan);

                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
        }
        // GET: Pertanggungan/Details/5
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mpertanggungan:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mpertanggungan>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Pertanggungan/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
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

        // POST: Pertanggungan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mpertanggungan model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mpertanggungan:create"];
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

        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mpertanggungan:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mbroker>>(result);
                var okupasi = _context.Mokupasi
                 .Select(s => new
                 {
                 Text = s.KODEOKUPASI + "-" + s.NAMAOKUPASI,
                    Value = s.ID
                 })
                .ToList();
                ViewBag.DDLOkupasi = new SelectList(okupasi, "Value", "Text");
                return View("Edit", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Pertanggungan/Edit/5

        // POST: Pertanggungan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mpertanggungan model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.Status == 1) model.IsActive = true;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mpertanggungan:edit"];
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
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mpertanggungan:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mpertanggungan>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var mpertanggungan = await _context.Mpertanggungan.FindAsync(id);
        //    _context.Mpertanggungan.Remove(mpertanggungan);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool MpertanggunganExists(int id)
        {
            return _context.Mpertanggungan.Any(e => e.ID == id);
        }
    }
}
