using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SharpBooks.Models;
using Microsoft.AspNet.Identity;

namespace SharpBooks.Controllers
{
    public class BookShelfController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BookShelf
        public IQueryable<BookshelfItem> GetBookShelfItems()
        {
            string currentUserID = User.Identity.GetUserId();
            return db.BookShelfItems.Where(a => currentUserID == a.User.Id);
        }

        //// GET: api/BookShelf/5
        //[ResponseType(typeof(BookshelfItem))]
        //public IHttpActionResult GetBookshelfItem(int id)
        //{
        //    BookshelfItem bookshelfItem = db.BookShelfItems.Find(id);
        //    if (bookshelfItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(bookshelfItem);
        //}

        //// PUT: api/BookShelf/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBookshelfItem(int id, BookshelfItem bookshelfItem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != bookshelfItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(bookshelfItem).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookshelfItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/BookShelf
        [ResponseType(typeof(BookshelfItem))]
        public IHttpActionResult PostBookshelfItem(BookshelfItem bookshelfItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userID = User.Identity.GetUserId();
            string currentUserID = User.Identity.GetUserId();
            ApplicationUser userFound = db.Users.Find(currentUserID);

            bookshelfItem.User = userFound;
            db.BookShelfItems.Add(bookshelfItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bookshelfItem.Id }, bookshelfItem);
        }

        // DELETE: api/BookShelf/5
        [ResponseType(typeof(BookshelfItem))]
        public IHttpActionResult DeleteBookshelfItem(int id)
        {
            var userID = User.Identity.GetUserId();
            string currentUserID = User.Identity.GetUserId();


            BookshelfItem bookshelfItem = db.BookShelfItems.Find(id);
            if (bookshelfItem == null)
            {
                return NotFound();
            }

            if (currentUserID == bookshelfItem.User.Id)
            {
                db.BookShelfItems.Remove(bookshelfItem);
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(bookshelfItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookshelfItemExists(int id)
        {
            return db.BookShelfItems.Count(e => e.Id == id) > 0;
        }
    }
}