using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ontap_bai6.Models;

namespace Ontap_bai6.Controllers
{
    public class RegisController : Controller
    {
        // GET: Regis
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Regis(Person p)
        {
            return View(p);
        }
    }
}