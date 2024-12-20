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
    public class smtOutController : Controller
    {
        private siixsem_wip_control_dbEntities db = new siixsem_wip_control_dbEntities();

        // GET: smtOut
        public ActionResult Index()
        {
            return View(db.WIP_RPT_OUT.ToList());
        }

        // GET: smtOut/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT_OUT wIP_RPT_OUT = db.WIP_RPT_OUT.Find(id);
            if (wIP_RPT_OUT == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT_OUT);
        }

        // GET: smtOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: smtOut/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT")] WIP_RPT_OUT wIP_RPT_OUT)
        {
            if (ModelState.IsValid)
            {
                db.WIP_RPT_OUT.Add(wIP_RPT_OUT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wIP_RPT_OUT);
        }

        // GET: smtOut/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT_OUT wIP_RPT_OUT = db.WIP_RPT_OUT.Find(id);
            if (wIP_RPT_OUT == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT_OUT);
        }

        // POST: smtOut/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT")] WIP_RPT_OUT wIP_RPT_OUT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIP_RPT_OUT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wIP_RPT_OUT);
        }

        // GET: smtOut/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIP_RPT_OUT wIP_RPT_OUT = db.WIP_RPT_OUT.Find(id);
            if (wIP_RPT_OUT == null)
            {
                return HttpNotFound();
            }
            return View(wIP_RPT_OUT);
        }

        // POST: smtOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WIP_RPT_OUT wIP_RPT_OUT = db.WIP_RPT_OUT.Find(id);
            db.WIP_RPT_OUT.Remove(wIP_RPT_OUT);
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
