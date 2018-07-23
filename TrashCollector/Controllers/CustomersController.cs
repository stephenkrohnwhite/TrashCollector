using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private double charge = 10;

        // GET: Customers
        public ActionResult Index(string option)
        {
            //DateTime dt = DateTime.Now;
             var customers = db.Customers.Include(c => c.Address);
            if(option == null)
            {
                return View(customers.ToList());
            }
            else if(option != null)
            {
     
                
                    string thisUserID = User.Identity.GetUserId();
                    var currentEmployee = db.Employees.Where(c => c.UserID == thisUserID).First();
                    return View(customers.Where(c => c.Address.ZipCode == currentEmployee.Zipcode).Where(c => c.PickUpDay.Day == option).ToList());
                }
                
            
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            var days = db.Days.ToList();
            Customer customer = new Customer()
            {
                DaysOfWeek = days
        };
            //ViewBag.DayID = new SelectList(db.Days, "DayID", "Day");
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,UserName,FirstName,LastName,Phone,Email,Password,PickUpDay,ExtraPickUp,AccountBalance, Address, UserAddressKey, DayID, ExtraPickUp")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                db.UserAddresses.Add(customer.Address);
                db.SaveChanges();
                var tableAddress = db.UserAddresses.Where(c => c.AddressLine == customer.Address.AddressLine).First();
                customer.UserAddressKey = tableAddress.UserAddressID;
                var customerDayJunction = db.Days.Where(c => c.DayID == customer.DayID).First();
                customer.PickUpDay = customerDayJunction;
                //if (customer.ExtraDayID != null)
                //{
                //    customerDayJunction = db.Days.Where(c => c.DayID == customer.ExtraDayID).First();
                //}
                db.Customers.Add(customer);
                db.SaveChanges();
                customer.UserID = currentUserId;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserAddressKey = new SelectList(db.UserAddresses, "UserAddressID", "AddressLine", customer.UserAddressKey);
            return View(customer);
        }

        private List<DateTime?> MapPickUpList(Days pickUpDay, DateTime? extraPickUp)
        {
            DateTime dt = DateTime.Now;
            DateTime end = DateTime.Now.AddDays(21);
            List<DateTime?> mappedDates = new List<DateTime?>();
            List<DateTime> nextThreeWeeks = DateTimeHandler.GetDatesBetween(dt, end);
            for(int i = 0; i < nextThreeWeeks.Count; i++)
            {
                if(nextThreeWeeks[i].DayOfWeek.ToString() == pickUpDay.Day)
                {
                    mappedDates.Add(nextThreeWeeks[i]);
                }
            }
            if(extraPickUp != null)
            {
                mappedDates.Add(extraPickUp);
            }
            return mappedDates;
            
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            var days = db.Days.ToList();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            customer = db.Customers.Include(c => c.Address).Where(c => c.UserID == customer.UserID).First();
            customer.DaysOfWeek = days;
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserAddressKey = new SelectList(db.UserAddresses, "UserAddressID", "AddressLine", customer.UserAddressKey);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID, FirstName,LastName,UserAddressKey,PickUpDay,ExtraPickUp,AccountBalance,ConfirmedPickUp, DayID, ExtraPickUp")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer existingCustomer = db.Customers.Where(c => c.UserID == customer.UserID).First();
                var customerDayJunction = db.Days.Where(c => c.DayID == customer.DayID).First();
                existingCustomer.PickUpDay = customerDayJunction;
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.ExtraPickUp = customer.ExtraPickUp;
                existingCustomer.ConfirmedPickUp = customer.ConfirmedPickUp;
                if(existingCustomer.ConfirmedPickUp == true && existingCustomer.AccountBalance == null)
                {
                    existingCustomer.AccountBalance = charge;
                }
                db.Entry(existingCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserAddressKey = new SelectList(db.UserAddresses, "UserAddressID", "AddressLine", customer.UserAddressKey);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
