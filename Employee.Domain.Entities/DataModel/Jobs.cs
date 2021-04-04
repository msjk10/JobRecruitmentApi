using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("Jobs", Schema = "Job")]
    public class Jobs
    {
        [Key]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public int JobSubCategoryId { get; set; }
        public int CompanyId { get; set; }
        public string JobOverview { get; set; }
        public string Responsibilities { get; set; }
        public string Benifits { get; set; }
        public string Closing { get; set; }
        public string JobStatus { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public string PerMonthYear { get; set; }
        public string SeniorityLevel { get; set; }
        public string YearOfExperience { get; set; }
        public int JobLocation { get; set; }
        public string PostalCode { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public string PreferredLanguage { get; set; }
        public string PreferredInstitute { get; set; }
        public string ProfCertification { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public DateTime ExpiredDate { get; set; } = DateTime.Now;
        public DateTime JobStartingDate { get; set; } = DateTime.Now;
        public int TotalScore { get; set; }
        public int PassingScore { get; set; }
        public bool IsAcceptPassingScore { get; set; }
        public int ApprovalStatus { get; set; } = 0;
        public bool IsActive { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
    }
}
