namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            WritenTests = new HashSet<WritenTest>();
        }

        public int StudentID { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LasttName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public int? Occupations_OccupationID { get; set; }

        public int? GradeClass_GradeClassID { get; set; }

        public virtual GradeClass GradeClass { get; set; }

        public virtual Occupation Occupation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritenTest> WritenTests { get; set; }
    }
}
