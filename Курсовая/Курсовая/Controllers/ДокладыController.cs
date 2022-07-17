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
    public class ДокладыController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Доклады
        //Использование процедуры
        public ActionResult Index(int ?idYch, decimal ?maxSum, float ?sell)
        {
            var доклады = db.Доклады.Include(д => д.Докладчики);
            if(idYch!=null && maxSum!=null && sell!=null)
            {
                System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@maxsum", maxSum);
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@sell", sell);
                System.Data.SqlClient.SqlParameter param3 = new System.Data.SqlClient.SqlParameter("@id", idYch);
                db.Database.ExecuteSqlCommand("EXEC SELL @maxsum, @sell, @id", param1, param2, param3);
            }
            return View(доклады.ToList());
        }
        //таблица, доступнаяю только юзерам
        public ActionResult IndexYch()
        {
            var доклады = db.Доклады.Include(д => д.Докладчики);
            return View(доклады.ToList());
        }

        // GET: Доклады/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Доклады доклады = db.Доклады.Find(id);
            if (доклады == null)
            {
                return HttpNotFound();
            }
            return View(доклады);
        }

        // GET: Доклады/Create
        public ActionResult Create()
        {
            ViewBag.ID_докладчика = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт");
            return View();
        }

        // POST: Доклады/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_доклада,Название,Направление,Публикация,Денежный_взнос,Количество_минут,Баллы,ID_докладчика")] Доклады доклады)
        {
            if (ModelState.IsValid)
            {
                db.Доклады.Add(доклады);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_докладчика = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт", доклады.ID_докладчика);
            return View(доклады);
        }

        // GET: Доклады/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Доклады доклады = db.Доклады.Find(id);
            if (доклады == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_докладчика = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт", доклады.ID_докладчика);
            return View(доклады);
        }

        // POST: Доклады/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_доклада,Название,Направление,Публикация,Денежный_взнос,Количество_минут,Баллы,ID_докладчика")] Доклады доклады)
        {
            if (ModelState.IsValid)
            {
                db.Entry(доклады).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_докладчика = new SelectList(db.Докладчики, "ID_докладчика", "Паспорт", доклады.ID_докладчика);
            return View(доклады);
        }

        // GET: Доклады/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Доклады доклады = db.Доклады.Find(id);
            if (доклады == null)
            {
                return HttpNotFound();
            }
            return View(доклады);
        }

        // POST: Доклады/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Доклады доклады = db.Доклады.Find(id);
            db.Доклады.Remove(доклады);
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
