using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Domain.Entities.ViewModel;
using Candidate.Domain.Interfaces;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Infrastructure.Data
{
    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public CandidateProfileRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<string> UpdateCustomJobCategory(CustomCategoryBodyModel customCategoryBodyModel)
        {
            try
            {
                var entity = await _sqlServerContext.Candidates.FirstOrDefaultAsync(item => item.CandidateId == customCategoryBodyModel.CandidateId);
                if (entity != null)
                {
                    entity.CandidateId = customCategoryBodyModel.CandidateId;
                    entity.CustomJobCategory = customCategoryBodyModel.CustomJobCategory;
                    entity.UpdatedDate = DateTime.Now;


                    _sqlServerContext.Candidates.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }
                return entity.CustomJobCategory;
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
                var entity = await _sqlServerContext.Candidates.FirstOrDefaultAsync(item => item.CandidateId == candidateJobCategoryBodyModel.CandidateId);
                if (entity != null)
                {
                    entity.CandidateId = candidateJobCategoryBodyModel.CandidateId;
                    entity.JobCategoryId = candidateJobCategoryBodyModel.JobCategoryId;
                    entity.UpdatedDate = DateTime.Now;


                    _sqlServerContext.Candidates.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }
                return entity.JobCategoryId;
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

                await _sqlServerContext.CandidateSkills.AddRangeAsync(candidateSkills);
                await _sqlServerContext.SaveChangesAsync();

                return candidateSkills;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<CandidateSkills>> UpdateCandidateSkills(IEnumerable<CandidateSkills> candidateSkills, int candidateId, int skillId)
        {
            try
            {
                var entity = await _sqlServerContext.CandidateSkills.Where(c => c.CandidateId == candidateId).ToListAsync();
                if(entity != null)
                {
                    _sqlServerContext.CandidateSkills.RemoveRange(entity);
                    _sqlServerContext.SaveChanges();

                }                
                if (skillId > 0)
                {
                    await _sqlServerContext.CandidateSkills.AddRangeAsync(candidateSkills);
                    await _sqlServerContext.SaveChangesAsync();
                }
                

                return candidateSkills;
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

                await _sqlServerContext.EmploymentHistory.AddRangeAsync(employmentHistories);
                await _sqlServerContext.SaveChangesAsync();

                return employmentHistories;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<EmploymentHistory>> UpdateCandidateEmploymentHistory(IEnumerable<EmploymentHistory> employmentHistory, int candidateId)
        {
            try
            {
                _sqlServerContext.EmploymentHistory.UpdateRange(employmentHistory);
                await _sqlServerContext.SaveChangesAsync();

                return employmentHistory;
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
                var entity = await _sqlServerContext.EmploymentHistory.Where(ed => ed.EmploymentId == employmentId).FirstOrDefaultAsync();
                if (entity != null)
                {
                    _sqlServerContext.Remove(entity);
                    await _sqlServerContext.SaveChangesAsync();
                    return employmentId;
                }

                return employmentId = 0;
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
                IQueryable<CandidateProfileViewModel> response = (from c in _sqlServerContext.Candidates
                                                                  where c.CandidateId == candidateId
                                                                  select new CandidateProfileViewModel
                                                                  {
                                                                      CandidateId = c.CandidateId,
                                                                      CandidateName = c.CandidateName,
                                                                      DateOfBirth = c.DateOfBirth,
                                                                      MaritalStatus = c.MaritalStatus,
                                                                      Nationality = c.Nationality,
                                                                      Religion = c.Religion,
                                                                      Gender = c.Gender,
                                                                      NationalId = c.NationalId,
                                                                      FathersName = c.FathersName,
                                                                      MothersName = c.MothersName,
                                                                      PresentAddress = c.PresentAddress,
                                                                      PermanentAddress = c.PermanentAddress,
                                                                      CandidateContactNo = c.CandidateContactNo,
                                                                      CandidateEmail = c.CandidateEmail,
                                                                      GitLink = c.GitLink,
                                                                      LinkedinLink = c.LinkedinLink,
                                                                      CarrerObjective = c.CarrerObjective,
                                                                      Interest = c.Interest,
                                                                      ProfileImagePath = c.ProfileImagePath,
                                                                      JobCategoryId = c.JobCategoryId,
                                                                      CreatedDate = c.CreatedDate,
                                                                      CandidateSkills = (from cs in _sqlServerContext.CandidateSkills
                                                                                         join s in _sqlServerContext.Skills
                                                                                         on cs.SkillId equals s.SkillId
                                                                                         where cs.CandidateId == candidateId

                                                                                         select new CandidateSkillsViewModel
                                                                                         {
                                                                                             CandidateId = cs.CandidateId,
                                                                                             SkillId = s.SkillId,
                                                                                             SkillCategoryId = s.SkillCategoryId,
                                                                                             SkillName = s.SkillName
                                                                                         }).Take(6),
                                                                      CandidateEmployment = (from eh in _sqlServerContext.EmploymentHistory
                                                                                             where eh.CandidateId == candidateId
                                                                                             orderby eh.EndDate descending,eh.StartDate descending
                                                                                             select new EmploymentHistory
                                                                                             {
                                                                                                 EmploymentId = eh.EmploymentId,
                                                                                                 CandidateId = eh.CandidateId,
                                                                                                 StartDate = eh.StartDate,
                                                                                                 EndDate = eh.IsCurrentJob? DateTime.Now: eh.EndDate,
                                                                                                 Organization = eh.Organization,
                                                                                                 Designation = eh.Designation,
                                                                                                 JobDescription = eh.JobDescription,
                                                                                                 JobLocation = eh.JobLocation,
                                                                                                 EmploymentType = eh.EmploymentType,
                                                                                                 IsCurrentJob = eh.IsCurrentJob,
                                                                                             }),
                                                                      CandidateProject = (from p in _sqlServerContext.Project
                                                                                             where p.CandidateId == candidateId
                                                                                             orderby p.EndDate descending, p.StartDate descending
                                                                                             select new Project
                                                                                             {
                                                                                                 ProjectId = p.ProjectId,
                                                                                                 CandidateId = p.CandidateId,
                                                                                                 StartDate = p.StartDate,
                                                                                                 EndDate = p.IsRunning ? DateTime.Now : p.EndDate,
                                                                                                 ProjectTitle = p.ProjectTitle,
                                                                                                 ProjectCompany = p.ProjectCompany,
                                                                                                 ProjectLocation = p.ProjectLocation,
                                                                                                 Description = p.Description,
                                                                                                 IsRunning = p.IsRunning,
                                                                                             }),
                                                                      CandidateCertification = (from ce in _sqlServerContext.Certification
                                                                                             where ce.CandidateId == candidateId
                                                                                             orderby ce.CertificationDate descending
                                                                                             select new Certification
                                                                                             {
                                                                                                 CertificationId = ce.CertificationId,
                                                                                                 CandidateId = ce.CandidateId,
                                                                                                 CertificationDate = ce.CertificationDate,
                                                                                                 IssuingOrganization = ce.IssuingOrganization,
                                                                                                 CertificationName = ce.CertificationName,
                                                                                             }),
                                                                      CandidateEducation = (from eb in _sqlServerContext.EducationalBackground
                                                                                            join dl in _sqlServerContext.DegreeLevel on eb.DegreeLevelId equals dl.DegreeLevelId
                                                                                            join d in _sqlServerContext.Degree on eb.DegreeId equals d.DegreeId
                                                                                             where eb.CandidateId == candidateId
                                                                                             orderby eb.EndDate descending, eb.StartDate descending
                                                                                             select new CandidateEducationViewModel
                                                                                             {
                                                                                                 EducationBkId = eb.EducationBkId,
                                                                                                 CandidateId = eb.CandidateId,
                                                                                                 StartDate = eb.StartDate,
                                                                                                 EndDate = eb.EndDate,
                                                                                                 Institute = eb.Institute,
                                                                                                 DegreeLevelId = eb.DegreeLevelId,
                                                                                                 DegreeId = eb.DegreeId,
                                                                                                 DegreeLevelName = dl.DegreeLevelName,
                                                                                                 DegreeName = d.DegreeName,
                                                                                                 PassingScore = eb.PassingScore,
                                                                                                 ScoreRange = eb.ScoreRange,
                                                                                                 CreatedDate = eb.CreatedDate,
                                                                                                 UpdatedDate = eb.UpdatedDate,
                                                                                             }),

                                                                  });
                return await response.FirstOrDefaultAsync();

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<string> UpdateCarrerObjective (CandidateCarrerObjectiveBodyModel candidateCarrerObjectiveBodyModel)
        {
            try
            {
                var entity = await _sqlServerContext.Candidates.FirstOrDefaultAsync(item => item.CandidateId == candidateCarrerObjectiveBodyModel.CandidateId);
                if (entity != null)
                {
                    entity.CandidateId = candidateCarrerObjectiveBodyModel.CandidateId;
                    entity.CarrerObjective = candidateCarrerObjectiveBodyModel.CarrerObjective;
                    entity.UpdatedDate = DateTime.Now;


                    _sqlServerContext.Candidates.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }
                if (entity.CarrerObjective == "")
                {
                    entity.CarrerObjective = "null";
                }
                return entity.CarrerObjective;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CandidateImageBodyModel> UpdateCandidatePersonalInformation (CandidateImageBodyModel candidateImageBodyModel)
        {
            try
            {
                var entity = await _sqlServerContext.Candidates.FirstOrDefaultAsync(item => item.CandidateId == candidateImageBodyModel.CandidateId);
                if (entity != null)
                {
                    entity.CandidateId = candidateImageBodyModel.CandidateId;
                    entity.CandidateName = candidateImageBodyModel.CandidateName;
                    entity.PermanentAddress = candidateImageBodyModel.PermanentAddress;
                    entity.ProfileImagePath = candidateImageBodyModel.ProfileImagePath;
                    entity.UpdatedDate = DateTime.Now;


                    _sqlServerContext.Candidates.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }
                return candidateImageBodyModel;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CandidateContactBodyModel> UpdateCandidateContact (CandidateContactBodyModel candidateContactBodyModel)
        {
            try
            {
                var entity = await _sqlServerContext.Candidates.FirstOrDefaultAsync(item => item.CandidateId == candidateContactBodyModel.CandidateId);
                if (entity != null)
                {
                    entity.CandidateId = candidateContactBodyModel.CandidateId;
                    entity.CandidateEmail = candidateContactBodyModel.CandidateEmail;
                    entity.CandidateContactNo = candidateContactBodyModel.CandidateContactNo;
                    entity.GitLink = candidateContactBodyModel.GitLink;
                    entity.PresentAddress = candidateContactBodyModel.PresentAddress;
                    entity.UpdatedDate = DateTime.Now;


                    _sqlServerContext.Candidates.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    candidateContactBodyModel.CandidateId = candidateContactBodyModel.CandidateId;
                    candidateContactBodyModel.CandidateEmail = "";
                    candidateContactBodyModel.CandidateContactNo = "";
                    candidateContactBodyModel.GitLink = "";
                    candidateContactBodyModel.PresentAddress = "";
                }
                return candidateContactBodyModel;
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

                await _sqlServerContext.Project.AddRangeAsync(projects);
                await _sqlServerContext.SaveChangesAsync();

                return projects;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Project>> UpdateCandidateProject(IEnumerable<Project> projects, int candidateId)
        {
            try
            {
                _sqlServerContext.Project.UpdateRange(projects);
                await _sqlServerContext.SaveChangesAsync();

                return projects;
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
                var entity = await _sqlServerContext.Project.Where(ed => ed.ProjectId == projectId).FirstOrDefaultAsync();
                if (entity != null)
                {
                    _sqlServerContext.Remove(entity);
                    await _sqlServerContext.SaveChangesAsync();
                    return projectId;
                }

                return projectId = 0;
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

                await _sqlServerContext.Certification.AddRangeAsync(certifications);
                await _sqlServerContext.SaveChangesAsync();

                return certifications;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Certification>> UpdateCandidateCertification(IEnumerable<Certification> certifications, int candidateId)
        {
            try
            {
                _sqlServerContext.Certification.UpdateRange(certifications);
                await _sqlServerContext.SaveChangesAsync();

                return certifications;
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
                var entity = await _sqlServerContext.Certification.Where(ed => ed.CertificationId == certificationId).FirstOrDefaultAsync();
                if (entity != null)
                {
                    _sqlServerContext.Remove(entity);
                    await _sqlServerContext.SaveChangesAsync();
                    return certificationId;
                }
                return certificationId = 0;
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

                await _sqlServerContext.EducationalBackground.AddRangeAsync(educations);
                await _sqlServerContext.SaveChangesAsync();

                return educations;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<EducationalBackground>> UpdateCandidateEducationalBackground(IEnumerable<EducationalBackground> educations, int candidateId)
        {
            try
            {
                _sqlServerContext.EducationalBackground.UpdateRange(educations);
                await _sqlServerContext.SaveChangesAsync();

                return educations;
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
                var entity = await _sqlServerContext.EducationalBackground.Where(ed => ed.EducationBkId == educationBkId).FirstOrDefaultAsync();
                if(entity != null)
                {
                    _sqlServerContext.Remove(entity);
                    await _sqlServerContext.SaveChangesAsync();
                    return educationBkId;
                }

                return educationBkId = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
