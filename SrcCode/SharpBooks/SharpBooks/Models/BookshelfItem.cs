using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SharpBooks.Models
{
    public class BookshelfItem
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        // public string UserID { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
    }
}