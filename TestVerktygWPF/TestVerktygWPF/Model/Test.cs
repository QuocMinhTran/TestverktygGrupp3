using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{

    public class Test 
    {
        [Key]
        public int TestID { get; set; }
        public string Name { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }

        [ForeignKey("TeacherRefFK")]
        public Teacher TeacherFK { get; set; }
        public int TeacherRefFK { get; set; }
        

        private List<Questions> lxQuestions;

        public Test()
        {
            lxQuestions = new List<Questions>();
        }
        public void AddQuestion(Questions xQuestion)
        {
            lxQuestions.Add(xQuestion);
        }
        public Questions GetQuestion(int i)
        {
            return lxQuestions[i];   
        }
        public bool RemoveQuestion(Questions xQuestion)
        {
            return lxQuestions.Remove(xQuestion);
        }
        public void EditQuestion(Occupation xQuestion)
        {

        }
    }

}
