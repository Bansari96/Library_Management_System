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
    [Authorize]
    public class BooksController : Controller
    {
        //private LibraryView db = new LibraryView();

        IMockBooks db;

        //default constructor
        public BooksController()
        {
            this.db = new IDataBooks();
        }

        public BooksController(IMockBooks mockDb)
        {
            this.db = mockDb;
        }

        [AllowAnonymous]
        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Books_Category);
            return View("Index",books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Book book = db.Books.Find(id);
            Book book = db.Books.SingleOrDefault(b => b.Book_id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("Details",book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
           ViewBag.Category_id = new SelectList(db.Books_Category, "Category_id", "Category_name");
           return View("Create");
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_id,Book_name,Category_id,Book_author,Book_price")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Books.Add(book);
                //db.SaveChanges();
                db.Save(book);
                return RedirectToAction("Index");
            }

            ViewBag.Category_id = new SelectList(db.Books_Category, "Category_id", "Category_name", book.Category_id);
            return View("Create",book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Book book = db.Books.Find(id);
            Book book = db.Books.SingleOrDefault(b => b.Book_id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
           ViewBag.Category_id = new SelectList(db.Books_Category, "Category_id", "Category_name", book.Category_id);
           return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_id,Book_name,Category_id,Book_author,Book_price")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(book).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_id = new SelectList(db.Books_Category, "Category_id", "Category_name", book.Category_id);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Book book = db.Books.Find(id);
            Book book = db.Books.SingleOrDefault(b => b.Book_id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("Delete",book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Book book = db.Books.Find(id);
            Book book = db.Books.SingleOrDefault(b => b.Book_id == id);
            //db.Books.Remove(book);
            //db.SaveChanges();
            db.Delete(book);
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
