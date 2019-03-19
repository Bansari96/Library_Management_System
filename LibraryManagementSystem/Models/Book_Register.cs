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
        public int Book_borrow_id { get; set; }

        [Display(Name ="BookName")]
        public int? Book_id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? Issued_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? Due_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? Returned_date { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.01, 100000)]
        [Column(TypeName = "money")]
        public decimal? Fine_amount { get; set; }

        public virtual Book Book { get; set; }
    }
}
