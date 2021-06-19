using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarmciaApp.Models;

namespace FarmciaApp.Controllers
{
    public class USUARIOsController : Controller
    {
        private FarmaciaEntities db = new FarmaciaEntities();

        // GET: USUARIOs
        public ActionResult Index()
        {
            var uSUARIOS = db.USUARIOS.Include(u => u.TIPOSUSUARIO);
            return View(uSUARIOS.ToList());
        }

        // GET: USUARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIOs/Create
        public ActionResult Create()
        {
            ViewBag.tipoUsuario = new SelectList(db.TIPOSUSUARIOS, "tipoUsuarioID", "tipoUsuario");
            return View();
        }

        // POST: USUARIOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usuarioID,primerNombre,primerApellido,nombreUsuario,contraseña,tipoUsuario,email")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoUsuario = new SelectList(db.TIPOSUSUARIOS, "tipoUsuarioID", "tipoUsuario", uSUARIO.tipoUsuario);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoUsuario = new SelectList(db.TIPOSUSUARIOS, "tipoUsuarioID", "tipoUsuario", uSUARIO.tipoUsuario);
            return View(uSUARIO);
        }

        // POST: USUARIOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuarioID,primerNombre,primerApellido,nombreUsuario,contraseña,tipoUsuario,email")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoUsuario = new SelectList(db.TIPOSUSUARIOS, "tipoUsuarioID", "tipoUsuario", uSUARIO.tipoUsuario);
            return View(uSUARIO);
        }

        // GET: USUARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIOS.Find(id);
            db.USUARIOS.Remove(uSUARIO);
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
