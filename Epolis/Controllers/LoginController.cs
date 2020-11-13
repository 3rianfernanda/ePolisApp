using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using epolis.Helper;
using Epolis.Models;
using Epolis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Epolis.Controllers
{
    //[Authorize]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class LoginController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult LoginCheck(UserVM model)
        {
            try
            {
                var url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Muser:login"];
                (bool resultApi, string result) = RequestToAPI.PostRequestToWebApi(url, model,null);
                if (resultApi && !string.IsNullOrEmpty(result))
                {
                    var rsp = JsonConvert.DeserializeObject<JWTRespVM>(result);
                

                    if (rsp.code > 0)
                    {
                        HttpContext.Session.SetInt32("ID", rsp.data.ID);
                        HttpContext.Session.SetString("USERID", rsp.data.USERID);
                        HttpContext.Session.SetString("USERNAME", rsp.data.USERNAME);
                        HttpContext.Session.SetString("UNITCODE", rsp.data.UNITCODE);
                        HttpContext.Session.SetString("UNITNAME", rsp.data.UNITNAME);
                        HttpContext.Session.SetInt32("MUSERGROUPID", rsp.data.MUSERGROUPID);
                        HttpContext.Session.SetString("USERGROUPCODE", rsp.data.USERGROUPCODE);
                        HttpContext.Session.SetString("USERGROUPNAME", rsp.data.USERGROUPNAME);
                        HttpContext.Session.SetString("NAMACABANG", rsp.data.NAMACABANG);
                        HttpContext.Session.SetString("KOTACABANG", rsp.data.KOTACABANG);
                        HttpContext.Session.SetString("TOKEN", rsp.data.TOKEN);

                        //IdUserGroupVM _model = new IdUserGroupVM
                        //{
                        //    Id = rsp.data.MUSERGROUPID,
                        //    Orderby = "ID"
                        //};
                        //var token = HttpContext.Session.GetString("TOKEN");
                        //var _url = ConfigDataAccess.Configuration["baseAPI"] + ConfigDataAccess.Configuration["urlapi:Mmenu:get"];
                        //(bool _resultApi, string _result) = RequestToAPI.PostRequestToWebApi(_url, _model, token);
                        //if (_resultApi && !string.IsNullOrEmpty(_result))
                        //{
                        //    var _rsp = JsonConvert.DeserializeObject<RespMenuSingleVM<RespMenuDataTableVM<RespMmenuVM>>>(_result);
                            
                        //    var _ = new RespMmenuVM()
                        //        {
                                    
                                
                        //        };
                              
                            

                        //}
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = rsp.message;
                        
                    }

                }
                else
                {
                    ViewBag.ErrorMessage = "Error";
                }
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
            }
                ViewBag.EnableErrorSummary = true;

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginCheck", "Login");
        }

    }
}
