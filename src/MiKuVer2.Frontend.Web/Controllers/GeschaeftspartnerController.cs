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

        private IGeschaeftspartnerService geschaeftspartnerService= new GeschaeftspartnerService();

        private IKundenService kundenService = new KundenService();

        //
        // GET: /Geschaeftspartner/
        //public ActionResult Index()
        //{
        //    ViewBag.gp = this.geschaeftspartnerService.GetGeschaeftspartner(1);
        //    var gps = this.geschaeftspartnerService.GetDirekteGeschaeftspartner(1);
        //    return View(gps);
        //}

        public ActionResult Index(string gp, string mode)
        {
            if (gp == null)
            {
                gp = "1";
            }

            int id = Convert.ToInt32(gp);

            List<Geschaeftspartner> gps = new List<Geschaeftspartner>();
            switch (mode)
            {
                case "agp":
                    gps = this.geschaeftspartnerService.GetAlleGeschaeftspartner(id);
                    break;
                case "dpg":
                    gps = this.geschaeftspartnerService.GetDirekteGeschaeftspartner(id);
                    break;
                default:
                    gps = this.geschaeftspartnerService.GetDirekteGeschaeftspartner(id);
                    break;
            }

            ViewBag.gp = this.geschaeftspartnerService.GetGeschaeftspartner(id);
            return View(gps);
        }

        //
        // GET: /Geschaeftspartner/Details/5

        public ActionResult Details(int id, string mode = "normal")
        {
            var kunden = new List<Kunde>();
            var gps = new List<Geschaeftspartner>();
            var gp = new Geschaeftspartner();

            switch (mode)
            {
                case "normal":
                    gp = this.geschaeftspartnerService.GetGeschaeftspartner(id);
                    break;
                case "Kunden":
                    kunden = this.kundenService.GetDirekteKundenVonGeschaeftspartner(id);
                    ViewBag.show = "_AlleKunden";
                    return View(kunden);
                case "gps":
                    gp = this.geschaeftspartnerService.GetGeschaeftspartner(id);
                    gp.Partner = this.geschaeftspartnerService.GetDirekteGeschaeftspartner(id);
                    gps = gp.Partner;
                    ViewBag.show = "_DirekteKunden";
                    return View(gps);
            }

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
        public ActionResult Create(Geschaeftspartner neuerGps)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.geschaeftspartnerService.GeschaeftspartnerSpeichern(neuerGps);
                    return RedirectToAction("Index");
                }

                return this.View(neuerGps);
            }
            catch
            {
                ViewBag.ErrorMessage = "Es ist ein Fehler aufgetretten";
                return View(neuerGps);
            }
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    try
        //    {
        //        var neuerGps = new Geschaeftspartner();

        //        neuerGps.Eintrittsdatum = DateTime.Parse(formCollection["Eintrittsdatum"]);
        //        neuerGps.Nachname = formCollection["Nachname"];
        //        neuerGps.Vorname = formCollection["Vorname"];
        //        neuerGps.Geburtstag = DateTime.Parse(formCollection["Geburtstag"]);
        //        neuerGps.Fax = formCollection["Fax"];
        //        neuerGps.Telefon = formCollection["Telefon"];
        //        neuerGps.Strasse = formCollection["Strasse"];
        //        neuerGps.Hausnummer = formCollection["Hausnummer"];
        //        neuerGps.PLZ = formCollection["PLZ"];
        //        neuerGps.Ort = formCollection["Ort"];
        //        neuerGps.EMail = formCollection["EMail"];

        //        this.geschaeftspartnerService.GeschaeftspartnerSpeichern(neuerGps);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        ViewBag.ErrorMessage = "Es ist ein Fehler aufgetretten";
        //        return View();
        //    }
        //}
        
        //
        // GET: /Geschaeftspartner/Edit/5
 
        public ActionResult Edit(int id)
        {
            var gpToEdit = this.geschaeftspartnerService.GetGeschaeftspartner(id);
            if (gpToEdit == null)
            {
                HttpNotFound();
            }
            return View(gpToEdit);
        }

        //
        // POST: /Geschaeftspartner/Edit/5

        [HttpPost]
        public ActionResult Edit(Geschaeftspartner geschaeftspartner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.geschaeftspartnerService.GeschaeftspartnerAktualisieren(geschaeftspartner);
                    return RedirectToAction("Index");
                }
                return View(geschaeftspartner);

            }
            catch
            {
                ViewBag.ErroeMessage = "Es ist ein Fehler beim Speichern aufgetreten";
                return View(geschaeftspartner);
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
