namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentTest
    {
        public int ID { get; set; }

        public int StudentRefFk { get; set; }

        public int TestRefFk { get; set; }

        public virtual Student Student { get; set; }

        public virtual Test Test { get; set; }
    }
}
