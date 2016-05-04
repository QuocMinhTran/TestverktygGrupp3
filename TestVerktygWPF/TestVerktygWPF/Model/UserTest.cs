using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygWPF.Model
{
    public class UserTest //Ta bort
    {
        public int ID { get; set; }

        [ForeignKey("UserFk")]
        public User User { get; set; }
        public int UserFk { get; set; }

        [ForeignKey("TestFk")]
        public Test Test  { get; set; }
        public int TestFk { get; set; }
    }
}
