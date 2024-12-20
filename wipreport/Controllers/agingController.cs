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
    public class agingController : Controller
    {
        private siixsem_wip_control_dbEntities db = new siixsem_wip_control_dbEntities();

        // GET: aging
        public ActionResult Index()
        {
            db.AGING_REPORT();
            return View(db.siixsem_aging_rpt.ToList());
        }

        // GET: aging/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siixsem_aging_rpt siixsem_aging_rpt = db.siixsem_aging_rpt.Find(id);
            if (siixsem_aging_rpt == null)
            {
                return HttpNotFound();
            }
            return View(siixsem_aging_rpt);
        }

        // GET: aging/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: aging/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "se_id,LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJGROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATE_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT,CREATED_DATE,DAYS,AGING")] siixsem_aging_rpt siixsem_aging_rpt)
        {
            if (ModelState.IsValid)
            {
                db.siixsem_aging_rpt.Add(siixsem_aging_rpt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siixsem_aging_rpt);
        }

        // GET: aging/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siixsem_aging_rpt siixsem_aging_rpt = db.siixsem_aging_rpt.Find(id);
            if (siixsem_aging_rpt == null)
            {
                return HttpNotFound();
            }
            return View(siixsem_aging_rpt);
        }

        // POST: aging/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "se_id,LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJGROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATE_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT,CREATED_DATE,DAYS,AGING")] siixsem_aging_rpt siixsem_aging_rpt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siixsem_aging_rpt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siixsem_aging_rpt);
        }

        // GET: aging/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siixsem_aging_rpt siixsem_aging_rpt = db.siixsem_aging_rpt.Find(id);
            if (siixsem_aging_rpt == null)
            {
                return HttpNotFound();
            }
            return View(siixsem_aging_rpt);
        }

        // POST: aging/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            siixsem_aging_rpt siixsem_aging_rpt = db.siixsem_aging_rpt.Find(id);
            db.siixsem_aging_rpt.Remove(siixsem_aging_rpt);
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
