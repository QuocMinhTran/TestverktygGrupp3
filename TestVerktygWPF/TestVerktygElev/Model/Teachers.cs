namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teachers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teachers()
        {
            Courses = new HashSet<Courses>();
            Tests = new HashSet<Tests>();
        }

        [Key]
        public int TeacherID { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LasttName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public int? Occupations_OccupationID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }

        public virtual Occupations Occupations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
