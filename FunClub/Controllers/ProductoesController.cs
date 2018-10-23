using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Newtonsoft.Json;

namespace FunClub.Controllers
{
    public class ProductoesController : Controller
    {
        private FunClubEntities db = new FunClubEntities();

        // GET: Productoes
        public ActionResult Index()
        {
            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(User.Identity.Name).FirstOrDefault();
            if (disco != null)
            {
                var productos = db.Productos.Include(p => p.Discoteca).Where(a=> a.CodDiscoteca == disco.CodDiscoteca);
                return View(productos.ToList());
            }
            return null;
            }

        public string GetProductosDisco()
        {
            var disco = BLL.DiscotecaBLL.GetDiscotecasUsuario(User.Identity.Name).FirstOrDefault();
            if (disco != null)
            {
                var productos = db.Productos.Include(p => p.Discoteca).Where(a => a.CodDiscoteca == disco.CodDiscoteca);

                return JsonConvert.SerializeObject(productos.ToList(), Formatting.None,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                 });
            }
            return null;
        }
    

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {

            ViewBag.CodDiscoteca = new SelectList(db.Discotecas.Where(a=> a.Usuario_Discotecas.Any(k=> k.EmailUsuario == User.Identity.Name)), "CodDiscoteca", "Descripcion");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descripcion,CodDiscoteca")] Producto producto)
        {
            if (ModelState.IsValid)
            {

                int? id = db.Productos.Any(a => a.CodDiscoteca == producto.CodDiscoteca) ? db.Productos.Where(a => a.CodDiscoteca == producto.CodDiscoteca).Max(a => a.CodBebida) : 0;
                producto.CodBebida = id >= 1 ? (int)id + 1 : 1;
                producto.TerminalAlta = "Servidor";
                producto.UsuarioAlta = User.Identity.Name;
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodDiscoteca = new SelectList(db.Discotecas, "CodDiscoteca", "Descripcion", producto.CodDiscoteca);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? idprod,int? coddisco)
        {
            if (idprod == null || coddisco == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Where(a => a.CodBebida == idprod && a.CodDiscoteca == coddisco).FirstOrDefault();
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodDiscoteca = new SelectList(db.Discotecas, "CodDiscoteca", "Descripcion", producto.CodDiscoteca);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodBebida,Descripcion,FechaAlta,TerminalAlta,UsuarioAlta,FechaMod,TerminalMod,UsuarioMod,CodDiscoteca")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodDiscoteca = new SelectList(db.Discotecas, "CodDiscoteca", "Descripcion", producto.CodDiscoteca);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
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
