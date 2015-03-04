using MVCAngularJsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAngularJsWebApplication.Controllers
{
    public class PlacesController : Controller
    {
        List<LinkModel> links = new List<LinkModel>();

        // GET: Places
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("AllPlaces")]
        public JsonResult GetAllLinks()
        {
            using (millerwebEntities1 context = new millerwebEntities1())
            {
                links.AddRange(from l in context.Links
                               select new LinkModel
                               {
                                   Id = l.Id,
                                   Description = l.Description,
                                   DisplayName = l.DisplayName,
                                   Href = l.Href
                               });
            }
            return new JsonResult { Data = links.OrderBy(x => x.DisplayName), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        [Route("Places/:id")]
        public JsonResult GetLinks(int id)
        {
            var link = links.FirstOrDefault((p) => p.Id == id);
            return new JsonResult { Data = link, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}