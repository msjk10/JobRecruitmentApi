using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Domain.Entities.ViewModel;
using Candidate.Domain.Interfaces;
using Candidate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepository _candidateProfileRepository;
        public CandidateProfileService(ICandidateProfileRepository candidateProfileRepository)
        {
            _candidateProfileRepository = candidateProfileRepository;
        }

        public async Task<string> UpdateCustomJobCategory(CustomCategoryBodyModel customCategoryBodyModel)
        {
            try
            {
                return await _candidateProfileRepository.UpdateCustomJobCategory(customCategoryBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<int> UpdateCandidateJobCategory(CandidateJobCategoryBodyModel candidateJobCategoryBodyModel)
        {
            try
            {
                return await _candidateProfileRepository.UpdateCandidateJobCategory(candidateJobCategoryBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<CandidateSkills>> AddCandidateSkills(IEnumerable<CandidateSkills> candidateSkills)
        {
            try
            {
                return await _candidateProfileRepository.AddCandidateSkills(candidateSkills);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<CandidateSkills>> UpdateCandidateSkills(IEnumerable<CandidateSkills> candidateSkills)
        {
            try
            {
            

                int candidateId = candidateSkills.Select(x=> x.CandidateId).FirstOrDefault();
                int skillId = candidateSkills.Select(x=> x.SkillId).FirstOrDefault();

                return await _candidateProfileRepository.UpdateCandidateSkills(candidateSkills, candidateId, skillId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<EmploymentHistory>> AddCandidateEmploymentHistory(IEnumerable<EmploymentHistory> employmentHistories)
        {
            try
            {
                return await _candidateProfileRepository.AddCandidateEmploymentHistory(employmentHistories);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<EmploymentHistory>> UpdateCandidateEmploymentHistory(IEnumerable<EmploymentHistory> employmentHistory)
        {
            try
            {
                int candidateId = employmentHistory.Select(x => x.CandidateId).FirstOrDefault();
                return await _candidateProfileRepository.UpdateCandidateEmploymentHistory(employmentHistory, candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<int> DeleteCandidateEmploymentHistory(int employmentId)
        {
            try
            {
                return await _candidateProfileRepository.DeleteCandidateEmploymentHistory(employmentId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Project>> AddCandidateProject(IEnumerable<Project> projects)
        {
            try
            {
                return await _candidateProfileRepository.AddCandidateProject(projects);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }



        public async Task<CandidateProfileViewModel> GetCaldidateProfile(int candidateId)
        {
            try
            {
                return await _candidateProfileRepository.GetCaldidateProfile(candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CandidateProfilePercentageViewModel> GetCandidateProfilePercentage(int candidateId)
        {
            try
            {
                var response = new CandidateProfilePercentageViewModel();
                var resultData = Convert.ToDecimal(100) / 17;
                var data = await _candidateProfileRepository.GetCaldidateProfile(candidateId);

                response.ProfilePercentage = 0;
                if (data != null)
                {
                    if (data.DateOfBirth != data.CreatedDate)
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.MaritalStatus != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.Nationality != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.Religion != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.Gender != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.NationalId != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.FathersName != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.MothersName != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.PresentAddress != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.PermanentAddress != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.CandidateContactNo != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.CandidateEmail != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.GitLink != "" || data.LinkedinLink != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.CarrerObjective != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.Interest != "")
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.JobCategoryId > 0)
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.CandidateSkills != null)
                    {
                        response.ProfilePercentage += resultData;
                    }
                    if (data.CandidateEmployment != null)
                    {
                        response.ProfilePercentage += resultData;
                    }

                }
                return response;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<string> UpdateCarrerObjective(CandidateCarrerObjectiveBodyModel candidateCarrerObjectiveBodyModel)
        {
            try
            {
                return await _candidateProfileRepository.UpdateCarrerObjective(candidateCarrerObjectiveBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CandidateImageBodyModel> UpdateCandidatePersonalInformation(CandidateImageBodyModel candidateImageBodyModel)
        {
            try
            {
                return await _candidateProfileRepository.UpdateCandidatePersonalInformation(candidateImageBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CandidateContactBodyModel> UpdateCandidateContact(CandidateContactBodyModel candidateContactBodyModel)
        {
            try
            {
                return await _candidateProfileRepository.UpdateCandidateContact(candidateContactBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Project>> UpdateCandidateProject(IEnumerable<Project> projects)
        {
            try
            {
                int candidateId = projects.Select(x => x.CandidateId).FirstOrDefault();
                return await _candidateProfileRepository.UpdateCandidateProject(projects, candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<int> DeleteCandidateProject(int projectId)
        {
            try
            {
                return await _candidateProfileRepository.DeleteCandidateProject(projectId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Certification>> AddCandidateCertification(IEnumerable<Certification> certifications)
        {
            try
            {
                return await _candidateProfileRepository.AddCandidateCertification(certifications);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Certification>> UpdateCandidateCertification(IEnumerable<Certification> certifications)
        {
            try
            {
                int candidateId = certifications.Select(x => x.CandidateId).FirstOrDefault();
                return await _candidateProfileRepository.UpdateCandidateCertification(certifications, candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<int> DeleteCandidateCertification(int certificationId)
        {
            try
            {
                return await _candidateProfileRepository.DeleteCandidateCertification(certificationId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<EducationalBackground>> AddCandidateEducationBackground(IEnumerable<EducationalBackground> educations)
        {
            try
            {
                return await _candidateProfileRepository.AddCandidateEducationBackground(educations);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<EducationalBackground>> UpdateCandidateEducationalBackground(IEnumerable<EducationalBackground> educations)
        {
            try
            {
                int candidateId = educations.Select(x => x.CandidateId).FirstOrDefault();
                return await _candidateProfileRepository.UpdateCandidateEducationalBackground(educations, candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<int> DeleteCandidateEducationalBackground(int educationBkId)
        {
            try
            {
                return await _candidateProfileRepository.DeleteCandidateEducationalBackground(educationBkId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
