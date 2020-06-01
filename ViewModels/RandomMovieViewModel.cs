using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_API8.Models;

namespace web_API8.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
