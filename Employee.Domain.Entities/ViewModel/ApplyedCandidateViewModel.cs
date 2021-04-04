using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.ViewModel
{
    public class ApplyedCandidateViewModel
    {
        public int JobId { get; set; }
        public int ApplicationId { get; set; }
        public int CompanyId { get; set; }
        public int StatusId { get; set; }
        public string JobTitle { get; set; }
        public int TotalExamMarks { get; set; }
        public int ObtainMarks { get; set; }
        public decimal MarkPercentage { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public bool IsProfileMatch { get; set; }
        public bool IsProfileView { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int CandidateCount { get; set; }
        public decimal CandidateProfilePercentage { get; set; }
    }
}
