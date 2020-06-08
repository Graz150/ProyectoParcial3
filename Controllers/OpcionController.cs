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
    public class OpcionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Opcion
        public ActionResult Index()
        {
            var opcions = db.Opcions.Include(o => o.Pregunta);
            return View(opcions.ToList());
        }

        // GET: Opcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.Opcions.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            return View(opcion);
        }

        // GET: Opcion/Create
        public ActionResult Create()
        {
            ViewBag.PreguntaID = new SelectList(db.Preguntas, "ID", "Nombre");
            return View();
        }

        // POST: Opcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,PreguntaID,Tipo")] Opcion opcion)
        {
            if (ModelState.IsValid)
            {
                db.Opcions.Add(opcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PreguntaID = new SelectList(db.Preguntas, "ID", "Nombre", opcion.PreguntaID);
            return View(opcion);
        }

        // GET: Opcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.Opcions.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.PreguntaID = new SelectList(db.Preguntas, "ID", "Nombre", opcion.PreguntaID);
            return View(opcion);
        }

        // POST: Opcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,PreguntaID,Tipo")] Opcion opcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PreguntaID = new SelectList(db.Preguntas, "ID", "Nombre", opcion.PreguntaID);
            return View(opcion);
        }

        // GET: Opcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcion opcion = db.Opcions.Find(id);
            if (opcion == null)
            {
                return HttpNotFound();
            }
            return View(opcion);
        }

        // POST: Opcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opcion opcion = db.Opcions.Find(id);
            db.Opcions.Remove(opcion);
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
