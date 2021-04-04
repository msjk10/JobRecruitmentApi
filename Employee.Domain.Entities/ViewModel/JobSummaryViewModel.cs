using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.ViewModel
{
    public class JobSummaryViewModel
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public string JobTitle { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int CandidateCount { get; set; }
        public int ApprovalStatus { get; set; }
    }
}
