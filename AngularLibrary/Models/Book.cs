namespace AngularLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string BookTitle { get; set; }

        [StringLength(50)]
        public string BookAuthor { get; set; }

        public int? BookPages { get; set; }
    }
}
