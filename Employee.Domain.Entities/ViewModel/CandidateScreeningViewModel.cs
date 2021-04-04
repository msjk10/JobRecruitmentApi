using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.ViewModel
{
    public class CandidateScreeningViewModel
    {
        public int CandidateJobCategoryId { get; set; }
        public string CandidateJobCategoryName { get; set; }
        public int CompanyJobCategoryId { get; set; }
        public string CompanyJobCategoryName { get; set; }
        public string JobYearOfExperience { get; set; }
        public int CandidateYearOfExperience { get; set; }
        public decimal MarkPercentage { get; set; }
        public decimal CandidateProfilePercentage { get; set; }

        public IEnumerable<Skills> CandidateSkills { get; set; }
        public IEnumerable<Skills> JobSkills { get; set; }




    }
}
