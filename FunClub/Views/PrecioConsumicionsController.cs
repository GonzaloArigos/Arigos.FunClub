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
    public class PrecioConsumicionsController : Controller
    {
        private FunClubEntities db = new FunClubEntities();

        // GET: PrecioConsumicions
        public ActionResult Index()
        {
            var precioConsumicions = db.PrecioConsumicions.Include(p => p.Consumicion);
            return View(precioConsumicions.ToList());
        }

        // GET: PrecioConsumicions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioConsumicion precioConsumicion = db.PrecioConsumicions.Find(id);
            if (precioConsumicion == null)
            {
                return HttpNotFound();
            }
            return View(precioConsumicion);
        }

        // GET: PrecioConsumicions/Create
        public ActionResult Create()
        {
            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion");
            return View();
        }

        // POST: PrecioConsumicions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPrecioConsumicion,FechaVigencia,FechaFin,Precio,Observaciones,FechaAlta,TerminalAlta,UsuarioAlta,FechaMod,TerminalMod,UsuarioMod,Puntos,CodConsumicion,CodDiscoteca")] PrecioConsumicion precioConsumicion)
        {
            if (ModelState.IsValid)
            {
                db.PrecioConsumicions.Add(precioConsumicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion", precioConsumicion.CodConsumicion);
            return View(precioConsumicion);
        }

        // GET: PrecioConsumicions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioConsumicion precioConsumicion = db.PrecioConsumicions.Find(id);
            if (precioConsumicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion", precioConsumicion.CodConsumicion);
            return View(precioConsumicion);
        }

        // POST: PrecioConsumicions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPrecioConsumicion,FechaVigencia,FechaFin,Precio,Observaciones,FechaAlta,TerminalAlta,UsuarioAlta,FechaMod,TerminalMod,UsuarioMod,Puntos,CodConsumicion,CodDiscoteca")] PrecioConsumicion precioConsumicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precioConsumicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodConsumicion = new SelectList(db.Consumicions, "CodConsumicion", "Descripcion", precioConsumicion.CodConsumicion);
            return View(precioConsumicion);
        }

        // GET: PrecioConsumicions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioConsumicion precioConsumicion = db.PrecioConsumicions.Find(id);
            if (precioConsumicion == null)
            {
                return HttpNotFound();
            }
            return View(precioConsumicion);
        }

        // POST: PrecioConsumicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecioConsumicion precioConsumicion = db.PrecioConsumicions.Find(id);
            db.PrecioConsumicions.Remove(precioConsumicion);
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
