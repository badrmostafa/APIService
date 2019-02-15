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
    public class CategoriesController : ApiController
    {
        private BookContext db = new BookContext();
        //get all categories
        public IEnumerable<Category> Getcategories()
        {
            return db.Categories;
        }
        //get category
        public Category Getcategory(int id)
        {
            Category category = db.Categories.Find(id);
            return category;
        }
        //post category
        public HttpResponseMessage Postcategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
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
        //put category
        public HttpResponseMessage Putcategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode.OK);
            return Response;
        }
        //delete category
        public HttpResponseMessage Deletecategory(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            HttpResponseMessage Response = Request.CreateResponse(HttpStatusCode.OK);
            return Response;
        }
    }
}
