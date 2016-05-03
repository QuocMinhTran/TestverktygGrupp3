namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tests()
        {
<<<<<<< HEAD:TestVerktygWPF/TestVerktygElev/Model/Test.cs
            TestQuestions = new HashSet<TestQuestion>();
            WritenTests = new HashSet<WritenTest>();
=======
            Students = new HashSet<Students>();
            StudentTests = new HashSet<StudentTests>();
            TestQuestions = new HashSet<TestQuestions>();
            WritenTests = new HashSet<WritenTests>();
>>>>>>> origin/master:TestVerktygWPF/TestVerktygElev/Model/Tests.cs
        }

        [Key]
        public int TestID { get; set; }

        public string Name { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? StartDate { get; set; }

        public int TeacherRefFK { get; set; }

<<<<<<< HEAD:TestVerktygWPF/TestVerktygElev/Model/Test.cs
        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritenTest> WritenTests { get; set; }
=======
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTests> StudentTests { get; set; }

        public virtual Teachers Teachers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestQuestions> TestQuestions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WritenTests> WritenTests { get; set; }
>>>>>>> origin/master:TestVerktygWPF/TestVerktygElev/Model/Tests.cs
    }
}
