using Project2.DAL;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private MissionContext db = new MissionContext();
        public static int userRole = 0;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mission()
        {
            return View("Mission");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult SignUp([Bind(Include = "UserID,UserEmail,Password,FirstName,LastName")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(users);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(users);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password, bool rememberMe = false)
        {
            var currentUser = db.Database.SqlQuery<Users>(
            "Select * " +
            "FROM Users " +
            "WHERE UserEmail = '" + Username + "' AND " +
            "Password = '" + Password + "'");
            if (currentUser.Count() > 0)
            {
                if (Username == "sam.gines.104@gmail.com")
                {
                    userRole = 9001;
                }
                else
                {
                    userRole = 1;
                }
                FormsAuthentication.SetAuthCookie(Username, rememberMe);
                return RedirectToAction("Index", "Home", new { userlogin = Username });
            }
            else
            {
                return View();
            }
        }
    }
}