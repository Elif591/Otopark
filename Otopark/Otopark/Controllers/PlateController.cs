using System;
using Otopark.Models.DataContext;
using Otopark.Models.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections;

namespace Otopark.Controllers
{
    public class PlateController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "PlateName")] Plate plate)
        {
            User uye = new User();
            uye = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            plate.UserId = uye.UserId;
            Capatcy capatcy = db.Capatcies.FirstOrDefault(m => m.UserId == 1);
            if (ModelState.IsValid && capatcy.Capacty > db.Plates.Count())
            {
                plate.Login = DateTime.Now;
                db.Plates.Add(plate);
                db.SaveChanges();
                return RedirectToAction("Plates", "Plate");
            }
            else
            {

                ViewBag.uyari = "Kapasite dolu";
            }

            return View();
        }

        public ActionResult Plates()
        {
            List<Plate> plates = db.Plates.Where(m => m.user.UserName == User.Identity.Name).ToList();

            return View(plates);
        }

        public ActionResult Logout(int id)
        {
            Plate plate = db.Plates.FirstOrDefault(m => m.Plateid == id);
            Capatcy capatcy = db.Capatcies.FirstOrDefault(m => m.UserId == 1);
            if (plate != null && plate.Logout == null)
            {
                plate.Logout = DateTime.Now;
                db.SaveChanges();

                if (plate.Logout != null)
                {
                    TimeSpan hour = (TimeSpan)(plate.Logout - plate.Login);

                    if (hour.TotalHours < 1)
                    {
                        plate.Price = capatcy.Paid;
                    }
                    else
                    {
                        plate.Price = (float?)((hour.TotalHours) * capatcy.Paid);
                    }


                    db.SaveChanges();
                }
                return RedirectToAction("Plates");
            }
            return RedirectToAction("Plates");

        }

        public ActionResult AdminPlates()
        {

            //List<Plate> plates = db.Plates.OrderBy(m => m.PlateName).ToList();
            List<ResultLine> result = db.Plates.ToList()
                .GroupBy(l => l.PlateName)
                .Select(cl => new ResultLine
                {
                    PlateName = cl.First().PlateName,
                    Quantity = cl.Count().ToString(),
                    Price = cl.Sum(c => c.Price).ToString(),
                }).ToList();

            return View(result);
        }

        public ActionResult PlakaSirala()
        {
            List<ResultLine> result = db.Plates.ToList()
                     .GroupBy(l => l.PlateName)
                     .Select(cl => new ResultLine
                      {
                      PlateName = cl.First().PlateName,
                      Quantity = cl.Count().ToString(),
                      Price = cl.Sum(c => c.Price).ToString(),
                      }).ToList();

            result = result.OrderByDescending(l => l.Price).ToList();
            return View(result);
        }
    }



    public class Product
    {

        public Product() { }

        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }

    public class ResultLine
    {

        public ResultLine() { }

        public string PlateName { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }
}