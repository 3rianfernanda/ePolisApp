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
    public class UserController : Controller
    {
        // GET: HomeController1
        private readonly EpolisContext _context;

        public UserController(EpolisContext context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Muser.ToListAsync());
        //}


        // GET: Broker

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
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Muser:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                        data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<Muser> listMuser;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMuser = new JsonSerializer().Deserialize(reader, typeof(List<Muser>)) as List<Muser>;
                        }
                    }
                    ViewData["listMuser"] = listMuser;
                    return View(listMuser);

                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
        }
        // GET: Broker/Details/5
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

            var muser = await _context.Muser
                .FirstOrDefaultAsync(m => m.ID == id);
            if (muser == null)
            {
                return NotFound();
            }

            return View(muser);
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
        public ActionResult Create(IFormCollection collection)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: HomeController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
