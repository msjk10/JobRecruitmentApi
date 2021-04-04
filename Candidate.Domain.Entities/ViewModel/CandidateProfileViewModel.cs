using Candidate.Domain.Entities.DataModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class CandidateProfileViewModel
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string MaritalStatus { get; set; } 
        public string Nationality { get; set; }
        public string Religion { get; set; } 
        public string Gender { get; set; }
        public string NationalId { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string PresentAddress { get; set; } 
        public string PermanentAddress { get; set; }
        public string CandidateContactNo { get; set; } 
        public string CandidateEmail { get; set; } 
        public string GitLink { get; set; } 
        public string LinkedinLink { get; set; }
        public string CarrerObjective { get; set; }
        public string Interest { get; set; }
        public string ProfileImagePath { get; set; }
        public string ProfileImageView { get; set; }
        public int JobCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<CandidateSkillsViewModel> CandidateSkills { get; set; }
        public IEnumerable<EmploymentHistory> CandidateEmployment { get; set; }
        public IEnumerable<Project> CandidateProject { get; set; }
        public IEnumerable<CandidateEducationViewModel> CandidateEducation { get; set; }
        public IEnumerable<Certification> CandidateCertification { get; set; }
        
        
        
    }
}
