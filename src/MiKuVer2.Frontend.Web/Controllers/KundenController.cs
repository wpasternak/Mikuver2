﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiKuVer2.Frontend.Web.Controllers
{
    using MiKuVer2.Model;
    using MiKuVer2.Services;

    public class KundenController : Controller
    {
        private IKundenService kundenService = new KundenService();

        //
        // GET: /Kunden/

        public ActionResult Index()
        {
            var kunden = this.kundenService.GetDirekteKunden();
            return View(kunden);
        }

        //
        // GET: /Kunden/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Kunden/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Kunden/Create

        [HttpPost]
        public ActionResult Create(Kunde neuerKunde)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Kunden/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Kunden/Edit/5

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
        // GET: /Kunden/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Kunden/Delete/5

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