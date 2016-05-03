namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentTests
    {
        public int ID { get; set; }

        public int StudentRefFk { get; set; }

        public int TestRefFk { get; set; }

        public virtual Students Students { get; set; }

        public virtual Tests Tests { get; set; }
    }
}
