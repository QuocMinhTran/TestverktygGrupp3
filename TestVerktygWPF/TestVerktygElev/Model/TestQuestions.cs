namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestQuestions
    {
        public int ID { get; set; }

        public int TestRefFk { get; set; }

        public int QuestionRefFk { get; set; }

        public virtual Occupations Occupations { get; set; }

        public virtual Tests Tests { get; set; }
    }
}
