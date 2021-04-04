using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class CandidateJobSummaryViewModel
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public string SeniorityLevel { get; set; }
        public string JobStatus { get; set; }
        public int JobLocationId { get; set; }
        public string JobLocationName { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool IsBookmark { get; set; }
        public int StatusId { get; set; }
        public int ApplicationId { get; set; }
        public int BookmarkId { get; set; }

    }
}
