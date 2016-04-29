using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class GradeClass //Done
    {
        public int ID { get; set; }

        public int GradeClassID { get; set; }
        public List<Student> Studends { get; set; }
        public string Name { get; set; }

    }
}
