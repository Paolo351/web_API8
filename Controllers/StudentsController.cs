using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using web_API8.Models;
using web_API8.Services;
using web_API8.ViewModels;

namespace web_API8.Controllers
{
    //[Route("api/[controller]")]
    [Route("api")]
    [ApiController]
    public class StudentsController : Controller
    {


        private readonly StudentService _StudentService;

        public StudentsController(StudentService Studentservice)
        {
            _StudentService = Studentservice;
        }

        [Route("powrot")]
        public IActionResult powrot()
        {

            return Redirect("/");
        }


        //[HttpGet]
        //public ActionResult<List<Student>> Get()
        [Route("students")]
        public IActionResult students()
        {
            var student_list = new List<Student>(_StudentService.Get());

            var viewModel = new StudentsViewModel() 
            {
                Students = student_list
            };
            return View(viewModel);
        }

        [Route("dodaj")]
        public IActionResult dodaj(string imie_wpis, string nazwisko_wpis, string szkola_wpis)
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
                                                { "FirstName", imie_wpis }, 
                                                { "LastName", nazwisko_wpis }, 
                                                { "School", szkola_wpis } 
                                            };


            var client = new MongoClient(MongoDB_College.ConnectionString_College);
            var database = client.GetDatabase(MongoDB_College.bd_College);
            var collec = database.GetCollection<BsonDocument>(MongoDB_College.kolekcja_College);

            collec.InsertOneAsync(document);

            var viewModel = new DodajViewModel_mgen(myObjectId_string, imie_wpis, nazwisko_wpis, szkola_wpis);

            return View(viewModel);
            
        }

        [Route("usun")]
        //[HttpDelete("{id:length(24)}", Name = "studentdel")]
        public IActionResult usun(string numer)
        {
            var client = new MongoClient(MongoDB_College.ConnectionString_College);
            var database = client.GetDatabase(MongoDB_College.bd_College);
            var collec = database.GetCollection<BsonDocument>(MongoDB_College.kolekcja_College);

            var student = _StudentService.Get(numer);
            
            if (student == null)
                return NotFound();
            
            _StudentService.Remove(student.StudentId);

            var viewModel = new UsunViewModel(student);

            return View(viewModel);

        }



        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public ActionResult<Student> Get(string id)
        {
            var student = _StudentService.Get(id);

            if (student == null)
                return NotFound();

            return student;
        }

        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            _StudentService.Create(student);

            return CreatedAtRoute("GetStudent", new { id = student.StudentId.ToString() }, student);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Student studentIn)
        {
            var student = _StudentService.Get(id);

            if (student == null)
                return NotFound();

            _StudentService.Update(id, studentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var student = _StudentService.Get(id);

            if (student == null)
                return NotFound();

            _StudentService.Remove(student.StudentId);

            return NoContent();
        }

    }
}
