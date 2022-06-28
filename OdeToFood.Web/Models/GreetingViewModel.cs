using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Web.Models
{
    public class GreetingViewModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}