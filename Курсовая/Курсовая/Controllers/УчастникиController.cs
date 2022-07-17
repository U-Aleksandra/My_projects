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
    public class УчастникиController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Участники
        public ActionResult Index()
        {
            var участники = db.Участники.Include(у => у.Докладчики).Include(у => у.Конференция).Include(у => у.Обслуживающий_персонал).Include(у => у.Организаторы);
            return View(участники.ToList());
        }

        // GET: Участники/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участники участники = db.Участники.Find(id);
            if (участники == null)
            {
                return HttpNotFound();
            }
            return View(участники);
        }

        // GET: Участники/Create
        public ActionResult Create()
        {
            ViewBag.ID_участника = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт");
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции");
            ViewBag.ID_участника = new SelectList(db.Обслуживающий_персонал, "ID_сотрудника", "Обязанности");
            ViewBag.ID_участника = new SelectList(db.Организаторы, "ID_организатора", "Должность");
            return View();
        }

        // POST: Участники/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_участника,ID_конференции,Фамилия,Имя,Отчество,Телефон,Почта")] Участники участники)
        {
            if (ModelState.IsValid)
            {
                db.Участники.Add(участники);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_участника = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт", участники.ID_участника);
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", участники.ID_конференции);
            ViewBag.ID_участника = new SelectList(db.Обслуживающий_персонал, "ID_сотрудника", "Обязанности", участники.ID_участника);
            ViewBag.ID_участника = new SelectList(db.Организаторы, "ID_организатора", "Должность", участники.ID_участника);
            return View(участники);
        }

        // GET: Участники/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участники участники = db.Участники.Find(id);
            if (участники == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_участника = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт", участники.ID_участника);
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", участники.ID_конференции);
            ViewBag.ID_участника = new SelectList(db.Обслуживающий_персонал, "ID_сотрудника", "Обязанности", участники.ID_участника);
            ViewBag.ID_участника = new SelectList(db.Организаторы, "ID_организатора", "Должность", участники.ID_участника);
            return View(участники);
        }

        // POST: Участники/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_участника,ID_конференции,Фамилия,Имя,Отчество,Телефон,Почта")] Участники участники)
        {
            if (ModelState.IsValid)
            {
                db.Entry(участники).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_участника = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт", участники.ID_участника);
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", участники.ID_конференции);
            ViewBag.ID_участника = new SelectList(db.Обслуживающий_персонал, "ID_сотрудника", "Обязанности", участники.ID_участника);
            ViewBag.ID_участника = new SelectList(db.Организаторы, "ID_организатора", "Должность", участники.ID_участника);
            return View(участники);
        }

        // GET: Участники/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Участники участники = db.Участники.Find(id);
            if (участники == null)
            {
                return HttpNotFound();
            }
            return View(участники);
        }

        // POST: Участники/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Участники участники = db.Участники.Find(id);
            db.Участники.Remove(участники);
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
