using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class User //Done
    {
        public int ID { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        [ForeignKey("StudentClassFk")]

        public StudentClass StudentClass { get; set; }
        public int StudentClassFk { get; set; }

        [ForeignKey("OccupationFk")]
        public Occupation Occupations { get; set; }
        public int OccupationFk { get; set; }
    }
}
