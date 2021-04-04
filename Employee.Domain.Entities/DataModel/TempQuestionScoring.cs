using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("QuestionScoring", Schema = "Temporary")]
    public class TempQuestionScoring
    {
        [Key]
        public int ScoreId { get; set; }
        public int TempJobId { get; set; }
        public int TotalScore { get; set; }
        public int PassingScore { get; set; }
        public bool IsAcceptPassingScore { get; set; }
    }
}
