namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentClassCourses")]
    public partial class StudentClassCours
    {
        public int ID { get; set; }

        public int StudentClassRefID { get; set; }

        public int CouseRefID { get; set; }

        public virtual Cours Cours { get; set; }

        public virtual StudentClass StudentClass { get; set; }
    }
}
