using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiKuVer2.Frontend.Web.Controllers
{
    using MiKuVer2.Services;
    using MiKuVer2.Model;

    //[Authorize]
    public class GeschaeftspartnerController : Controller
    {
        //
        // GET: /Geschaeftspartner/
        private IGeschaeftspartnerService geschaeftspartnerService= new GeschaeftspartnerService();

        
        public ActionResult Index()
        {
            ViewBag.gp = this.geschaeftspartnerService.GetGeschaeftspartner(0);
            var gps = this.geschaeftspartnerService.GetDirekteGeschaeftspartner();
            return View(gps);
        }

        //
        // GET: /Geschaeftspartner/Details/5

        public ActionResult Details(int id)
        {
            var gp = this.geschaeftspartnerService.GetGeschaeftspartner(id);
            return View(gp);
        }

        //
        // GET: /Geschaeftspartner/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Geschaeftspartner/Create

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
                // TODO: Add insert logic here
                var neuerGps = new Geschaeftspartner();

                neuerGps.Eintrittsdatum = DateTime.Parse(formCollection["Eintrittsdatum"]);
                neuerGps.Vorname = formCollection["Nachname"];

                this.geschaeftspartnerService.GeschaeftspartnerSpeichern(neuerGps);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Geschaeftspartner/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Geschaeftspartner/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Geschaeftspartner/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Geschaeftspartner/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
