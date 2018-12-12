using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    //this is the mission controller, where we show the different missions. 
    public class MissionsController : Controller
    {
        string mission = "";
        // GET: Mission
        public ActionResult Index()
        {
            return View("MissionFAQs");
        }


        public ActionResult Cambodia()
        {
            ViewBag.missionName = "Cambodia";
            ViewBag.missionPresident = "President Christianson";
            ViewBag.address = "House 2B off road Noban";
            ViewBag.language = "Khmer";
            ViewBag.climate = "hot & SWEATY";
            ViewBag.dominantReligion = "Bhuddist";

            return View("MissionFAQs");
        }
        public ActionResult California()
        {
            ViewBag.missionName = "Santa Rosa, Califonia";
            ViewBag.missionPresident = "President Wright";
            ViewBag.address = "7254 Calistoga Road, Santa Rosa California 95401";
            ViewBag.language = "English";
            ViewBag.climate = "Beautiful";
            ViewBag.dominantReligion = "Christian";
            return View("MissionFAQs");
        }
        public ActionResult Chile()
        {
            ViewBag.missionName = "Chile Antofagasta";
            ViewBag.missionPresident = "President Dalton";
            ViewBag.address = "Antafogasta 7 Apt 12";
            ViewBag.language = "Spanish";
            ViewBag.climate = "Hot and dry";
            ViewBag.dominantReligion = "Catholic";
            return View("MissionFAQs");
        }

        public ActionResult Reply()
        {
            ViewBag.replyForm = "<form><div class='form-group'><textarea class='form-control' name='message' placeholder='Answer..'></textarea></div><input type='submit' value='Submit' class='btn btn-primary'</form>";
            return View("MissionFAQs");
        }
    }
}