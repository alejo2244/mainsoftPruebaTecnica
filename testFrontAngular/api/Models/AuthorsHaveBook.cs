using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class AuthorsHaveBook
    {
        public int AuthorsId { get; set; }
        public Int64? BooksIsbn { get; set; }

        public virtual Author Authors { get; set; }
        public virtual Book BooksIsbnNavigation { get; set; }
    }
}
