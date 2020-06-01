using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_API8.Models;

namespace web_API8.ViewModels
{
    public class DatabaseViewModel
    {
        public List<Database> Databases { get; set; }
    }

    public class AdddatabaseViewModel 
    {
        public ObjectId DatabaseId { get; set; }
        public string Name { get; set; }

        public string Engine { get; set; }

    public AdddatabaseViewModel(ObjectId DatabaseId_in, string name_in, string engine_in)
        {
            DatabaseId = DatabaseId_in;

            Name = name_in;

            Engine = engine_in;

        }
    }

}
