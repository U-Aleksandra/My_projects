using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Курсовая;

namespace Курсовая.Controllers
{
    public class ОрганизаторыController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Организаторы
        public ActionResult Index()
        {
            var организаторы = db.Организаторы.Include(о => о.Участники);
            return View(организаторы.ToList());
        }

        //проверка уникального ID
        public class UniqueIdOrgAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();
                var organizator = db.Организаторы.SingleOrDefault(
                    u => u.ID_организатора == (int)value);
                return organizator == null;
            }
        }

        // GET: Организаторы/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Организаторы организаторы = db.Организаторы.Find(id);
            if (организаторы == null)
            {
                return HttpNotFound();
            }
            return View(организаторы);
        }

        // GET: Организаторы/Create
        public ActionResult Create()
        {
            ViewBag.ID_организатора = new SelectList(db.Участники, "ID_участника", "Телефон");
            return View();
        }

        // POST: Организаторы/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_организатора,Должность,Обязанность,Комиссия")] Организаторы организаторы)
        {
            if (ModelState.IsValid)
            {
                db.Организаторы.Add(организаторы);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_организатора = new SelectList(db.Участники, "ID_участника", "Телефон", организаторы.ID_организатора);
            return View(организаторы);
        }

        // GET: Организаторы/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Организаторы организаторы = db.Организаторы.Find(id);
            if (организаторы == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_организатора = new SelectList(db.Участники, "ID_участника", "Телефон", организаторы.ID_организатора);
            return View(организаторы);
        }

        // POST: Организаторы/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_организатора,Должность,Обязанность,Комиссия")] Организаторы организаторы)
        {
            if (ModelState.IsValid)
            {
                db.Entry(организаторы).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_организатора = new SelectList(db.Участники, "ID_участника", "Телефон", организаторы.ID_организатора);
            return View(организаторы);
        }

        // GET: Организаторы/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Организаторы организаторы = db.Организаторы.Find(id);
            if (организаторы == null)
            {
                return HttpNotFound();
            }
            return View(организаторы);
        }

        // POST: Организаторы/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Организаторы организаторы = db.Организаторы.Find(id);
            db.Организаторы.Remove(организаторы);
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
