using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Курсовая;

namespace Курсовая.Controllers
{
    public class ЗонаController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Зона
        public ActionResult Index()
        {
            var зона = db.Зона.Include(з => з.Место_проведения);
            return View(зона.ToList());
        }

        // GET: Зона/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Зона зона = db.Зона.Find(id);
            if (зона == null)
            {
                return HttpNotFound();
            }
            return View(зона);
        }

        // GET: Зона/Create
        public ActionResult Create()
        {
            ViewBag.ID_места_нахождения = new SelectList(db.Место_проведения, "ID_места_проведения", "Адрес");
            return View();
        }

        // POST: Зона/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_зоны,Название,Предназначение,Технический_специалист,Техника,ID_места_нахождения")] Зона зона)
        {
            if (ModelState.IsValid)
            {
                db.Зона.Add(зона);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_места_нахождения = new SelectList(db.Место_проведения, "ID_места_проведения", "Адрес", зона.ID_места_нахождения);
            return View(зона);
        }

        // GET: Зона/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Зона зона = db.Зона.Find(id);
            if (зона == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_места_нахождения = new SelectList(db.Место_проведения, "ID_места_проведения", "Адрес", зона.ID_места_нахождения);
            return View(зона);
        }

        // POST: Зона/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_зоны,Название,Предназначение,Технический_специалист,Техника,ID_места_нахождения")] Зона зона)
        {
            if (ModelState.IsValid)
            {
                db.Entry(зона).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_места_нахождения = new SelectList(db.Место_проведения, "ID_места_проведения", "Адрес", зона.ID_места_нахождения);
            return View(зона);
        }

        // GET: Зона/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Зона зона = db.Зона.Find(id);
            if (зона == null)
            {
                return HttpNotFound();
            }
            return View(зона);
        }

        // POST: Зона/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Зона зона = db.Зона.Find(id);
            db.Зона.Remove(зона);
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
