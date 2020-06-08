using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoParcial3.Models;

namespace ProyectoParcial3.Controllers
{
    public class AfirmacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Afirmacion
        public ActionResult Index()
        {
            return View(db.Afirmacions.ToList());
        }

        // GET: Afirmacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afirmacion afirmacion = db.Afirmacions.Find(id);
            if (afirmacion == null)
            {
                return HttpNotFound();
            }
            return View(afirmacion);
        }

        // GET: Afirmacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Afirmacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] Afirmacion afirmacion)
        {
            if (ModelState.IsValid)
            {
                db.Afirmacions.Add(afirmacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(afirmacion);
        }

        // GET: Afirmacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afirmacion afirmacion = db.Afirmacions.Find(id);
            if (afirmacion == null)
            {
                return HttpNotFound();
            }
            return View(afirmacion);
        }

        // POST: Afirmacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] Afirmacion afirmacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afirmacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(afirmacion);
        }

        // GET: Afirmacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afirmacion afirmacion = db.Afirmacions.Find(id);
            if (afirmacion == null)
            {
                return HttpNotFound();
            }
            return View(afirmacion);
        }

        // POST: Afirmacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afirmacion afirmacion = db.Afirmacions.Find(id);
            db.Afirmacions.Remove(afirmacion);
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
