namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Options
    {
        [Key]
        public int OptionID { get; set; }

        public string SelectivOption { get; set; }

        public bool RightAnswer { get; set; }


        public int QuestionRefFK { get; set; }

        public virtual Questions Question { get; set; }

    }
}
