using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;

namespace CommunityAssistMVC2018.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName, PassWord")]LoginClass lc)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            int loginResult = db.usp_Login(lc.UserName, lc.PassWord);

            if(loginResult != -1)
            {
                var uid = (from r in db.People
                           where r.PersonEmail.Equals(lc.UserName)
                           select r.PersonKey).FirstOrDefault();
                int rKey = (int)uid;
                Session["ReviewerKey"] = rKey;

                Message msg = new Message();
                msg.MessageText = "Thank You, " + lc.UserName + ", for logging in. You can now donate or apply for assistance.";
                return RedirectToAction("Result", msg);
            }

            Message message = new Message();
            message.MessageText = "Failed to login. Please try again or Register";
            return View("Result", message);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}