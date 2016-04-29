using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class StudentTest //Done
    {
        public int ID { get; set; }

        [ForeignKey("StudentRefFk")]
        public Student StudentFk { get; set; }
        public int StudentRefFk { get; set; }


        [ForeignKey("TestRefFk")]
        public Test TestFk { get; set; }
        public int TestRefFk { get; set; }

    }
}
