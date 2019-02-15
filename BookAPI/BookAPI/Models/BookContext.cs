using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookAPI.Models;

namespace BookAPI.Models
{
    public class BookContext:DbContext
    {
        public BookContext() : base("BookContext")
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}