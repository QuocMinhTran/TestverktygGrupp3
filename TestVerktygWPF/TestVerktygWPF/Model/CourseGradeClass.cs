using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class CourseGradeClass //Done
    {
        public int ID { get; set; }

        [ForeignKey("GradeClassRefID")]
        public GradeClass GradeClassFK { get; set; }
        public int GradeClassRefID { get; set; }

        [ForeignKey("CouseRefID")]
        public Course CourseFK { get; set; }
        public int CouseRefID { get; set; }


    }
}
