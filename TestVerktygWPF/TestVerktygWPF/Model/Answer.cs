using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class Answer //Done
    {
        public int ID { get; set; }
        public string Text{ get; set; }
        public bool RightAnswer { get; set; }
        public int? OrderPosition { get; set; }

        [ForeignKey("QuestionFk")]
        public Questions Questions { get; set; }
        public int QuestionFk { get; set; }

    }
}
