namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CourseGradeClasses
    {
        public int ID { get; set; }

        public int GradeClassRefID { get; set; }

        public int CouseRefID { get; set; }

        public virtual Courses Courses { get; set; }

        public virtual GradeClasses GradeClasses { get; set; }
    }
}
