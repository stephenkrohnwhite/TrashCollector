﻿using System;
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
    public class UserAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserAddresses
        public ActionResult Index()
        {
            return View(db.UserAddresses.ToList());
        }

        // GET: UserAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return HttpNotFound();
            }
            return View(userAddress);
        }

        // GET: UserAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserAddressID,AddressLine,AddressLineTwo,City,State,ZipCode")] UserAddress userAddress)
        {
            if (ModelState.IsValid)
            {
                db.UserAddresses.Add(userAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAddress);
        }

        // GET: UserAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return HttpNotFound();
            }
            return View(userAddress);
        }

        // POST: UserAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAddressID,AddressLine,AddressLineTwo,City,State,ZipCode")] UserAddress userAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAddress);
        }

        // GET: UserAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return HttpNotFound();
            }
            return View(userAddress);
        }

        // POST: UserAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAddress userAddress = db.UserAddresses.Find(id);
            db.UserAddresses.Remove(userAddress);
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
