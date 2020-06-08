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
    public class ProgramaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Programa
        public ActionResult Index()
        {
            return View(db.Programas.ToList());
        }

        // GET: Programa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programa programa = db.Programas.Find(id);
            if (programa == null)
            {
                return HttpNotFound();
            }
            return View(programa);
        }

        // GET: Programa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                db.Programas.Add(programa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programa);
        }

        // GET: Programa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programa programa = db.Programas.Find(id);
            if (programa == null)
            {
                return HttpNotFound();
            }
            return View(programa);
        }

        // POST: Programa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programa);
        }

        // GET: Programa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programa programa = db.Programas.Find(id);
            if (programa == null)
            {
                return HttpNotFound();
            }
            return View(programa);
        }

        // POST: Programa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programa programa = db.Programas.Find(id);
            db.Programas.Remove(programa);
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
