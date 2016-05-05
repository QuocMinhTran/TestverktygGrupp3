namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WritenTest
    {
        public int ID { get; set; }

        public int Score { get; set; }

        public bool IsTestDone { get; set; }

        public int WritenTime { get; set; }

        public int StudentRefFK { get; set; }

        public int TestRefFK { get; set; }

        public virtual Student Student { get; set; }

        public virtual Test Test { get; set; }
    }
}
