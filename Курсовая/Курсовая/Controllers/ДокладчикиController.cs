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
    public class ДокладчикиController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Докладчики
        public ActionResult Index()
        {
            var докладчики = db.Докладчики.Include(д => д.Участники);
            return View(докладчики.ToList());
        }

        //Проверка уникального Id
        public class UniqueIdDoklAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();
                var dokladchik = db.Докладчики.SingleOrDefault(
                    u => u.ID_докладчика == (int)value);
                return dokladchik == null;
            }
        }


        // GET: Докладчики/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Докладчики докладчики = db.Докладчики.Find(id);
            if (докладчики == null)
            {
                return HttpNotFound();
            }
            return View(докладчики);
        }

        // GET: Докладчики/Create
        public ActionResult Create()
        {
            ViewBag.ID_докладчика = new SelectList(db.Участники, "ID_участника", "Телефон");
            return View();
        }

        // POST: Докладчики/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_докладчика,Паспорт,Дата_рождения,Учебное_заведение,Курс,Научный_руководитель")] Докладчики докладчики)
        {
            if (ModelState.IsValid)
            {
                db.Докладчики.Add(докладчики);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_докладчика = new SelectList(db.Участники, "ID_участника", "Телефон", докладчики.ID_докладчика);
            return View(докладчики);
        }

        // GET: Докладчики/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Докладчики докладчики = db.Докладчики.Find(id);
            if (докладчики == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_докладчика = new SelectList(db.Участники, "ID_участника", "Телефон", докладчики.ID_докладчика);
            return View(докладчики);
        }

        // POST: Докладчики/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_докладчика,Паспорт,Дата_рождения,Учебное_заведение,Курс,Научный_руководитель")] Докладчики докладчики)
        {
            if (ModelState.IsValid)
            {
                db.Entry(докладчики).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_докладчика = new SelectList(db.Участники, "ID_участника", "Телефон", докладчики.ID_докладчика);
            return View(докладчики);
        }

        // GET: Докладчики/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Докладчики докладчики = db.Докладчики.Find(id);
            if (докладчики == null)
            {
                return HttpNotFound();
            }
            return View(докладчики);
        }

        // POST: Докладчики/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Докладчики докладчики = db.Докладчики.Find(id);
            db.Докладчики.Remove(докладчики);
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
