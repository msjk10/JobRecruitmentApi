using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class JobDetailsViewModel
    {
        public int JobId { get; set; }

        public string JobTitle { get; set; }
        public int JobLocationId { get; set; }
        public string JobLocation { get; set; }
        public int JobCategoryId { get; set; }
        public string JobCategory { get; set; }
        public string JobStatus { get; set; }
        public string SeniorityLevel { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime JobStartingDate { get; set; }
        public string JobOverview { get; set; }
        public string JobResponsibilities { get; set; }
        public int CompanyId { get; set; }
        public string BusinessCategory { get; set; }
        public string BusinessDescription { get; set; }
        public string CompanyName { get; set; }
        public string YearOfExperiance { get; set; }
        public int CandidateId { get; set; }
        public int StatusId { get; set; }
        public int ApplicationId { get; set; }
        public IEnumerable<JobSkillsViewModel> JobSkills { get; set; }
        public IEnumerable<JobQualificationViewModel> JobQualifications { get; set; }
        

    }
}
