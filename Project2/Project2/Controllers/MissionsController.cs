using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2.Controllers
{
    //this is the mission controller, where we show the different missions. 
    [Authorize]
    public class MissionsController : Controller
    {
        string mission = "";
        // GET: Mission

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("MissionFAQs");
        }

        
        public ActionResult FAQ()
        {
            return View();
        }

     
      
     
        public ActionResult Reply()
        {
            ViewBag.replyForm = "<form><div class='form-group'><textarea class='form-control' name='message' placeholder='Answer..'></textarea></div><input type='submit' value='Submit' class='btn btn-primary'</form>";
            return View("MissionFAQs");
        }
    }
}