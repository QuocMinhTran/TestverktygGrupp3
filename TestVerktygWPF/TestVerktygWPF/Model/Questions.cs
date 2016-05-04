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
        public int ID { get; set; }
        public string Name { get; set; } //Frågan
        public string QuestionType { get; set; }
        public string AppData { get; set; }
      

        [ForeignKey("TestFk")]
        public Test Test { get; set; }
        public int TestFk { get; set; }

        //public Questions()
        //{
        //    Options = new List<Option>();

        //}
           
    }
}
