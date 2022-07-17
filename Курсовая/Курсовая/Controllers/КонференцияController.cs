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
    public class КонференцияController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Конференция
        //поиск данных
        public ViewResult Index(string searchString, string date)
        {
            var konferencia = from k in db.Конференция
                              select k;
            if (!String.IsNullOrEmpty(searchString))
            {
                konferencia = konferencia.Where(k => k.Город== searchString);
            }
            if (!String.IsNullOrEmpty(date))
            {
                DateTime Date = DateTime.Parse(date);
                konferencia = konferencia.Where(k => k.Дата_проведения_Начало == Date);
            }
            return View(konferencia);
        }

        //функция, расчитывающая расходы
        public ActionResult Budget(int? idKonf, int? sbornik, float? hour, float? pers)
        {
            System.Data.SqlClient.SqlParameter Id = new System.Data.SqlClient.SqlParameter("@idKonf", 100000000);
            System.Data.SqlClient.SqlParameter Sborn = new System.Data.SqlClient.SqlParameter("@countSbornik", 1);
            System.Data.SqlClient.SqlParameter Hour = new System.Data.SqlClient.SqlParameter("@hour", 0.1);
            System.Data.SqlClient.SqlParameter Personal = new System.Data.SqlClient.SqlParameter("@countStaff", 0.1);
            if (idKonf != null && sbornik != null && hour != null && pers != null)
            {
                Id = new System.Data.SqlClient.SqlParameter("@idKonf", idKonf);
                Sborn = new System.Data.SqlClient.SqlParameter("@countSbornik", sbornik);
                Hour = new System.Data.SqlClient.SqlParameter("@hour", hour);
                Personal = new System.Data.SqlClient.SqlParameter("@countStaff", pers);
            }
                var budget = db.Database.SqlQuery<budget_Result>("SELECT * FROM Budget (@idKonf,@countSbornik,@hour,@countStaff)",
                    Id, Sborn, Hour, Personal);
                return View(budget);
            
        }
        // GET: Конференция/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Конференция конференция = db.Конференция.Find(id);
            if (конференция == null)
            {
                return HttpNotFound();
            }
            return View(конференция);
        }

        // GET: Конференция/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Конференция/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_конференции,Название_конференции,Основная_тема,Дата_проведения_Начало,Дата_проведения_Конец,Организация,Город,Аудитория,Рабочий_язык_конференции,Ссылка_на_сайт")] Конференция конференция)
        {
            if (ModelState.IsValid)
            {
                db.Конференция.Add(конференция);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(конференция);
        }

        // GET: Конференция/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Конференция конференция = db.Конференция.Find(id);
            if (конференция == null)
            {
                return HttpNotFound();
            }
            return View(конференция);
        }

        // POST: Конференция/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_конференции,Название_конференции,Основная_тема,Дата_проведения_Начало,Дата_проведения_Конец,Организация,Город,Аудитория,Рабочий_язык_конференции,Ссылка_на_сайт")] Конференция конференция)
        {
            if (ModelState.IsValid)
            {
                db.Entry(конференция).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(конференция);
        }

        // GET: Конференция/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Конференция конференция = db.Конференция.Find(id);
            if (конференция == null)
            {
                return HttpNotFound();
            }
            return View(конференция);
        }

        // POST: Конференция/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Конференция конференция = db.Конференция.Find(id);
            db.Конференция.Remove(конференция);
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
