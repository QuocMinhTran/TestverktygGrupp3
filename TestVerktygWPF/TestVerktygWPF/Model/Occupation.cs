using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class Occupation 
    {
        [Key]
        public int OccupationID { get; set; }
        public string Occupations { get; set; }
    }
}
