using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Book
    {
        public Int64 Isbn { get; set; }
        public int EditorialId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string NPages { get; set; }

        public virtual Editorial Editorial { get; set; }
    }
}
