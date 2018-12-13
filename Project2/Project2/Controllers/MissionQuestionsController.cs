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
    public class MissionQuestionsController : Controller
    {
        private MissionContext db = new MissionContext();

        // GET: MissionQuestions
        public ActionResult Index()
        {
            var missionQuestion = db.MissionQuestion.Include(m => m.Mission).Include(m => m.User);
            return View(missionQuestion.ToList());
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.MissionQuestion.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Create
        public ActionResult Create(int? id)
        {
            ViewBag.thisMissionID = id;
            ViewBag.MissionID = new SelectList(db.Mission, "MissionID", "MissionName");
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserEmail");
            return View();
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MissionQuestionID,MissionID,UserID,Question,Answer")] MissionQuestions missionQuestions, int? id)
        {          
            if (ModelState.IsValid)
            {
                missionQuestions.MissionID = id;
                db.MissionQuestion.Add(missionQuestions);
                db.SaveChanges();
                return RedirectToAction("FAQ", "Missions", id);
            }

            ViewBag.MissionID = new SelectList(db.Mission, "MissionID", "MissionName", missionQuestions.MissionID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserEmail", missionQuestions.UserID);
            return View(missionQuestions);
        }


        public ActionResult Reply(int? id)
        {
            ViewBag.thisMissionID = id;
            ViewBag.MissionID = new SelectList(db.Mission, "MissionID", "MissionName");
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserEmail");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply([Bind(Include = "MissionQuestionID,MissionID,UserID,Question,Answer")] MissionQuestions missionQuestions, int id)
        {
            if (ModelState.IsValid)
            {
                missionQuestions.MissionQuestionID = id;
                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("getID", "Missions", null);
            }
            ViewBag.MissionID = new SelectList(db.Mission, "MissionID", "MissionName", missionQuestions.MissionID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserEmail", missionQuestions.UserID);
            return View(missionQuestions);
        }

        //// GET: MissionQuestions/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MissionQuestions missionQuestions = db.MissionQuestion.Find(id);
        //    if (missionQuestions == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.MissionID = new SelectList(db.Mission, "MissionID", "MissionName", missionQuestions.MissionID);
        //    ViewBag.UserID = new SelectList(db.User, "UserID", "UserEmail", missionQuestions.UserID);
        //    return View(missionQuestions);
        //}

        //// POST: MissionQuestions/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MissionQuestionID,MissionID,UserID,Question,Answer")] MissionQuestions missionQuestions)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(missionQuestions).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MissionID = new SelectList(db.Mission, "MissionID", "MissionName", missionQuestions.MissionID);
        //    ViewBag.UserID = new SelectList(db.User, "UserID", "UserEmail", missionQuestions.UserID);
        //    return View(missionQuestions);
        //}

        //// GET: MissionQuestions/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MissionQuestions missionQuestions = db.MissionQuestion.Find(id);
        //    if (missionQuestions == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(missionQuestions);
        //}

        //// POST: MissionQuestions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    MissionQuestions missionQuestions = db.MissionQuestion.Find(id);
        //    db.MissionQuestion.Remove(missionQuestions);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
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
