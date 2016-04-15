namespace RakietaLogikaBiznesowa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormAnswers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FormsId { get; set; }

        public int FormQuestionId { get; set; }

        public int Answer { get; set; }

        public int UserId { get; set; }

        public virtual Forms Forms { get; set; }

        public virtual FormQuestions FormQuestions { get; set; }

        public virtual User Respondent { get; set; }
    }
}
