namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        public int AdminID { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public int? Occupations_OccupationID { get; set; }

        public virtual Occupation Occupation { get; set; }
    }
}
