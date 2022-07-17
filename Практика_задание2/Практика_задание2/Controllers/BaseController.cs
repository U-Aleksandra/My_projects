using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Практика_задание2.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public string ErrorMessage
        {
            get { return TempData["ErrorMessage"] == null ? String.Empty : TempData["ErrorMessage"].ToString(); }
            set { TempData["ErrorMessage"] = value; }
        }

        
        public ActionResult Error()
        {
            ViewBag.Message = ErrorMessage;
            return View();
            
        }
    }
}