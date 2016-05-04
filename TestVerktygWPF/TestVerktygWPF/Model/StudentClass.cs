using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class StudentClass //Done
    {
        
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
