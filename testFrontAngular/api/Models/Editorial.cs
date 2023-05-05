using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
