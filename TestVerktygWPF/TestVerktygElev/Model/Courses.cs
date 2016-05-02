namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            CourseGradeClasses = new HashSet<CourseGradeClasses>();
        }

        [Key]
        public int CourseID { get; set; }

        public int TeacherRefFK { get; set; }

        public int? Subject_SubjectsID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseGradeClasses> CourseGradeClasses { get; set; }

        public virtual Subjects Subjects { get; set; }

        public virtual Teachers Teachers { get; set; }
    }
}
