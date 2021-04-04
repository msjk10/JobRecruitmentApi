using Candidate.Domain.Entities.DataModel;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Employee.Domain.Entities.DataModel;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public UserRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext= sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<UserRegistrationViewModel> UserRegistration (UserEmployerRegistrationBodyModel userRegistrationBodyModel)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    UserRegistrationViewModel userRegistrationViewModel = new UserRegistrationViewModel();
                    Users users = new Users();
                    var entity = await _sqlServerContext.Users.FirstOrDefaultAsync(item => item.LoginId == userRegistrationBodyModel.LoginId && item.UserType== userRegistrationBodyModel.UserType);
                    if (entity == null)
                    {
                        
                        users.LoginId = userRegistrationBodyModel.LoginId;
                        users.UserName = userRegistrationBodyModel.ContactPersonName;
                        users.UserType = userRegistrationBodyModel.UserType;
                        users.UserPassword = userRegistrationBodyModel.UserPassword;
                        users.IsActive = true;
                        users.CreatedDate = DateTime.Now;
                        users.UpdatedDate = DateTime.Now;
                        users.LastLoginDate = DateTime.Now;
                        users.IsPhoneVerified = false;
                        users.IsEmailVerified = false;
                        users.SignupDeviceInfo = "";
                        users.PackageId = 0;



                        await _sqlServerContext.Users.AddAsync(users);
                        await _sqlServerContext.SaveChangesAsync();


                        userRegistrationViewModel.UserId = users.UserId;
                        userRegistrationViewModel.LoginId = users.LoginId;
                        userRegistrationViewModel.UserName = users.UserName;
                        userRegistrationViewModel.UserType = users.UserType;

                        if(users.UserId>0)
                        {
                            if(users.UserType == "candidate")
                            {
                                Candidates candidates = new Candidates();

                                candidates.CandidateName = users.UserName;
                                candidates.CandidateEmail = users.LoginId;
                                candidates.UserId = users.UserId;
                                candidates.CreatedDate = DateTime.Now;

                                await _sqlServerContext.Candidates.AddAsync(candidates);
                                await _sqlServerContext.SaveChangesAsync();
                            }
                            else if (users.UserType == "company")
                            {
                                Companies companies = new Companies();
                                companies.CompanyName = userRegistrationBodyModel.CompanyName;
                                companies.CompanyEmail = users.LoginId;
                                companies.IndustryType = userRegistrationBodyModel.IndustryType;
                                companies.CompanyAddress = userRegistrationBodyModel.CompanyAddress;
                                companies.CountryId = userRegistrationBodyModel.CountryId;
                                companies.TreadLicencanceNo = userRegistrationBodyModel.TreadLicencanceNo;
                                companies.WebSiteUrl = userRegistrationBodyModel.WebSiteUrl;
                                companies.BusinessDescription = userRegistrationBodyModel.BusinessDescription;
                                companies.ContactPersonName = userRegistrationBodyModel.ContactPersonName;
                                companies.ContactPersonEmailId = userRegistrationBodyModel.ContactPersonEmailId;
                                companies.ContactPersonDesignation = userRegistrationBodyModel.ContactPersonDesignation;
                                companies.PersonalContactNo = userRegistrationBodyModel.PersonalContactNo;
                                companies.UserId = users.UserId;
                                companies.JoiningDate = DateTime.Now;
                                companies.CreatedDate = DateTime.Now;

                                await _sqlServerContext.Companies.AddAsync(companies);
                                await _sqlServerContext.SaveChangesAsync();
                                
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                            
                        }
                        else
                        {
                            transaction.Rollback();
                        }

                        
                    }
                    else
                    {
                        userRegistrationViewModel.UserId = entity.UserId;
                        userRegistrationViewModel.LoginId = entity.LoginId;
                        userRegistrationViewModel.UserName = entity.UserName;
                        userRegistrationViewModel.UserType = entity.UserType;
                    }

                    transaction.Commit();
                    return userRegistrationViewModel;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }

            }
                
        }

        public async Task<UserLoginViewModel> UserLogin(UserLoginBodyModel userLoginBodyModel)
        {
            try
            {
                IQueryable<UserLoginViewModel> response = (from u in _sqlServerContext.Users
                                                           where u.IsActive == true
                                                           && u.LoginId == userLoginBodyModel.LoginId
                                                           && u.UserType== userLoginBodyModel.UserType
                                                           select new UserLoginViewModel
                                                           {
                                                               UserId = u.UserId,
                                                               LoginId = u.LoginId,
                                                               UserName = u.UserName,
                                                               UserType = u.UserType,
                                                               UserPassword = u.UserPassword,
                                                               Token = "",
                                                               ExpirationTime = DateTime.Now.AddDays(1)
                                                           });
                return await response.FirstOrDefaultAsync();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }


        public async Task<Candidates> GetCandidateInfo(int userId)
        {
            IQueryable<Candidates> response = (from u in _sqlServerContext.Candidates
                                                       where u.IsActive == true
                                                       && u.UserId == userId
                                                       select new Candidates
                                                       {
                                                           UserId = u.UserId,
                                                           CandidateId = u.CandidateId,
                                                           JobCategoryId = u.JobCategoryId,
                                                           CandidateName = u.CandidateName
                                                       });
            return await response.FirstOrDefaultAsync();
        }

        public async Task<Companies> GetCompanyInfo(int userId)
        {
            IQueryable<Companies> response = (from u in _sqlServerContext.Companies
                                              where u.IsActive == true
                                               && u.UserId == userId
                                               select new Companies
                                               {
                                                   UserId = u.UserId,
                                                   CompanyId = u.CompanyId,
                                                   CompanyName = u.CompanyName
                                               });
            return await response.FirstOrDefaultAsync();
        }

        public async Task<JobCategory>CandidateJobCategory(int jobCategoryId)
        {
            try
            {
                var data =await _sqlServerContext.JobCategory.Where(x => x.JobCategoryId== jobCategoryId).FirstOrDefaultAsync();
                return data;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<CandidateDateViewModel>> GetCandidateExperiance(int candidateId)
        {
            try
            {
                IQueryable<CandidateDateViewModel> dateViewModel = (from e in _sqlServerContext.EmploymentHistory
                                                                    where e.CandidateId == candidateId
                                                                    select new CandidateDateViewModel
                                                                    {
                                                                        StartDate = e.StartDate,
                                                                        IsCurrentJob = e.IsCurrentJob,
                                                                        EndDate = e.EndDate
                                                                    });
                return await dateViewModel.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Skills>> GetCandidateSkills(int candidateId)
        {
            try
            {
                var data = (from cs in  _sqlServerContext.CandidateSkills
                            join s in _sqlServerContext.Skills
                            on cs.SkillId equals s.SkillId
                            where cs.CandidateId == candidateId
                            select new Skills
                            {

                                SkillId = s.SkillId,
                                SkillName = s.SkillName
                            }).Take(6).ToListAsync();
                return await data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
