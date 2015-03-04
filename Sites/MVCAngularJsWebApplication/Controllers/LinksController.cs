using MVCAngularJsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace MVCAngularJsWebApplication.Controllers
{
    public class LinksController : Controller
    {
        List<Link> links = new List<Link>();
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Route("Links")]
        //public JsonResult GetAllLinks()
        //{
        //    return new JsonResult { Data = links, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //[HttpGet]
        //[Route("Link/:id")]
        //public JsonResult GetLinks(int id)
        //{
        //    var link = links.FirstOrDefault((p) => p.Id == id);
        //    return new JsonResult { Data = link, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
    }
}
