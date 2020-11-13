using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epolis.Models;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Epolis.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Epolis.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class OkupasiController : Controller
    {
        private readonly EpolisContext _context;

        public OkupasiController(EpolisContext context)
        {
            _context = context;
        }
        // GET: Okupasi
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Mokupasi.ToListAsync());
        //}
        //public ActionResult Index()
        //{
        //    List<Mokupasi> okupasi = _context.Mokupasi.ToList();
        //    List<Mlookup> lookup = _context.Mlookup.ToList();

        //    var OkupasiRecord = from o in okupasi
        //                        join r in lookup on o.RESIKO equals r.ID into table1
        //                        from r in table1.ToList()
        //                        where o.ISDELETED != true
        //                        select new ViewModel
        //                        {
        //                            okupasi = o,
        //                            lookup = r
        //                        };
        //    return View(OkupasiRecord);
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
                    model.Orderby = "o.ID";
                    model.Firstrow = 0;
                    model.Secondrow = 20;
                    var token = HttpContext.Session.GetString("TOKEN");
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                    data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<Mokupasi> listMokupasi;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMokupasi = new JsonSerializer().Deserialize(reader, typeof(List<Mokupasi>)) as List<Mokupasi>;
                        }
                    }
                    ViewData["listMokupasi"] = listMokupasi;
                    return View(listMokupasi);

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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mokupasi>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult DDLRESIKO()
        {

            ViewBag.DDLResiko = new SelectList(GetLookupByType("RESIKO"), "id", "value");
            return View();
        }

        public List<RspDropdown> GetLookupByType(string type )
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

        //// GET: Okupasi/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            //var lookup = _context.Mlookup
            //.Where(x => x.TYPE == "RESIKO")
            //.OrderBy(x => x.ORDERBY)
            //.Select(x => new { Value = x.ID, Text = x.VALUE });

            //ViewBag.DDLResiko = new SelectList(lookup, "Value", "Text");
            DDLRESIKO();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mokupasi model)
        {
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:create"];
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
        // GET: Okupasi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mokupasi>>(result);

                return View("Edit", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Edit(Mokupasi model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.Status == 1) model.IsActive = true;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:edit"];
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mokupasi:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mokupasi>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool MokupasiExists(int id)
        {
            return _context.Mokupasi.Any(e => e.ID == id);
        }
    }
}
