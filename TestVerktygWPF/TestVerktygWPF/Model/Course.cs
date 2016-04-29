using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class Course //Done
    {
        [Key]
        public int CourseID { get; set; }

        public Subjects Subject { get; set; }

        [ForeignKey("TeacherRefFK")]
        public Teacher TeacherFK { get; set; }
        public int TeacherRefFK { get; set; }
    }
}
