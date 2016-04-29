using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class TestQuestion //Done
    {
        public int ID { get; set; }

        [ForeignKey("TestRefFk")]
        public Test TestFk { get; set; }
        public int TestRefFk { get; set; }


        [ForeignKey("QuestionRefFk")]
        public Occupation QuestionFk { get; set; }
        public int QuestionRefFk { get; set; }

    }
}
