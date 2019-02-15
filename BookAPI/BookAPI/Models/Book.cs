using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPI.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        //NavigationProperty
        public Category Category { get; set; }
    }

   
}