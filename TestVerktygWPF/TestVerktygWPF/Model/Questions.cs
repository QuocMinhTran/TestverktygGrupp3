using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class Questions
    {
        [Key]
        public int QuestionID { get; set; }
        public string QuestionsLabel { get; set; } //Frågan
        public List<Option> Options { get; set; }
        public string AppData { get; set; }

        [ForeignKey("QuestTypeRefFK")]
        public QuestionType QuestionTypeFK { get; set; }
        public int QuestTypeRefFK { get; set; }

        //Frågans typ
        private QuestionType xQuestionType;
        //Svarets id för listan i Test
        private int iAnswerId;

        public Questions()
        {
            Options = new List<Option>();

        }
           
    }
}
