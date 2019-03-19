namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Book_id { get; set; }

        [StringLength(50)]
        public string Book_name { get; set; }

        public int? Category_id { get; set; }

        [StringLength(50)]
        public string Book_author { get; set; }

        [Column(TypeName = "money")]
        public decimal? Book_price { get; set; }
    }
}
