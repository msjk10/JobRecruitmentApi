using Employee.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.ViewModel
{
    public class JobInsertViewModel
    {
        public int TempJobId { get; set; }
        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public int CompanyId { get; set; }
        public string JobOverview { get; set; }
        public string JobRequirements { get; set; }
        public string Benefits { get; set; }
        public string Closing { get; set; }
        public string JobStatus { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public string PerMonthYear { get; set; }
        public string SeniorityLevel { get; set; }
        public string YearsOfExperience { get; set; }
        public int DistrictId { get; set; }
        public string PostalCode { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public string PreferredLanguage { get; set; }
        public string PreferredInstitution { get; set; }
        public string ProfessionalCertification { get; set; }
        public DateTime SubmissionDeadline { get; set; }
        public DateTime JobStartingDate { get; set; }
        public int TotalScore { get; set; }
        public int PassingScore { get; set; }
        public bool IsAcceptPassingScore { get; set; }
        public IEnumerable<TempSkill> TempSkills { get; set; }
        public IEnumerable<TempQuestion> TempQuestions { get; set; }
        public IEnumerable<TempGender> TempGenders { get; set; }
        public IEnumerable<TempDegree> TempDegrees { get; set; }

    }
}
