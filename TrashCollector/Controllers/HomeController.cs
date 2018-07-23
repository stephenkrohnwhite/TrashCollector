using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if(User.IsInRole("Employee"))
            {
                string currentID = User.Identity.GetUserId();
                string today = DateTime.Now.DayOfWeek.ToString();
                DateTime todaysDate = DateTime.Now;
                var employee = db.Employees.Where(c => c.UserID == currentID).First();
                
                var customerWeeklyPickups = db.Customers.Include("Address").Where(c => c.Address.ZipCode == employee.Zipcode)
                    .Where(c => c.PickUpDay.Day == today);
                var extraPickUps = db.Customers.Where(c => c.Address.ZipCode == employee.Zipcode).Where(c => ((DateTime)c.ExtraPickUp) == todaysDate);
                var pickups = customerWeeklyPickups.ToList();
                var extraPickUpsList = extraPickUps.ToList();
                foreach (var person in extraPickUpsList)
                {
                    pickups.Add(person);
                }

                return View(pickups);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}