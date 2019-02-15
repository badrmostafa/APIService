using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookConsumer.Models;
using System.Net.Http;

namespace BookConsumer.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            HttpResponseMessage Response = client.GetAsync("api/books").Result;
            var books = Response.Content.ReadAsAsync<IEnumerable<Book>>().Result;
            return View(books);
        }
        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            HttpResponseMessage Response = client.PostAsJsonAsync("api/books",book).Result;
            return RedirectToAction("Index");
        }
        //Details
        public ActionResult Details(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/books/" + id;
            HttpResponseMessage Response = client.GetAsync(Url).Result;
            var book = Response.Content.ReadAsAsync<Book>().Result;
            return View(book);
        }
        //Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/books/" + id;
            HttpResponseMessage Response = client.GetAsync(Url).Result;
            var book = Response.Content.ReadAsAsync<Book>().Result;
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            HttpResponseMessage Response = client.PutAsJsonAsync("api/books", book).Result;
            return RedirectToAction("Index");
        }
        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/books/" + id;
            HttpResponseMessage Response = client.GetAsync(Url).Result;
            var book = Response.Content.ReadAsAsync<Book>().Result;
            return View(book);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/books/" + id;
            HttpResponseMessage Response = client.DeleteAsync(Url).Result;
            return RedirectToAction("Index");
        }
    }
}