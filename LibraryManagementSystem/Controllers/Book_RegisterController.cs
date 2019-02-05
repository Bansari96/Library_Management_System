using System;
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
    public class Book_RegisterController : Controller
    {
        private LibraryView db = new LibraryView();

        // GET: Book_Register
        public ActionResult Index()
        {
            var book_Register = db.Book_Register.Include(b => b.Book);
            return View(book_Register.ToList());
        }

        // GET: Book_Register/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Register book_Register = db.Book_Register.Find(id);
            if (book_Register == null)
            {
                return HttpNotFound();
            }
            return View(book_Register);
        }

        // GET: Book_Register/Create
        public ActionResult Create()
        {
            ViewBag.Book_id = new SelectList(db.Books, "Book_id", "Book_name");
            return View();
        }

        // POST: Book_Register/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_borrow_id,Book_id,Issued_date,Due_date,Returned_date,Fine_amount")] Book_Register book_Register)
        {
            if (ModelState.IsValid)
            {
                db.Book_Register.Add(book_Register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_id = new SelectList(db.Books, "Book_id", "Book_name", book_Register.Book_id);
            return View(book_Register);
        }

        // GET: Book_Register/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Register book_Register = db.Book_Register.Find(id);
            if (book_Register == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_id = new SelectList(db.Books, "Book_id", "Book_name", book_Register.Book_id);
            return View(book_Register);
        }

        // POST: Book_Register/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_borrow_id,Book_id,Issued_date,Due_date,Returned_date,Fine_amount")] Book_Register book_Register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_id = new SelectList(db.Books, "Book_id", "Book_name", book_Register.Book_id);
            return View(book_Register);
        }

        // GET: Book_Register/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Register book_Register = db.Book_Register.Find(id);
            if (book_Register == null)
            {
                return HttpNotFound();
            }
            return View(book_Register);
        }

        // POST: Book_Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Register book_Register = db.Book_Register.Find(id);
            db.Book_Register.Remove(book_Register);
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
