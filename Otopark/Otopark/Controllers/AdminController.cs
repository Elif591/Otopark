using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Otopark.Models.Model;
using Otopark.Models.DataContext;
using System.Web.Security;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;


namespace Otopark.Controllers
{
    public class AdminController : Controller
    {
        Context db = new Context();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(User users)
        {

            var user = db.Users.FirstOrDefault(m => m.UserName == users.UserName && m.Password == users.Password);
            if (user != null)
            {
                if (user.roll == true)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.roll = "Admin değilsiniz";
                }
            }
            else
            {
                ViewBag.giris = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "Capacty,Paid")] Capatcy capatcy)
        {

            Capatcy capatcy2 = db.Capatcies.FirstOrDefault(m => m.UserId == 1);
            if (ModelState.IsValid)
            {

                capatcy2.Capacty = capatcy.Capacty;
                capatcy2.Paid = capatcy.Paid;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }

           return RedirectToAction("Index", "Admin");
        }



    }
}