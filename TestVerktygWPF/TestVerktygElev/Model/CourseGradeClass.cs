namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CourseGradeClass
    {
        public int ID { get; set; }

        public int GradeClassRefID { get; set; }

        public int CouseRefID { get; set; }

        public virtual Cours Cours { get; set; }

        public virtual GradeClass GradeClass { get; set; }
    }
}
