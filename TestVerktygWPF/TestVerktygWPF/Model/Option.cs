using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class Option //Done
    {
        public int OptionID { get; set; }
        public string SelectivOption { get; set; }
        public bool RightAnswer { get; set; }
        //[ForeignKey("QuestionRefFK")]
        //public Questions QuestionID { get; set; }
        public int QuestionRefFK { get; set; }
    }
}
