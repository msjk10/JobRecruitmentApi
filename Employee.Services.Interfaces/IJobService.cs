using Candidate.Domain.Entities.DataModel;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.ViewModel;
using Employee.Domain.Entities.BodyModel;
using Employee.Domain.Entities.DataModel;
using Employee.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Services.Interfaces
{
    public interface IJobService
    {
        Task<TemporaryJobFirstStage> AddTemporaryJobFirstStage(TemporaryJobFirstStage temporaryJobFirstStage);
        Task<TemporaryJobFirstStage> GetTemporaryJobFirstStage(int companyId);
        Task<IEnumerable<TemporaryJobFirstStage>> GetTemporaryJobFirstStageList(int companyId);
        Task<JobSecondStageBodyModel> AddTemporaryJobSecondtStage(JobSecondStageBodyModel jobSecondStageBodyModel);
        Task<JobSecondStageBodyModel> GetJobSecondStageAsync(int tempJobId);
        Task<JobThirdStageBodyModel> AddTemporaryJobThirdtStage(JobThirdStageBodyModel jobThirdStageBodyModel);
        Task<JobThirdStageViewModel> GetJobThirdStage(int tempJobId);

        Task<Jobs> AddJob(JobBodyModel jobBodyModel);
        Task<IEnumerable<JobSummaryViewModel>> GetCompanyJobsSummary(OrderByJobsBodyModel orderByJobs);
        Task<IEnumerable<ApplyedCandidateViewModel>> GetJobWiseAppliedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel);
        Task<IEnumerable<ApplyedCandidateViewModel>> GetNewCandidateList(JobWiseAppliedCandidateBodyModel bodyModel);
        Task<AppliedJobAssissmentViewModel> GetAppliedCandidateAssissmentDetails(CandidateAssessmentBodyModel bodyModel);
        Task<CandidateScreeningViewModel> GetJobWiseCandidateScreening(CandidateAssessmentBodyModel bodyModel);
        Task<IEnumerable<Status>> GetAllStatus();
        Task<AppliedJobs> UpdateAppliedCandidateJobStatus(JobStatusChangeBodyModel JobStatusChangeBodyModel);
        Task<EmployerWellcomeViewModel> GetEmployerWellcomeNote(int companyId);
        Task<AppliedJobs> UpdateApplyedJobScheduleDate(JobScheduleBodyModel jobScheduleBodyModel);
        Task<AppliedJobs> UpdateApplyedCandidateProfileView(ProfileViewBodyModel profileViewBodyModel);
        Task<IEnumerable<JobSummaryViewModel>> GetStatusWiseCompanyJobsSummary(JobStatusBodyModel jobStatus);
        Task<TemporaryJobFirstStage> UpdateTemporaryJobFirstStage(TemporaryJobFirstStage temporaryJobFirstStage);
    }
}
