using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("AnswerSheet", Schema = "Job")]
    public class AnswerSheet
    {
        [Key]
        public int AnswerId { get; set; }
        public int ApplicationId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public int QuestionDetailsId { get; set; }
        public int CompanyId { get; set; }
        public int CandidateId { get; set; }
        public bool IsSubmittedAnswer { get; set; }
    }
}
