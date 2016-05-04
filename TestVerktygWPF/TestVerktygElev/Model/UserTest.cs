namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserTest
    {
        public int ID { get; set; }

        public int UserFk { get; set; }

        public int TestFk { get; set; }

        public virtual Test Test { get; set; }

        public virtual User User { get; set; }
    }
}
