using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpBooks.Models
{
    public class BookCacheModel
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}