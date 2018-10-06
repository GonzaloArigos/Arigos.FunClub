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
    public class PrecioEntradasController : Controller
    {
        private FunClubEntities db = new FunClubEntities();

        // GET: PrecioEntradas
        public ActionResult Index()
        {
            var precioEntradas = db.PrecioEntradas.Include(p => p.Entrada);
            return View(precioEntradas.ToList());
        }

        // GET: PrecioEntradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioEntrada precioEntrada = db.PrecioEntradas.Find(id);
            if (precioEntrada == null)
            {
                return HttpNotFound();
            }
            return View(precioEntrada);
        }

        // GET: PrecioEntradas/Create
        public ActionResult Create()
        {
            ViewBag.CodEntrada = new SelectList(db.Entradas, "CodEntrada", "Descripcion");
            return View();
        }

        // POST: PrecioEntradas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodPrecioEntrada,Precio,FechaInicio,FechaFin,Observaciones,FechaAlta,TerminalAlta,UsuarioAlta,FechaMod,TerminalMod,UsuarioMod,Puntos,CodEntrada,CodDiscoteca")] PrecioEntrada precioEntrada)
        {
            if (ModelState.IsValid)
            {
                precioEntrada.CodDiscoteca = 1;
                db.PrecioEntradas.Add(precioEntrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodEntrada = new SelectList(db.Entradas, "CodEntrada", "Descripcion", precioEntrada.CodEntrada);
            return View(precioEntrada);
        }

        // GET: PrecioEntradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioEntrada precioEntrada = db.PrecioEntradas.Find(id);
            if (precioEntrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodEntrada = new SelectList(db.Entradas, "CodEntrada", "Descripcion", precioEntrada.CodEntrada);
            return View(precioEntrada);
        }

        // POST: PrecioEntradas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPrecioEntrada,Precio,FechaInicio,FechaFin,Observaciones,FechaAlta,TerminalAlta,UsuarioAlta,FechaMod,TerminalMod,UsuarioMod,Puntos,CodEntrada,CodDiscoteca")] PrecioEntrada precioEntrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precioEntrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodEntrada = new SelectList(db.Entradas, "CodEntrada", "Descripcion", precioEntrada.CodEntrada);
            return View(precioEntrada);
        }

        // GET: PrecioEntradas/Delete/5
        public ActionResult Delete(int? disco,int? entrada, DateTime? fecha )
        {
            if (disco == null || entrada == null || fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecioEntrada precioEntrada = db.PrecioEntradas.Where(a => a.CodDiscoteca == disco && a.CodEntrada == entrada && a.FechaInicio == fecha).FirstOrDefault();
            if (precioEntrada == null)
            {
                return HttpNotFound();
            }
            return View(precioEntrada);
        }

        // POST: PrecioEntradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? disco, int? entrada, DateTime? fecha)
        {
            PrecioEntrada precioEntrada = db.PrecioEntradas.Where(a => a.CodDiscoteca == disco && a.CodEntrada == entrada && a.FechaInicio == fecha).FirstOrDefault();
            db.PrecioEntradas.Remove(precioEntrada);
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
