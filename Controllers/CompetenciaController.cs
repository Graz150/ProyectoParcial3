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
    public class CompetenciaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Competencia
        public ActionResult Index()
        {
            return View(db.Competencias.ToList());
        }

        // GET: Competencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.Competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        // GET: Competencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                db.Competencias.Add(competencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competencia);
        }

        // GET: Competencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.Competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        // POST: Competencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] Competencia competencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competencia);
        }

        // GET: Competencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = db.Competencias.Find(id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        // POST: Competencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competencia competencia = db.Competencias.Find(id);
            db.Competencias.Remove(competencia);
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
