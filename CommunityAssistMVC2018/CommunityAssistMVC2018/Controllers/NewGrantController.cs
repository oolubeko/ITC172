using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;

namespace CommunityAssistMVC2018.Controllers
{
    public class NewGrantController : Controller
    {
        // GET: NewGrant
        public ActionResult Index()
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            if(Session["ReviewerKey"] == null)
            {
                Message m = new Message();
                m.MessageText = "You must be logged in to request a grant.";
                return RedirectToAction("Result", m);
            }
            ViewBag.GrantTypeKey = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="GrantTypeKey, PersonKey, GrantAppicationDate, GrantApplicationStatusKey, GrantApplicationRequestAmount, GrantApplicationReason")] GrantApplication g)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            g.PersonKey = (int)Session["ReviewerKey"];
            g.GrantApplicationStatusKey = 1;
            g.GrantAppicationDate = DateTime.Now;
            db.GrantApplications.Add(g);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "Your application has been successfully submitted.";
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}