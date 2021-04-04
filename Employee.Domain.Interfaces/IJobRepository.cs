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

namespace Employee.Domain.Interfaces
{
    public interface IJobRepository
    {
        Task<TemporaryJobFirstStage> AddTemporaryJobFirstStage(TemporaryJobFirstStage temporaryJobFirstStage);
        Task<TemporaryJobFirstStage> GetTemporaryJobFirstStage(int companyId);
        Task<IEnumerable<TemporaryJobFirstStage>> GetTemporaryJobFirstStageList(int companyId);
        Task<JobSecondStageBodyModel> AddTemporaryJobSecondtStage(TempJobSecondStage tempJobSecondStage, IEnumerable<TempSkill> tempSkills, IEnumerable<TempDegree> tempDegrees, IEnumerable<TempGender> tempGenders);
        Task<JobSecondStageBodyModel> GetJobSecondStage(int tempJobId);

        Task<JobThirdStageBodyModel> AddTemporaryJobThirdtStage(TempQuestionScoring tempQuestionScoring, IEnumerable<TempQuestion> tempQuestions);
        Task<JobThirdStageViewModel> GetJobThirdStage(int tempJobId);

        Task<JobInsertViewModel> GetTemporaryJobInfo(JobBodyModel jobBodyModel);

        Task<Jobs> AddJob(Jobs job,IEnumerable<JobSkills> jobSkills,IEnumerable<GamificationQuestions> questions,IEnumerable<Gender> genders,IEnumerable<Qualifications> qualifications,int deleteId);
        Task<IEnumerable<JobSummaryViewModel>> GetCompanyJobsSummary(OrderByJobsBodyModel orderByJobs);
        Task<IEnumerable<ApplyedCandidateViewModel>> GetJobWiseAppliedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel);
        Task<IEnumerable<ApplyedCandidateViewModel>> GetCompanyWiseAppliedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel);
        Task<IEnumerable<ApplyedCandidateViewModel>> GetNewCandidateList(JobWiseAppliedCandidateBodyModel bodyModel);
        Task<IEnumerable<ApplyedCandidateViewModel>> GetShortListedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel);
        Task<AppliedJobAssissmentViewModel> GetAppliedCandidateAssissmentDetails(CandidateAssessmentBodyModel bodyModel);
        Task<CandidateScreeningViewModel> GetJobWiseCandidateScreening(CandidateAssessmentBodyModel bodyModel);
        Task<IEnumerable<Status>> GetAllStatus();
        Task<AppliedJobs> UpdateAppliedCandidateJobStatus(JobStatusChangeBodyModel JobStatusChangeBodyModel);
        int GetCompanyWiseNotProfileViewCandidateCount(int companyId);
        int GetCurrentDateOnlineInterviewCandidatesCount(int companyId);
        Task<AppliedJobs> UpdateApplyedJobScheduleDate(JobScheduleBodyModel jobScheduleBodyModel);
        Task<AppliedJobs> UpdateApplyedCandidateProfileView(ProfileViewBodyModel profileViewBodyModel);
        Task<IEnumerable<JobSummaryViewModel>> GetStatusWiseCompanyJobsSummary(JobStatusBodyModel jobStatus);
        Task<TemporaryJobFirstStage> UpdateTemporaryJobFirstStage(TemporaryJobFirstStage temporaryJobFirstStage);
    }
}
