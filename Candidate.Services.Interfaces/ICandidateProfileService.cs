using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Services.Interfaces
{
    public interface ICandidateProfileService
    {
        Task<string> UpdateCustomJobCategory(CustomCategoryBodyModel customCategoryBodyModel);
        Task<int> UpdateCandidateJobCategory(CandidateJobCategoryBodyModel candidateJobCategoryBodyModel);
        Task<IEnumerable<CandidateSkills>> AddCandidateSkills(IEnumerable<CandidateSkills> candidateSkills);
        Task<IEnumerable<EmploymentHistory>> AddCandidateEmploymentHistory(IEnumerable<EmploymentHistory> employmentHistories);
        Task<CandidateProfileViewModel> GetCaldidateProfile(int candidateId);
        Task<CandidateProfilePercentageViewModel> GetCandidateProfilePercentage(int candidateId);
        Task<string> UpdateCarrerObjective(CandidateCarrerObjectiveBodyModel candidateCarrerObjectiveBodyModel);
        Task<CandidateContactBodyModel> UpdateCandidateContact(CandidateContactBodyModel candidateContactBodyModel);
        Task<IEnumerable<CandidateSkills>> UpdateCandidateSkills(IEnumerable<CandidateSkills> candidateSkills);
        Task<IEnumerable<EmploymentHistory>> UpdateCandidateEmploymentHistory(IEnumerable<EmploymentHistory> employmentHistory);
        Task<IEnumerable<Project>> AddCandidateProject(IEnumerable<Project> projects);
        Task<IEnumerable<Project>> UpdateCandidateProject(IEnumerable<Project> projects);
        Task<IEnumerable<Certification>> AddCandidateCertification(IEnumerable<Certification> certifications);
        Task<IEnumerable<Certification>> UpdateCandidateCertification(IEnumerable<Certification> certifications);
        Task<IEnumerable<EducationalBackground>> AddCandidateEducationBackground(IEnumerable<EducationalBackground> educations);
        Task<IEnumerable<EducationalBackground>> UpdateCandidateEducationalBackground(IEnumerable<EducationalBackground> educations);
        Task<int> DeleteCandidateEducationalBackground(int educationBkId);
        Task<int> DeleteCandidateCertification(int certificationId);
        Task<int> DeleteCandidateProject(int projectId);
        Task<int> DeleteCandidateEmploymentHistory(int employmentId);
        Task<CandidateImageBodyModel> UpdateCandidatePersonalInformation(CandidateImageBodyModel candidateImageBodyModel);
    }
}
