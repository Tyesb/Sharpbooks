using SharpBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBooks.Services
{
    public interface IBookSearch
    {
       Task< IEnumerable<Book> >GeneralSearch(String input);
       Task<IEnumerable<Book>> TitleSearch(String input);
       Task<IEnumerable<Book>> ISBNSearch(String input);
       
       
       
    }
}
