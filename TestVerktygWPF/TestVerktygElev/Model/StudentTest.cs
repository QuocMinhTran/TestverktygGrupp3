namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentTest()
        {
            StudentAnswers = new HashSet<StudentAnswer>();
        }

        public int ID { get; set; }

        public int Score { get; set; }

        public bool IsTestDone { get; set; }

        public int WritenTime { get; set; }

        public int StudentRefFk { get; set; }

        public int TestRefFk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAnswer> StudentAnswers { get; set; }

        public virtual Student Student { get; set; }

        public virtual Test Test { get; set; }
    }
}
