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
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public double TimeStampe { get; set; }
        public  bool IsAutoCorrect { get; set; }

        //public Test()
        //{
        //    lxQuestions = new List<Questions>();
        //}
        //public void AddQuestion(Questions xQuestion)
        //{
        //    lxQuestions.Add(xQuestion);
        //}
        //public Questions GetQuestion(int i)
        //{
        //    return lxQuestions[i];   
        //}
        //public bool RemoveQuestion(Questions xQuestion)
        //{
        //    return lxQuestions.Remove(xQuestion);
        //}
        //public void EditQuestion(Questions xQuestion)
        //{

        //}
    }

}
