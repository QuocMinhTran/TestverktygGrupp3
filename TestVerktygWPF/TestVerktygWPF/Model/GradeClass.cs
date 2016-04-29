using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class GradeClass //Done
    {
        
        [Key]
        public int GradeClassID { get; set; }
        public List<Student> Studends { get; set; }
        public string Name { get; set; }

    }
}
