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
    public class MEDICAMENTOesController : Controller
    {
        private FarmaciaEntities db = new FarmaciaEntities();

        // GET: MEDICAMENTOes
        public ActionResult Index()
        {
            var mEDICAMENTOes = db.MEDICAMENTOes.Include(m => m.PRESENTACION1).Include(m => m.TIPOFARMACO1).Include(m => m.TIPOMEDICAMENTO1).Include(m => m.TIPOESPECIFICO1);
            return View(mEDICAMENTOes.ToList());
        }

        // GET: MEDICAMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTOes.Find(id);
            if (mEDICAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(mEDICAMENTO);
        }

        // GET: MEDICAMENTOes/Create
        public ActionResult Create()
        {
            ViewBag.presentacion = new SelectList(db.PRESENTACIONs, "id", "nombrePresentacion");
            ViewBag.tipoFarmaco = new SelectList(db.TIPOFARMACOes, "id", "nombreTipoFar");
            ViewBag.tipoMedicamento = new SelectList(db.TIPOMEDICAMENTOes, "id", "nombreTipo");
            ViewBag.tipoEspecifico = new SelectList(db.TIPOESPECIFICOes, "id", "nombreTipEsp");
            return View();
        }

        // POST: MEDICAMENTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,precio,presentacion,tipoMedicamento,cantidad,indicaciones,tipoFarmaco,tipoEspecifico,existencia")] MEDICAMENTO mEDICAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.MEDICAMENTOes.Add(mEDICAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.presentacion = new SelectList(db.PRESENTACIONs, "id", "nombrePresentacion", mEDICAMENTO.presentacion);
            ViewBag.tipoFarmaco = new SelectList(db.TIPOFARMACOes, "id", "nombreTipoFar", mEDICAMENTO.tipoFarmaco);
            ViewBag.tipoMedicamento = new SelectList(db.TIPOMEDICAMENTOes, "id", "nombreTipo", mEDICAMENTO.tipoMedicamento);
            ViewBag.tipoEspecifico = new SelectList(db.TIPOESPECIFICOes, "id", "nombreTipEsp", mEDICAMENTO.tipoEspecifico);
            return View(mEDICAMENTO);
        }

        // GET: MEDICAMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTOes.Find(id);
            if (mEDICAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.presentacion = new SelectList(db.PRESENTACIONs, "id", "nombrePresentacion", mEDICAMENTO.presentacion);
            ViewBag.tipoFarmaco = new SelectList(db.TIPOFARMACOes, "id", "nombreTipoFar", mEDICAMENTO.tipoFarmaco);
            ViewBag.tipoMedicamento = new SelectList(db.TIPOMEDICAMENTOes, "id", "nombreTipo", mEDICAMENTO.tipoMedicamento);
            ViewBag.tipoEspecifico = new SelectList(db.TIPOESPECIFICOes, "id", "nombreTipEsp", mEDICAMENTO.tipoEspecifico);
            return View(mEDICAMENTO);
        }

        // POST: MEDICAMENTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,precio,presentacion,tipoMedicamento,cantidad,indicaciones,tipoFarmaco,tipoEspecifico,existencia")] MEDICAMENTO mEDICAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEDICAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.presentacion = new SelectList(db.PRESENTACIONs, "id", "nombrePresentacion", mEDICAMENTO.presentacion);
            ViewBag.tipoFarmaco = new SelectList(db.TIPOFARMACOes, "id", "nombreTipoFar", mEDICAMENTO.tipoFarmaco);
            ViewBag.tipoMedicamento = new SelectList(db.TIPOMEDICAMENTOes, "id", "nombreTipo", mEDICAMENTO.tipoMedicamento);
            ViewBag.tipoEspecifico = new SelectList(db.TIPOESPECIFICOes, "id", "nombreTipEsp", mEDICAMENTO.tipoEspecifico);
            return View(mEDICAMENTO);
        }

        // GET: MEDICAMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTOes.Find(id);
            if (mEDICAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(mEDICAMENTO);
        }

        // POST: MEDICAMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEDICAMENTO mEDICAMENTO = db.MEDICAMENTOes.Find(id);
            db.MEDICAMENTOes.Remove(mEDICAMENTO);
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
