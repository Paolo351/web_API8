using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_API8.Models;

namespace web_API8.ViewModels
{
    public class UsunViewModel
    {
        public Student pojedynczy_student;

        public UsunViewModel(Student student)
        {
            this.pojedynczy_student = student;
        }
    }
}
