using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class StudentTest //Ta bort
    {
        public int ID { get; set; }
        public int Score { get; set; }
        public bool IsTestDone { get; set; }
        public int WritenTime { get; set; }

        [ForeignKey("StudentRefFk")]
        public Student StudentFk { get; set; }
        public int StudentRefFk { get; set; }


        [ForeignKey("TestRefFk")]
        public Test TestFk { get; set; }
        public int TestRefFk { get; set; }

    }
}
