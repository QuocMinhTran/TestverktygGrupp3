namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestQuestion
    {
        public int ID { get; set; }

        public int TestRefFk { get; set; }

        public int QuestionRefFk { get; set; }

        public virtual Question Question { get; set; }

        public virtual Test Test { get; set; }
    }
}
