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
    public class userGroupController : Controller
    {
        private readonly EpolisContext _context;

        public userGroupController(EpolisContext context)
        {
            _context = context;
        }

        // GET: userGroup
       
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
                    var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Musergroup:get"];
                    (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model, token);
                    if (resultApi && !string.IsNullOrEmpty(result))
                        data = JsonConvert.DeserializeObject<DataTableViewModel>(result);
                    List<MuserGroup> listMuserGroup;
                    using (var textReader = new StringReader(data.data.data.ToString()))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            listMuserGroup = new JsonSerializer().Deserialize(reader, typeof(List<MuserGroup>)) as List<MuserGroup>;
                        }
                    }
                    ViewData["listMuserGroup"] = listMuserGroup;
                    return View(listMuserGroup);

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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Musergroup:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<MuserGroup>>(result);

                return View("Details", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: userGroup/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            return View();
        }

        // POST: userGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,USERGROUPCODE,USERGROUPNAME,USERGROUPDESC,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVE")] MuserGroup muserGroup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(muserGroup);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(muserGroup);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MuserGroup model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Musergroup:create"];
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

        // GET: userGroup/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var muserGroup = await _context.MuserGroup.FindAsync(id);
        //    if (muserGroup == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(muserGroup);
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Musergroup:getById"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<MuserGroup>>(result);

                return View("Edit", jsonResult.data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: userGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,USERGROUPCODE,USERGROUPNAME,USERGROUPDESC,UPDATEDBYID,UPDATEDTIME,ISDELETED,DELETEDBYID,DELETEDTIME,CREATEDTIME,CREATEDBYID,ISACTIVE")] MuserGroup muserGroup)
        //{
        //    if (id != muserGroup.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(muserGroup);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MuserGroupExists(muserGroup.ID))
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
        //    return View(muserGroup);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MuserGroup model)
        {
            if (HttpContext.Session.GetString("USERNAME") == null)
            {
                return RedirectToAction("LoginCheck", "Login");
            }
            try
            {
                var token = HttpContext.Session.GetString("TOKEN");
                //if (model.Status == 1) model.IsActive = true;
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Musergroup:edit"];
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


        // GET: userGroup/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var muserGroup = await _context.MuserGroup
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (muserGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(muserGroup);
        //}

        // POST: userGroup/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var muserGroup = await _context.MuserGroup.FindAsync(id);
        //    _context.MuserGroup.Remove(muserGroup);
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
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Musergroup:delete"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, new { id }, token);
                var jsonResult = JsonConvert.DeserializeObject<ResponseViewModel<MuserGroup>>(result);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool MuserGroupExists(int id)
        {
            return _context.MuserGroup.Any(e => e.ID == id);
        }
    }
}
