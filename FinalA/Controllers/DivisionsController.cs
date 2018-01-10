using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalA.Models;

namespace FinalA.Controllers
{
    public class DivisionsController : Controller
    {
       

        private HockeyModel db = new HockeyModel();

        [Authorize]
        // GET: Divisions
        public ActionResult Index() => View(db.Divisions.OrderBy(a => a.Name).ToList());

        // GET: Divisions/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
