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
    public class LookupController : Controller
    {
        private readonly EpolisContext _context;

        public LookupController(EpolisContext context)
        {
            _context = context;
        }
        //public ActionResult Index()
        //{
        //    var lookup = from t in _context.Mlookup
        //                 where t.ISDELETED != true
        //                 select t;

        //    return View(lookup);
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
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mlookup:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                        data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<Mlookup> listMlookup;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMlookup = new JsonSerializer().Deserialize(reader, typeof(List<Mlookup>)) as List<Mlookup>;
                        }
                    }
                    ViewData["listMlookup"] = listMlookup;
                    return View(listMlookup);

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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mlookup:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mlookup>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: Lookup/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            return View();
        }

        // POST: Lookup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mlookup model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mlookup:create"];
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

        //public async Task<IActionResult> Create([Bind("ID,TYPE,NAME,VALUE,ORDERBY,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVE")] Mlookup mlookup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(mlookup);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(mlookup);
        //}

        // GET: Lookup/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var mlookup = await _context.Mlookup.FindAsync(id);
        //    if (mlookup == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(mlookup);
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mlookup:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mlookup>>(result);

                return View("Edit", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: Lookup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mlookup model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.ISACTIVE == true) ;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mlookup:edit"];
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
        //public async Task<IActionResult> Edit(int id, [Bind("ID,TYPE,NAME,VALUE,ORDERBY,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVE")] Mlookup mlookup)
        //{
        //    if (id != mlookup.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(mlookup);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MlookupExists(mlookup.ID))
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
        //    return View(mlookup);
        //}

        // GET: Lookup/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var mlookup = await _context.Mlookup
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (mlookup == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(mlookup);
        //}

        // POST: Lookup/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var mlookup = await _context.Mlookup.FindAsync(id);
        //    _context.Mlookup.Remove(mlookup);
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mlookup:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<Mlookup>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private bool MlookupExists(int id)
        {
            return _context.Mlookup.Any(e => e.ID == id);
        }
    }
}
