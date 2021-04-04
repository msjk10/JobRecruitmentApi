using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("Questions", Schema = "Temporary")]
    public class TempQuestion
    {
        [Key]
        public int TempQuestionId { get; set; }
        public int TempJobId { get; set; }
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
    }
}
