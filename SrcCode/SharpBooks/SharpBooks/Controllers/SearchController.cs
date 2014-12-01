﻿using System;
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

namespace SharpBooks.Controllers
{
    public class SearchController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Search
        public IQueryable<Book> GetBooks(string search) //Search not implemented yet. To be added later.
        {
            return db.Books;
        }

        // GET: api/Search/5
        //[ResponseType(typeof(Book))]
        //public IHttpActionResult GetBook(int id)
        //{
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(book);
        //}

        // PUT: api/Search/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBook(int id, Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != book.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
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

        //// POST: api/Search
        //[ResponseType(typeof(Book))]
        //public IHttpActionResult PostBook(Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Books.Add(book);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        //}

        //// DELETE: api/Search/5
        //[ResponseType(typeof(Book))]
        //public IHttpActionResult DeleteBook(int id)
        //{
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Books.Remove(book);
        //    db.SaveChanges();

        //    return Ok(book);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}