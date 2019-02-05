﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class Books_CategoryController : Controller
    {
        private LibraryView db = new LibraryView();

        // GET: Books_Category
        public ActionResult Index()
        {
            return View(db.Books_Category.ToList());
        }

        // GET: Books_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Category books_Category = db.Books_Category.Find(id);
            if (books_Category == null)
            {
                return HttpNotFound();
            }
            return View(books_Category);
        }

        // GET: Books_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_id,Category_name")] Books_Category books_Category)
        {
            if (ModelState.IsValid)
            {
                db.Books_Category.Add(books_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books_Category);
        }

        // GET: Books_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Category books_Category = db.Books_Category.Find(id);
            if (books_Category == null)
            {
                return HttpNotFound();
            }
            return View(books_Category);
        }

        // POST: Books_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_id,Category_name")] Books_Category books_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books_Category);
        }

        // GET: Books_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Category books_Category = db.Books_Category.Find(id);
            if (books_Category == null)
            {
                return HttpNotFound();
            }
            return View(books_Category);
        }

        // POST: Books_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books_Category books_Category = db.Books_Category.Find(id);
            db.Books_Category.Remove(books_Category);
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
