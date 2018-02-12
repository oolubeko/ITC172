using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC2018.Models;

namespace CommunityAssistMVC2018.Controllers
{
    public class NewDonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: NewDonation
        public ActionResult Index()
        {
            if(Session["ReviewerKey"] == null)
            {
                Message m = new Message();
                m.MessageText = "You must be logged in to make a donation.";
                return RedirectToAction("Result", m);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "DonationAmount")] NewDonation nd)
        {
            //Create a new row in donation table and set value of donation amount equal to new donation

            int rKey = (int)Session["ReviewerKey"];

            Donation d = new Donation();
            d.DonationAmount = nd.DonationAmount;
            d.DonationDate = DateTime.Now;
            d.PersonKey = rKey;
            d.DonationConfirmationCode = Guid.NewGuid();

            db.Donations.Add(d);
            db.SaveChanges();

            Message m = new Message();
            m.MessageText = "Thank You for your Donation!";

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}