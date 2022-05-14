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
    public class UserController : Controller
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
                if (user.roll == false)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Plate");
                }
                else
                {
                    ViewBag.roll = "Admin girişini deneyiniz.";
                }
            }
            else
            {
                ViewBag.giris = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            return View();
        }

    
    }
}