using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wipreport.Models;

namespace wipreport.Controllers
{
    public class assyRptFinController : Controller
    {
        private siixsem_stocktake_dbEntities db = new siixsem_stocktake_dbEntities();

        // GET: assyRptFin
        public ActionResult Index()
        {
            return View(db.ST_ASSY_FIN_RPT.ToList());
        }

        // GET: assyRptFin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ST_ASSY_FIN_RPT sT_ASSY_FIN_RPT = db.ST_ASSY_FIN_RPT.Find(id);
            if (sT_ASSY_FIN_RPT == null)
            {
                return HttpNotFound();
            }
            return View(sT_ASSY_FIN_RPT);
        }

        // GET: assyRptFin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: assyRptFin/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT,VALIDATED_BY_FIN,FIN_USER,FIN_QTY,FIN_DATE_VALIDATED")] ST_ASSY_FIN_RPT sT_ASSY_FIN_RPT)
        {
            if (ModelState.IsValid)
            {
                db.ST_ASSY_FIN_RPT.Add(sT_ASSY_FIN_RPT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sT_ASSY_FIN_RPT);
        }

        // GET: assyRptFin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ST_ASSY_FIN_RPT sT_ASSY_FIN_RPT = db.ST_ASSY_FIN_RPT.Find(id);
            if (sT_ASSY_FIN_RPT == null)
            {
                return HttpNotFound();
            }
            return View(sT_ASSY_FIN_RPT);
        }

        // POST: assyRptFin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT,VALIDATED_BY_FIN,FIN_USER,FIN_QTY,FIN_DATE_VALIDATED")] ST_ASSY_FIN_RPT sT_ASSY_FIN_RPT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sT_ASSY_FIN_RPT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sT_ASSY_FIN_RPT);
        }

        // GET: assyRptFin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ST_ASSY_FIN_RPT sT_ASSY_FIN_RPT = db.ST_ASSY_FIN_RPT.Find(id);
            if (sT_ASSY_FIN_RPT == null)
            {
                return HttpNotFound();
            }
            return View(sT_ASSY_FIN_RPT);
        }

        // POST: assyRptFin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ST_ASSY_FIN_RPT sT_ASSY_FIN_RPT = db.ST_ASSY_FIN_RPT.Find(id);
            db.ST_ASSY_FIN_RPT.Remove(sT_ASSY_FIN_RPT);
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
