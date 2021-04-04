using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("JobFirstStage", Schema = "Temporary")]
    public class TemporaryJobFirstStage
    {
        [Key]
        public int TempJobId { get; set; }
        public int CompanyId { get; set; }
        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public string JobOverview { get; set; }
        public string JobRequirements { get; set; }
        public string Benefits { get; set; }
        public string Closing { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public string JobStatus { get; set; }
        public string SeniorityLevel { get; set; }
        public string YearsOfExperience { get; set; }
        public int DistrictId { get; set; }
        public string PostalCode { get; set; }
        public DateTime SubmissionDeadline { get; set; }
        public DateTime JobStartingDate { get; set; }
        public string PerMonthYear { get; set; }
    }
}
