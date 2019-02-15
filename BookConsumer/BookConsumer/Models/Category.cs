using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookConsumer.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        //NavigationProperty
        public List<Book> Books { get; set; }
    }
}