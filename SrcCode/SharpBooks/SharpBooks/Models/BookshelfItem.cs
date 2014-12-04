using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SharpBooks.Models
{
    public class BookshelfItem
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string ISBN { get; set; }

        public string ImgURI { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
    }
}