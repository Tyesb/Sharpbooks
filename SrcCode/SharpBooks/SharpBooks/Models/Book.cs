using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpBooks.Models
{
    public class Book
    {
   
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public virtual BookCache Cache { get; set; }
        public string ImgURI { get; set; }
    }
}