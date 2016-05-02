namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Option
    {
        public int OptionID { get; set; }

        public string SelectivOption { get; set; }

        public bool RightAnswer { get; set; }

        public int QuestionRefFK { get; set; }

        public virtual Question Question { get; set; }
    }
}
