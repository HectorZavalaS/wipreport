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
    public class WIP_RPT_FINController : Controller
    {
        private siixsem_wip_control_dbEntities db = new siixsem_wip_control_dbEntities();

        // GET: WIP_RPT_FIN
        public ActionResult Index()
        {
            return View(db.WIP_RPT_FIN.ToList());
        }

        // GET: WIP_RPT_FIN/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT_FIN wIP_RPT_FIN = db.WIP_RPT_FIN.Find(id);
            if (wIP_RPT_FIN == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT_FIN);
        }

        // GET: WIP_RPT_FIN/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WIP_RPT_FIN/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT,VALIDATED_BY_FIN,FIN_USER,FIN_DATE_VALIDATED")] WIP_RPT_FIN wIP_RPT_FIN)
        {
            if (ModelState.IsValid)
            {
                db.WIP_RPT_FIN.Add(wIP_RPT_FIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wIP_RPT_FIN);
        }

        // GET: WIP_RPT_FIN/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT_FIN wIP_RPT_FIN = db.WIP_RPT_FIN.Find(id);
            if (wIP_RPT_FIN == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT_FIN);
        }

        // POST: WIP_RPT_FIN/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT,VALIDATED_BY_FIN,FIN_USER,FIN_DATE_VALIDATED")] WIP_RPT_FIN wIP_RPT_FIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIP_RPT_FIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wIP_RPT_FIN);
        }

        // GET: WIP_RPT_FIN/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT_FIN wIP_RPT_FIN = db.WIP_RPT_FIN.Find(id);
            if (wIP_RPT_FIN == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT_FIN);
        }

        // POST: WIP_RPT_FIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WIP_RPT_FIN wIP_RPT_FIN = db.WIP_RPT_FIN.Find(id);
            db.WIP_RPT_FIN.Remove(wIP_RPT_FIN);
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
