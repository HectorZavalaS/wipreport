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
    public class WIP_RPTAssyController : Controller
    {
        private siixsem_wip_assy_ctrl_dbEntities db = new siixsem_wip_assy_ctrl_dbEntities();
        private CUtils _cu = new CUtils();

        // GET: WIP_RPTAssy
        public ActionResult Index()
        {
            List<WIP_RPT> list = new List<WIP_RPT>();
            String querySQL = _cu.getASSYstatement();

            try {
                list = db.Database.SqlQuery<WIP_RPT>(querySQL).ToList();
            }
            catch(Exception ex){

            }
            return View(list);
        }

        // GET: WIP_RPTAssy/Details/5
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

        // GET: WIP_RPTAssy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WIP_RPTAssy/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT")] WIP_RPT wIP_RPT)
        {
            if (ModelState.IsValid)
            {
                db.WIP_RPT.Add(wIP_RPT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wIP_RPT);
        }

        // GET: WIP_RPTAssy/Edit/5
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

        // POST: WIP_RPTAssy/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOCATOR,MAGAZINE,SCANED_SERIAL,MODEL,ROUTE,DJ_GROUP,QTY,SEMIFINISH,REVIEW,TYPE,QR,USER_READ,QUARANTINE,VALIDATED_BY_QA,USER_VALIDATE,DATE_VALIDATED,STATUS,DATE_IN,DATE_OUT")] WIP_RPT wIP_RPT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIP_RPT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wIP_RPT);
        }

        // GET: WIP_RPTAssy/Delete/5
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

        // POST: WIP_RPTAssy/Delete/5
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
