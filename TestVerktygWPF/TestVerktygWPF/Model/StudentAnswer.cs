using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{

    public class StudentAnswer
    {
        public int Id { get; set; }
        public int Answer { get; set; }
        public int Question { get; set; }
        public int? OrderPostition { get; set; }

        [ForeignKey("StudentTestFk")]
        public StudentTest StudentTest { get; set; }
        public int StudentTestFk { get; set; }

       

    }
}
