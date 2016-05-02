namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Questions
    {
        [Key]
        public int QuestionID { get; set; }

        public string QuestionsLabel { get; set; }

        public string AppData { get; set; }

        public int QuestTypeRefFK { get; set; }

        public virtual QuestionTypes QuestionTypes { get; set; }
    }
}
