using Candidate.Domain.Entities.DataModel;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Employee.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserRegistrationViewModel> UserRegistration(UserEmployerRegistrationBodyModel userRegistrationBodyModel);
        Task<UserLoginViewModel> UserLogin(UserLoginBodyModel userLoginBodyModel);
        Task<Candidates> GetCandidateInfo(int userId);
        Task<Companies> GetCompanyInfo(int userId);
        Task<JobCategory> CandidateJobCategory(int jobCategoryId);
        Task<IEnumerable<Skills>> GetCandidateSkills(int candidateId);
        Task<IEnumerable<CandidateDateViewModel>> GetCandidateExperiance(int candidateId);
    }
}
