using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRMVC.Controllers
{
    public class MVCController : Controller
    {
        // GET: MVC
        public ActionResult Index()
        {
            return View();
        }
    }
}