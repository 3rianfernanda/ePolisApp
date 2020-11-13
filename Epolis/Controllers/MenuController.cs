using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Epolis.Models;
using Epolis.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Epolis.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class MenuController : Controller
    {
        // GET: HomeController1
        private readonly EpolisContext _context;

        public MenuController(EpolisContext context)
        {
            _context = context;
        }

        // GET: Broker
        
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            return View(await _context.Mmenu.ToListAsync());

        }

        //public IActionResult Index(LoadVM model)
        //{
        //    {
        //        var data = new DataTableViewModel();

        //        try
        //        {
        //            model.Column = "*";
        //            model.Filter = "0=0";
        //            model.Orderby = "ID";
        //            model.Firstrow = 0;
        //            model.Secondrow = 10;

        //            var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mmenu:get"];
        //            (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, null);
        //            if (resultApi && !string.IsNullOrEmpty(result))
        //                data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
        //            List<Mmenu> listMmenu;
        //            using (var textReader = new StringReader(data.data.data.ToString()))
        //            {
        //                using (var reader = new JsonTextReader(textReader))
        //                {
        //                    listMmenu = new JsonSerializer().Deserialize(reader, typeof(List<Mmenu>)) as List<Mmenu>;
        //                }
        //            }
        //            ViewData["listMmenu"] = listMmenu;
        //            return View(listMmenu);

        //        }
        //        catch (Exception ex)
        //        {
        //            return View(ex.Message);
        //        }
        //    }
        //}
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mmenu:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mmenu>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: HomeController1/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public IActionResult Create(Mmenu model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mmenu:create"];
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

        // GET: HomeController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mmenu:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mmenu>>(result);

                return View("Edit", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: HomeController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mmenu model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.Status == 1) model.IsActive = true;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mmenu:edit"];
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

        // GET: HomeController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mmenu:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mmenu>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
