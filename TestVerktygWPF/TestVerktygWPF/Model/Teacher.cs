using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Password { get; set; }
        public Occupation Occupations { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Email { get; set; }
        //public Test Tests { get; set; }
        public string UserName { get; set; }
        //public Course Courses { get; set; }


    }
}
