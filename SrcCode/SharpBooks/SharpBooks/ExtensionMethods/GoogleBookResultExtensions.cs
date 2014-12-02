using SharpBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpBooks.ExtensionMethods
{
    public static class GoogleBookResultExtensions
    {
        public static IEnumerable<Models.Book> ToBooks(this GoogleBookResult result)
        {

            foreach (GoogleBookItem item in result.items)
            {
                yield return new Book { Title = item.volumeInfo.title, Author = string.Join(", ", item.volumeInfo.authors) };
            }

        }
    }
}