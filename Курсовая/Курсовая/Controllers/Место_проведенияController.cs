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
    public class Место_проведенияController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Место_проведения
        public ActionResult Index()
        {
            var место_проведения = db.Место_проведения.Include(м => м.Конференция);
            return View(место_проведения.ToList());
        }

        // GET: Место_проведения/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Место_проведения место_проведения = db.Место_проведения.Find(id);
            if (место_проведения == null)
            {
                return HttpNotFound();
            }
            return View(место_проведения);
        }

        // GET: Место_проведения/Create
        public ActionResult Create()
        {
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции");
            return View();
        }

        // POST: Место_проведения/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_места_проведения,Адрес,Название,Стоимость_аренды,Дата_аренды,ID_конференции")] Место_проведения место_проведения)
        {
            if (ModelState.IsValid)
            {
                db.Место_проведения.Add(место_проведения);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", место_проведения.ID_конференции);
            return View(место_проведения);
        }

        // GET: Место_проведения/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Место_проведения место_проведения = db.Место_проведения.Find(id);
            if (место_проведения == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", место_проведения.ID_конференции);
            return View(место_проведения);
        }

        // POST: Место_проведения/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_места_проведения,Адрес,Название,Стоимость_аренды,Дата_аренды,ID_конференции")] Место_проведения место_проведения)
        {
            if (ModelState.IsValid)
            {
                db.Entry(место_проведения).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", место_проведения.ID_конференции);
            return View(место_проведения);
        }

        // GET: Место_проведения/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Место_проведения место_проведения = db.Место_проведения.Find(id);
            if (место_проведения == null)
            {
                return HttpNotFound();
            }
            return View(место_проведения);
        }

        // POST: Место_проведения/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Место_проведения место_проведения = db.Место_проведения.Find(id);
            db.Место_проведения.Remove(место_проведения);
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
