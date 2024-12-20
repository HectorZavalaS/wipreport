using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wipreport.Class;
using wipreport.Models;

namespace wipreport.Controllers
{
    public class WIP_RPTController : Controller
    {
        private siixsem_wip_control_dbEntities db = new siixsem_wip_control_dbEntities();

        // GET: WIP_RPT
        public ActionResult Index()
        {
            siixsem_wip_control_dbEntities m_db = new siixsem_wip_control_dbEntities();

            //CUtils utils = new CUtils();

            //DataTable report = utils.ToDataTable(m_db.getSMTIN().ToList());
            return View(m_db.getSMTIN().ToList());
        }

        // GET: WIP_RPT/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT wIP_RPT = db.WIP_RPT.Find(id);
            if (wIP_RPT == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT);
        }

        // GET: WIP_RPT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WIP_RPT/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,DATE_IN,USER_READ,QUARANTINE,VALIDATED_BY_QA,STATUS")] WIP_RPT wIP_RPT)
        {
            if (ModelState.IsValid)
            {
                db.WIP_RPT.Add(wIP_RPT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wIP_RPT);
        }

        // GET: WIP_RPT/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT wIP_RPT = db.WIP_RPT.Find(id);
            if (wIP_RPT == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT);
        }

        // POST: WIP_RPT/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,DATE_IN,USER_READ,QUARANTINE,VALIDATED_BY_QA,STATUS")] WIP_RPT wIP_RPT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIP_RPT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wIP_RPT);
        }

        // GET: WIP_RPT/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT wIP_RPT = db.WIP_RPT.Find(id);
            if (wIP_RPT == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT);
        }

        // POST: WIP_RPT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WIP_RPT wIP_RPT = db.WIP_RPT.Find(id);
            db.WIP_RPT.Remove(wIP_RPT);
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
