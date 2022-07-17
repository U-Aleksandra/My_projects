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
    public class СпонсорыController : Controller
    {
        private Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();

        // GET: Спонсоры
        //фильтрация данных
        public ActionResult Index(string sponPaket, string moneySum)
        {
            var спонсоры = db.Спонсоры.Include(с => с.Конференция);
            if(sponPaket == "Бронзовый спонсор")
            {
                спонсоры = спонсоры.Where(c => c.Спонсорский_пакет == "Бронзовый спонсор");
            }
            if(sponPaket == "Серебряный спонсор")
            {
                спонсоры = спонсоры.Where(c => c.Спонсорский_пакет == "Серебряный спонсор");
            }
            if(sponPaket == "Золотой спонсор")
            {
                спонсоры = спонсоры.Where(c => c.Спонсорский_пакет == "Золотой спонсор");
            }
            if(!String.IsNullOrEmpty(moneySum))
            {
                decimal money = decimal.Parse(moneySum);
                спонсоры = спонсоры.Where(c => c.Сумма > money);
            }
            return View(спонсоры.ToList());
        }

        // GET: Спонсоры/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спонсоры спонсоры = db.Спонсоры.Find(id);
            if (спонсоры == null)
            {
                return HttpNotFound();
            }
            return View(спонсоры);
        }

        // GET: Спонсоры/Create
        public ActionResult Create()
        {
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции");
            return View();
        }

        // POST: Спонсоры/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_спонсора,Название_компании,Представитель,Спонсорский_пакет,Сумма,ID_конференции")] Спонсоры спонсоры)
        {
            if (ModelState.IsValid)
            {
                db.Спонсоры.Add(спонсоры);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", спонсоры.ID_конференции);
            return View(спонсоры);
        }

        // GET: Спонсоры/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спонсоры спонсоры = db.Спонсоры.Find(id);
            if (спонсоры == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", спонсоры.ID_конференции);
            return View(спонсоры);
        }

        // POST: Спонсоры/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_спонсора,Название_компании,Представитель,Спонсорский_пакет,Сумма,ID_конференции")] Спонсоры спонсоры)
        {
            if (ModelState.IsValid)
            {
                db.Entry(спонсоры).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_конференции = new SelectList(db.Конференция, "ID_конференции", "Название_конференции", спонсоры.ID_конференции);
            return View(спонсоры);
        }

        // GET: Спонсоры/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спонсоры спонсоры = db.Спонсоры.Find(id);
            if (спонсоры == null)
            {
                return HttpNotFound();
            }
            return View(спонсоры);
        }

        // POST: Спонсоры/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Спонсоры спонсоры = db.Спонсоры.Find(id);
            db.Спонсоры.Remove(спонсоры);
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
