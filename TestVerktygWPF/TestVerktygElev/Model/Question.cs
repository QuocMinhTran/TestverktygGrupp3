namespace TestVerktygElev
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question
    {
        public int QuestionID { get; set; }

        public string QuestionsLabel { get; set; }

        public string AppData { get; set; }

        public int QuestTypeRefFK { get; set; }

        public virtual QuestionType QuestionType { get; set; }
    }
}
