/*
Names: Sam Gines, Michael Niemann, Taylor Bakow, Hunter Riches
Description: Mission FAQs with questions and answers
*/
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
        public ActionResult SelectMission()
        {

            return View("SelectMission", db.Mission.ToList());
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
        public ActionResult SignUp([Bind(Include = "UserID,UserEmail,Password,FirstName,LastName")] Users users, bool rememberMe = false)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(users);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(users.UserEmail, rememberMe);
                return RedirectToAction("Index", "Home", new { userlogin = users.UserEmail });
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