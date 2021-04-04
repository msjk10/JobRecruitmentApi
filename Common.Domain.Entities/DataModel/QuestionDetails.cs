using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("QuestionDetails", Schema = "Common")]
    public class QuestionDetails
    {
        [Key]
        [Column("QuestionDetailsId")]
        public int QuestionDetailsId { get; set; }
        public int QuestionId { get; set; }
        public string OptionValue { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
