namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Controls.Primitives;
    public partial class Answer
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public bool RightAnswer { get; set; }

        public int? OrderPosition { get; set; }

        public int QuestionFk { get; set; }

        public virtual Question Question { get; set; }

    }
}
