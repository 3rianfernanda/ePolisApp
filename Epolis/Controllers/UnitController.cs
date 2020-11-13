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
    public class UnitController : Controller
    {
        private readonly EpolisContext _context;

        public UnitController(EpolisContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Munit.ToListAsync());
        //}

        // GET: Unit

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
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Munit:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                        data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<Munit> listMunit;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMunit = new JsonSerializer().Deserialize(reader, typeof(List<Munit>)) as List<Munit>;
                        }
                    }
                    ViewData["listMunit"] = listMunit;
                    return View(listMunit);

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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Munit:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Munit>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Unit/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Munit model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Munit:create"];
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Munit:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Munit>>(result);

                return View("Edit", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: Unit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Munit model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.Status == 1) model.IsActive = true;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Munit:edit"];
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Munit:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Munit>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool MunitExists(int id)
        {
            return _context.Munit.Any(e => e.ID == id);
        }
    }
}
