using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace FunClub.Views
{
    public class EntradasController : Controller
    {
        private FunClubEntities db = new FunClubEntities();

        // GET: Entradas
        public ActionResult Index()
        {
            var entradas = db.Entradas.Include(e => e.Consumicion).Include(e => e.Discoteca);
            return View(entradas.ToList());
        }

        // GET: Entradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // GET: Entradas/Create
        public ActionResult Create()
        {
            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion");
            ViewBag.CodDiscoteca = new SelectList(db.Discotecas, "CodDiscoteca", "Descripcion");
            return View();
        }

        // POST: Entradas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodEntrada,CodDiscoteca,FechaRegistro,Descripcion,CodConsumicion,Estado")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entradas.Add(entrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion", entrada.CodConsumicion);
            ViewBag.CodDiscoteca = new SelectList(db.Discotecas, "CodDiscoteca", "Descripcion", entrada.CodDiscoteca);
            return View(entrada);
        }

        // GET: Entradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion", entrada.CodConsumicion);
            ViewBag.CodDiscoteca = new SelectList(db.Discotecas, "CodDiscoteca", "Descripcion", entrada.CodDiscoteca);
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodEntrada,CodDiscoteca,FechaRegistro,Descripcion,CodConsumicion,Estado")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion", entrada.CodConsumicion);
            ViewBag.CodDiscoteca = new SelectList(db.Discotecas, "CodDiscoteca", "Descripcion", entrada.CodDiscoteca);
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrada entrada = db.Entradas.Find(id);
            db.Entradas.Remove(entrada);
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
