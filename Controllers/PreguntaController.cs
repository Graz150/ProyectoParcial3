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
    public class PreguntaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pregunta
        public ActionResult Index()
        {
            var preguntas = db.Preguntas.Include(p => p.Afirmacion).Include(p => p.Competencia);
            return View(preguntas.ToList());
        }

        // GET: Pregunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // GET: Pregunta/Create
        public ActionResult Create()
        {
            ViewBag.AfirmacionID = new SelectList(db.Afirmacions, "ID", "Nombre");
            ViewBag.CompetenciaID = new SelectList(db.Competencias, "ID", "Nombre");
            return View();
        }

        // POST: Pregunta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,CompetenciaID,AfirmacionID")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Preguntas.Add(pregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AfirmacionID = new SelectList(db.Afirmacions, "ID", "Nombre", pregunta.AfirmacionID);
            ViewBag.CompetenciaID = new SelectList(db.Competencias, "ID", "Nombre", pregunta.CompetenciaID);
            return View(pregunta);
        }

        // GET: Pregunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.AfirmacionID = new SelectList(db.Afirmacions, "ID", "Nombre", pregunta.AfirmacionID);
            ViewBag.CompetenciaID = new SelectList(db.Competencias, "ID", "Nombre", pregunta.CompetenciaID);
            return View(pregunta);
        }

        // POST: Pregunta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,CompetenciaID,AfirmacionID")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AfirmacionID = new SelectList(db.Afirmacions, "ID", "Nombre", pregunta.AfirmacionID);
            ViewBag.CompetenciaID = new SelectList(db.Competencias, "ID", "Nombre", pregunta.CompetenciaID);
            return View(pregunta);
        }

        // GET: Pregunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: Pregunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pregunta pregunta = db.Preguntas.Find(id);
            db.Preguntas.Remove(pregunta);
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
