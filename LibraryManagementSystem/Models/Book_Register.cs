namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book_Register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Book_borrow_id { get; set; }

        public int? Book_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Issued_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Due_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Returned_date { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fine_amount { get; set; }

        public virtual Book Book { get; set; }
    }
}
