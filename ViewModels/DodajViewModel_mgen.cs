using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_API8.Models;

namespace web_API8.ViewModels
{
    public class DodajViewModel_mgen
    {
        //static public string tekst = "Dodano studenta ";
        //public Student jeden_student;
        public string StudentId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public DodajViewModel_mgen (string studentid_in, string firstname_in, string lastname_in, string department_in)
        {
            StudentId = studentid_in;

            FirstName = firstname_in;

            LastName = lastname_in;

            Department = department_in; 
        }
    }
}
