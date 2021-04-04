using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Domain.Entities.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate.Services.Interfaces
{
    public interface ICandidateJobService
    {
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateNewJobsSummary(CandidateJobCategoryBodyModel candidateJobCategoryBodyModel);
        Task<BookmarkJob> AddBookmarkJob(BookmarkJob bookmarkJob);
        Task<IEnumerable<CandidateBookmarkJobSummaryViewModel>> GetCandidateBookmarkJobsSummary(CandidateBookmarkJobBodyModel candidateBookmarkJobBodyModel);
        Task<JobDetailsViewModel> GetJobDetails(int jobId);
        Task<JobQuestionsViewModel> GetJobWiseQuestions(int jobId);
        Task<JobDetailsViewModel> GetAppliedJobDetails(AppliedJobDetailsBodyModel appliedJob);
        Task<AppliedJobs> AddCandidateApplyingJob(ApplyingJobBodyModel applyingJobBodyModel);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateAppliedJobsSummary(int candidateId);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateVideoInterviewJobsSummary(int candidateId);
        Task<CandidateWellcomeViewModel> GetCandidateWellComeNote(CandidateWellcomeBodyModel candidateWellcomeBodyModel);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateShortlistedJobsSummary(int candidateId);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateHiredJobsSummary(int candidateId);
    }
}
