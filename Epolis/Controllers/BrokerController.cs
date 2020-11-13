using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Epolis.Models;
using epolis.Helper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Epolis.ViewModels;
using System.Net.Http;
using Epolis.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO;

namespace Epolis.Controllers
{
    //[Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class BrokerController : Controller
    {
        private readonly EpolisContext _context;

        
        public BrokerController(EpolisContext context)
        {
            _context = context;
        }
        
        //public ActionResult Index()
        //{
        //    var broker = from t in _context.Mbroker
        //                 where t.ISDELETED != true
        //                 select t;
        //    return View(broker);
        //}
        //public JsonResult GetBroker()
        //{
        //    var broker = from t in _context.Mbroker
        //                 where t.ISDELETED != true
        //                 select t;
        //    return Json(broker);
        //}
        //public ActionResult Index()
        //{
        //    return View();
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
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mbroker:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                        data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<Mbroker> listMbroker;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMbroker = new JsonSerializer().Deserialize(reader, typeof(List<Mbroker>)) as List<Mbroker>;
                        }
                    }
                    ViewData["listMbroker"] = listMbroker;
                    return View(listMbroker);

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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mbroker:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mbroker>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Broker/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mbroker model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mbroker:create"];
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

        // GET: Broker/Edit/5
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mbroker:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mbroker>>(result);

                return View("Edit", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mbroker model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.Status == 1) model.IsActive = true;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mbroker:edit"];
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

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var mbroker = await _context.Mbroker.FindAsync(id);
        //    _context.Mbroker.Remove(mbroker);
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mbroker:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mbroker>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool MbrokerExists(int id)
        {
            return _context.Mbroker.Any(e => e.ID == id);
        }
    }
}
