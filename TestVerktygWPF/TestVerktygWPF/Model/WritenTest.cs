using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
  public class WritenTest
    {
        [Key]
        public int ID { get; set; }

        public int Score { get; set; }
        public bool IsTestDone { get; set; }
        public int WritenTime { get; set; }
        
        [ForeignKey("StudentRefFK")]
        public Student StudentFK { get; set; }
        public int StudentRefFK { get; set; }

        [ForeignKey("TestRefFK")]
        public Test TestFK { get; set; }
        public int TestRefFK { get; set; }
    }
}
