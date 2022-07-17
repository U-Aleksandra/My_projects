using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Курсовая.Models;

namespace Курсовая.Controllers
{
    public class HomeController : Controller
    {
        // главная страница
        public ActionResult Index()
        {
            return View();
        }

        // страница с таблицами, доступная только админу
        //[Authorize(Roles = "admin")]
        public ActionResult DateBase()
        {

            return View();
        }

        //страница с общей информацией
        public ActionResult Info()
        {
            return View();
        }

        //страница с функцией, которая определяет победителя
        public ActionResult Winner(int ?idKon, string napr)
        {
            
            Оргкомитет_конференцииEntities db = new Оргкомитет_конференцииEntities();
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@idKonf", 1);
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@napravl", "0000");
            if (idKon != null && !String.IsNullOrEmpty(napr))
            {
                param = new System.Data.SqlClient.SqlParameter("@idKonf", idKon);
                param1 = new System.Data.SqlClient.SqlParameter("@napravl", napr);
            }
                var winner = db.Database.SqlQuery<Winner_Result>("SELECT * FROM Winner (@idKonf,@napravl)", param, param1);
            
            return View(winner);
        }

        //страница, доступная только юзерам
        // [Authorize(Roles = "user")]
        public ActionResult Ychastnikam()
        {
            return View();
        }

        //GET-метод авторизации
        public ActionResult Login()
        {
            return View();
        }

        //POST-метод авторизации
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Users user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        //GET-метод регистрации
        public ActionResult Register()
        {
            return View();
        }

        //POST-метод регистрации
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegister model)
        {
            if (ModelState.IsValid)
            {
                Users user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new Users { Login = model.Login, Password = model.Password, IdRoles = 2});
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }

        //выход из системы
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}