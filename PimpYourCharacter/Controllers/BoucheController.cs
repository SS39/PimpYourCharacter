﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PimpYourCharacter.Models;

namespace PimpYourCharacter.Controllers
{
    public class BoucheController : Controller
    {
        private pimp_your_characterEntities db = new pimp_your_characterEntities();

        // GET: Bouche
        public ActionResult Index()
        {
            var bouche = db.bouche.Include(b => b.couleur);
            return View(bouche.ToList());
        }

        // GET: Bouche/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bouche bouche = db.bouche.Find(id);
            if (bouche == null)
            {
                return HttpNotFound();
            }
            return View(bouche);
        }

        // GET: Bouche/Create
        public ActionResult Create()
        {
            ViewBag.id_couleur = new SelectList(db.couleur, "id_couleur", "label");
            return View();
        }

        // POST: Bouche/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_bouche,forme,largeur,hauteur,profondeur,id_couleur")] bouche bouche)
        {
            if (ModelState.IsValid)
            {
                db.bouche.Add(bouche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_couleur = new SelectList(db.couleur, "id_couleur", "label", bouche.id_couleur);
            return View(bouche);
        }

        // GET: Bouche/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bouche bouche = db.bouche.Find(id);
            if (bouche == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_couleur = new SelectList(db.couleur, "id_couleur", "label", bouche.id_couleur);
            return View(bouche);
        }

        // POST: Bouche/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_bouche,forme,largeur,hauteur,profondeur,id_couleur")] bouche bouche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bouche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_couleur = new SelectList(db.couleur, "id_couleur", "label", bouche.id_couleur);
            return View(bouche);
        }

        // GET: Bouche/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bouche bouche = db.bouche.Find(id);
            if (bouche == null)
            {
                return HttpNotFound();
            }
            return View(bouche);
        }

        // POST: Bouche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bouche bouche = db.bouche.Find(id);
            db.bouche.Remove(bouche);
            db.SaveChanges();
            return RedirectToAction("Index");
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
