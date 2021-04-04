using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("GamificationQuestions", Schema = "Job")]
    public class GamificationQuestions
    {
        [Key]
        public int JobQuestionId { get; set; }
        public int JobId { get; set; }
        public int QuestionId { get; set; }
    }
}
