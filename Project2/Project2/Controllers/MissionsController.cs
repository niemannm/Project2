using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project2.DAL;
using Project2.Models;

namespace Project2.Controllers
{
    //this is the mission controller, where we show the different missions. 
    [Authorize]
    public class MissionsController : Controller
    {
        private MissionContext db = new MissionContext();
        public int? thisMissionID;

        // GET: Mission
        [AllowAnonymous]
        public ActionResult Index(int? id)
        {
            thisMissionID = id;
            Missions mission = db.Mission.Find(id);
            return View("MissionFAQs", mission);
        }

        public ActionResult FAQ()
        {
            Missions mission = db.Mission.Find(thisMissionID);
            ViewBag.MissionName = mission.MissionName;
            ViewBag.MissionID = thisMissionID;


            IEnumerable<MissionQuestions> missionQuestion =
                db.Database.SqlQuery<MissionQuestions>(
                "Select MissionQuestions.MissionQuestionID, MissionQuestions.MissionID, MissionQuestions.UserID, " +
                "MissionQuestions.Question, MissionQuestions.Answer " + 
                "FROM MissionQuestions, Missions " + 
                "WHERE MissionQuestions.MissionID = " + thisMissionID + " AND MissionQuestions.MissionID = Missions.MissionID");

            //var missionQuestion = db.MissionQuestion.Include(m => m.Mission).Include(m => m.User);
            return View(missionQuestion);
        }

        public ActionResult getID()
        {
            return RedirectToAction("FAQ", thisMissionID);
        }

        //[HttpPost]
        //public ActionResult FAQ([Bind(Include = "MissionQuestionID,MissionID,UserID,Question,Answer")] MissionQuestions missionQuestions, int? id)
        //{
        //    missionQuestions.MissionID = id;
        //    db.MissionQuestion.Add(missionQuestions);

        //    db.SaveChanges();
        //    return RedirectToAction("FAQ", thisMissionID);
        //}

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