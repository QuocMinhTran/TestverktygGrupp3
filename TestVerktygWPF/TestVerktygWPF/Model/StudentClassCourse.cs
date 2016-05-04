using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class StudentClassCourse //Done
    {
        public int ID { get; set; }

        [ForeignKey("StudentClassRefID")]
        public StudentClass StudentClassFK { get; set; }
        public int StudentClassRefID { get; set; }

        [ForeignKey("CouseRefID")]
        public Course CourseFK { get; set; }
        public int CouseRefID { get; set; }


    }
}
