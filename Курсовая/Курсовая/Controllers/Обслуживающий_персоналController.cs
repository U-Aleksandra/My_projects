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
    public class Обслуживающий_персоналController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Обслуживающий_персонал
        public ActionResult Index()
        {
            var обслуживающий_персонал = db.Обслуживающий_персонал.Include(о => о.Зона).Include(о => о.Участники);
            return View(обслуживающий_персонал.ToList());
        }

        //проверка уникальности Id
        public class UniqueIdPersAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();
                var personal = db.Обслуживающий_персонал.SingleOrDefault(
                    u => u.ID_сотрудника == (int)value);
                return personal == null;
            }
        }

        // GET: Обслуживающий_персонал/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Обслуживающий_персонал обслуживающий_персонал = db.Обслуживающий_персонал.Find(id);
            if (обслуживающий_персонал == null)
            {
                return HttpNotFound();
            }
            return View(обслуживающий_персонал);
        }

        // GET: Обслуживающий_персонал/Create
        public ActionResult Create()
        {
            ViewBag.Ответственная_зона = new SelectList(db.Зона, "ID_зоны", "Название");
            ViewBag.ID_сотрудника = new SelectList(db.Участники, "ID_участника", "Телефон");
            return View();
        }

        // POST: Обслуживающий_персонал/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_сотрудника,Ответственная_зона,Обязанности,Стоимость_услуг")] Обслуживающий_персонал обслуживающий_персонал)
        {
            if (ModelState.IsValid)
            {
                db.Обслуживающий_персонал.Add(обслуживающий_персонал);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ответственная_зона = new SelectList(db.Зона, "ID_зоны", "Название", обслуживающий_персонал.Ответственная_зона);
            ViewBag.ID_сотрудника = new SelectList(db.Участники, "ID_участника", "Телефон", обслуживающий_персонал.ID_сотрудника);
            return View(обслуживающий_персонал);
        }

        // GET: Обслуживающий_персонал/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Обслуживающий_персонал обслуживающий_персонал = db.Обслуживающий_персонал.Find(id);
            if (обслуживающий_персонал == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ответственная_зона = new SelectList(db.Зона, "ID_зоны", "Название", обслуживающий_персонал.Ответственная_зона);
            ViewBag.ID_сотрудника = new SelectList(db.Участники, "ID_участника", "Телефон", обслуживающий_персонал.ID_сотрудника);
            return View(обслуживающий_персонал);
        }

        // POST: Обслуживающий_персонал/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_сотрудника,Ответственная_зона,Обязанности,Стоимость_услуг")] Обслуживающий_персонал обслуживающий_персонал)
        {
            if (ModelState.IsValid)
            {
                db.Entry(обслуживающий_персонал).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ответственная_зона = new SelectList(db.Зона, "ID_зоны", "Название", обслуживающий_персонал.Ответственная_зона);
            ViewBag.ID_сотрудника = new SelectList(db.Участники, "ID_участника", "Телефон", обслуживающий_персонал.ID_сотрудника);
            return View(обслуживающий_персонал);
        }

        // GET: Обслуживающий_персонал/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Обслуживающий_персонал обслуживающий_персонал = db.Обслуживающий_персонал.Find(id);
            if (обслуживающий_персонал == null)
            {
                return HttpNotFound();
            }
            return View(обслуживающий_персонал);
        }

        // POST: Обслуживающий_персонал/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Обслуживающий_персонал обслуживающий_персонал = db.Обслуживающий_персонал.Find(id);
            db.Обслуживающий_персонал.Remove(обслуживающий_персонал);
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
