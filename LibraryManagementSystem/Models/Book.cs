namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Book_Register = new HashSet<Book_Register>();
        }

        [Key]
        public int Book_id { get; set; }

        [StringLength(50)]
        public string Book_name { get; set; }

        public int? Category_id { get; set; }

        [StringLength(50)]
        public string Book_author { get; set; }

        [Column(TypeName = "money")]
        public decimal? Book_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book_Register> Book_Register { get; set; }

        public virtual Books_Category Books_Category { get; set; }
    }
}
