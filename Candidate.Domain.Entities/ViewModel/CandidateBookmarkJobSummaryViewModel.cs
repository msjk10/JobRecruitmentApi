using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class CandidateBookmarkJobSummaryViewModel
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
        public bool IsBookmark { get; set; }
        public int CandidateId { get; set; }
        public int BookmarkId { get; set; }
    }
}
