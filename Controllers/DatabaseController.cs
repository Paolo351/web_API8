using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using web_API8.ViewModels;


using web_API8.Models;
using web_API8.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_API8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : Controller
    {

        [Route("adddatabase")]
        public IActionResult adddatabase(string name_wpis, string engine_wpis)
        {
            //var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            int nProcessID = Process.GetCurrentProcess().Id;
            short short_n = Convert.ToInt16(nProcessID);
            var myObjectId = new ObjectId(DateTime.UtcNow, 2, short_n, 1);



            var myObjectId_string = new string(myObjectId.ToString());
            //string myObjectId_string = myObjectId.ToString();

            //var string newObjectId = 5349b4ddd2781d08c09890f4
            //var myObjectId = new ObjectId("5349b4ddd2781d08c09890f4");

            //string myObjectId_string = myObjectId.ToString();

            var document = new BsonDocument {
                                                { "_id", myObjectId },
                                                { "Name", name_wpis },
                                                { "Engine", engine_wpis }
                                            };


            var client = new MongoClient(MongoDB_College.ConnectionString_College);
            var database = client.GetDatabase(MongoDB_College.bd_College);
            var collec = database.GetCollection<BsonDocument>(MongoDB_College.kolekcja_College);

            collec.InsertOneAsync(document);

            var viewModel = new AdddatabaseViewModel(myObjectId, name_wpis, engine_wpis);

            return View(viewModel);

        }

        // GET: api/<DatabaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DatabaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DatabaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DatabaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DatabaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
