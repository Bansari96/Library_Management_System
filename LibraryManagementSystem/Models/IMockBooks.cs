using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public interface IMockBooks
    {
        IQueryable<Book> Books { get; }
        IQueryable<Books_Category> Books_Category { get; }
        Book Save(Book book);
        void Delete(Book book);
        void Dispose();
    }
}
