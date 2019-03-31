using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class IDataBooks : IMockBooks
    {
        //db connection
        private LibraryView db = new LibraryView();

        public IQueryable<Book> Books { get { return db.Books; } }

        public void Delete(Book book)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public void Dispose()
        {
           db.Dispose();
        }

        public Book Save(Book book)
        {
            if(book.Book_id==0)
            {
                db.Books.Add(book);
            }
            else
            {
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return book;
        }
    }
}