using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("AppliedJobs", Schema = "Job")]
    public class AppliedJobs
    {
        [Key]
        public int ApplicationId { get; set; }
        public int CandidateId { get; set; }
        public int CompanyId { get; set; }
        public int JobId { get; set; }
        public DateTime AppliedDate { get; set; }
        public int TotalExamMarks { get; set; }
        public int ObtainMarks { get; set; }
        public decimal MarkPercentage { get; set; }
        public int StatusId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public bool IsProfileMatch { get; set; }
        public bool IsProfileView { get; set; }
    }
}
