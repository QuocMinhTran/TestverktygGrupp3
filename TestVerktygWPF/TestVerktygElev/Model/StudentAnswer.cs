namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentAnswer
    {
        public int Id { get; set; }

        public int Answer { get; set; }

        public int Question { get; set; }

        public int? OrderPostition { get; set; }

        public int StudentTestFk { get; set; }

        public virtual StudentTest StudentTest { get; set; }
    }
}
