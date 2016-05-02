namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
<<<<<<< HEAD:TestVerktygWPF/TestVerktygElev/Model/Student.cs
            WritenTests = new HashSet<WritenTest>();
=======
            StudentTests = new HashSet<StudentTests>();
            WritenTests = new HashSet<WritenTests>();
>>>>>>> origin/master:TestVerktygWPF/TestVerktygElev/Model/Students.cs
        }

        [Key]
        public int StudentID { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LasttName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public int? Occupations_OccupationID { get; set; }

<<<<<<< HEAD:TestVerktygWPF/TestVerktygElev/Model/Student.cs
        public int? GradeClass_GradeClassID { get; set; }
=======
        public int? Tests_TestID { get; set; }

        public int? GradeClass_GradeClassID { get; set; }

        public virtual GradeClasses GradeClasses { get; set; }
>>>>>>> origin/master:TestVerktygWPF/TestVerktygElev/Model/Students.cs

        public virtual Occupations Occupations { get; set; }

        public virtual Tests Tests { get; set; }

<<<<<<< HEAD:TestVerktygWPF/TestVerktygElev/Model/Student.cs
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritenTest> WritenTests { get; set; }
=======
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTests> StudentTests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritenTests> WritenTests { get; set; }
>>>>>>> origin/master:TestVerktygWPF/TestVerktygElev/Model/Students.cs
    }
}
