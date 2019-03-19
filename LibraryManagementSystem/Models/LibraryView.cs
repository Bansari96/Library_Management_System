namespace LibraryManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryView : DbContext
    {
        public LibraryView()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Book_Register> Book_Register { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Books_Category> Books_Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Register>()
                .Property(e => e.Fine_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Book>()
                .Property(e => e.Book_price)
                .HasPrecision(19, 4);
        }
    }
}
