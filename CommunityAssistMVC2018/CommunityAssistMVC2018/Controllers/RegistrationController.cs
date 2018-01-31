using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;

namespace CommunityAssistMVC2018.Controllers
{
    public class RegistrationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Registration
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "LastName, FirstName, Email, Password, Apartment, Street, City, State, Zipcode, Phone")]NewPerson person)
        {
            int result = db.usp_Register(person.LastName, person.FirstName, person.Email, person.PlainPassword, person.Apartment, person.Street, person.City, person.State, person.Zipcode, person.Phone);
            Message m = new Message();
            if(result != -1)
            {
                m.MessageText = "Thanks for registering.";
                return RedirectToAction("Result",m);
            }
            m.MessageText = "Sorry, but something seems to have gone wrong with registration.";
            return RedirectToAction("Result",m);
        }

    }
}