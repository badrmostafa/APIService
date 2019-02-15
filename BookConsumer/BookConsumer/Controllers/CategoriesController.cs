using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookConsumer.Models;
using System.Net.Http;

namespace BookConsumer.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            HttpResponseMessage Response = client.GetAsync("api/categories").Result;
            var categories = Response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            return View(categories);
            
        }
        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            HttpResponseMessage Response = client.PostAsJsonAsync("api/categories", category).Result;
            return RedirectToAction("Index");
        }
        //Details
        public ActionResult Details(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/categories/" + id;
            HttpResponseMessage Response = client.GetAsync(Url).Result;
            var category = Response.Content.ReadAsAsync<Category>().Result;
            return View(category);
        }
        //Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/categories/" + id;
            HttpResponseMessage Response = client.GetAsync(Url).Result;
            var category = Response.Content.ReadAsAsync<Category>().Result;
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            HttpResponseMessage Response = client.PutAsJsonAsync("api/categories", category).Result;
            return RedirectToAction("Index");
        }
        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/categories/" + id;
            HttpResponseMessage Response = client.GetAsync(Url).Result;
            var category = Response.Content.ReadAsAsync<Category>().Result;
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49916/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/Json"));
            var Url = "api/categories/" + id;
            HttpResponseMessage Response = client.DeleteAsync(Url).Result;
            return RedirectToAction("Index");
        }
    }
}