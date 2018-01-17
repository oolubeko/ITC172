using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstLook.Models;

namespace FirstLook.Controllers
{
    public class MailingController : Controller
    {
        // GET: Mailing
        public ActionResult Index()
        {
            Mailing m1 = new Mailing();
            m1.FirstName = "Steve";
            m1.LastName = "Conger";
            m1.Email = "steven.conger@seattlecolleges.edu";

            Mailing m2 = new Mailing();
            m2.FirstName = "Normal";
            m2.LastName = "Mailer";
            m2.Email = "norm@gmail.com";

            Mailing m3= new Mailing();
            m3.FirstName = "Sarah";
            m3.LastName = "Jones";
            m3.Email = "sarah@gmail.com";

            List <Mailing> mailings = new List<Mailing>();
            mailings.Add(m1);
            mailings.Add(m2);
            mailings.Add(m3);


            return View(mailings);
        }
    }
}