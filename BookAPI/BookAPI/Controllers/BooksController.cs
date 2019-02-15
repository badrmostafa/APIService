using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookAPI.Models;
using System.Data.Entity;


namespace BookAPI.Controllers
{
    public class BooksController : ApiController
    {
        private BookContext db = new BookContext();
        //get all books
        public IEnumerable<Book> Getbooks()
        {
            return db.Books;
        }
        //get book
        public Book Getbook(int id)
        {
            Book book = db.Books.Find(id);
            return book;
        }
        //Post book
        public HttpResponseMessage Postbook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode.Created);
                return Response;
            }
            else
            {
                HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode.Conflict);
                return Response;
            }
        }
        //put book
        public HttpResponseMessage Putbook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode.OK);
            return Response;
        }
        //delete book
        public HttpResponseMessage Deletebook(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode.OK);
            return Response;
        }
    }
}
