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
    public class СборникController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Сборник
        //фильтрация данных
        public ActionResult Index(string price, Nullable<bool> chekRes, Nullable<bool> Res)
        {
            var сборник = db.Сборник.Include(с => с.Конференция);
            if (!String.IsNullOrEmpty(price))
            {
                decimal Price = decimal.Parse(price);
                сборник = сборник.Where(c => c.Стоимость > Price);
            }
            if(chekRes == true)
            {
                сборник = сборник.Where(c => c.РИНЦ == true);
            }
            if(chekRes == false)
            {
                сборник = сборник.Where(c => c.РИНЦ == false);
            }
            if(Res == true)
            {
                сборник = db.Сборник.Include(с => с.Конференция);
            }
            return View(сборник.ToList());
        }

        //проверка уникального Id конференции
        public class UniqueIdKonfAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();
                var cbornik = db.Сборник.SingleOrDefault(
                    u => u.ID_конференции == (int)value);
                return cbornik == null;
            }
        }

        // GET: Сборник/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сборник сборник = db.Сборник.Find(id);
            if (сборник == null)
            {
                return HttpNotFound();
            }
            return View(сборник);
        }

        // GET: Сборник/Create
        public ActionResult Create()
        {
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции");
            return View();
        }

        // POST: Сборник/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_сборник,ID_конференции,Название_сборника,Издательский_центр,РИНЦ,Стоимость,Количество_страниц,Электронный_или_печатный_вариант,Дата_выпуска,Рассылка_докладчикам")] Сборник сборник)
        {
            if (ModelState.IsValid)
            {
                db.Сборник.Add(сборник);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", сборник.ID_конференции);
            return View(сборник);
        }

        // GET: Сборник/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сборник сборник = db.Сборник.Find(id);
            if (сборник == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", сборник.ID_конференции);
            return View(сборник);
        }

        // POST: Сборник/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_сборник,ID_конференции,Название_сборника,Издательский_центр,РИНЦ,Стоимость,Количество_страниц,Электронный_или_печатный_вариант,Дата_выпуска,Рассылка_докладчикам")] Сборник сборник)
        {
            if (ModelState.IsValid)
            {
                db.Entry(сборник).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", сборник.ID_конференции);
            return View(сборник);
        }

        // GET: Сборник/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сборник сборник = db.Сборник.Find(id);
            if (сборник == null)
            {
                return HttpNotFound();
            }
            return View(сборник);
        }

        // POST: Сборник/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Сборник сборник = db.Сборник.Find(id);
            db.Сборник.Remove(сборник);
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
