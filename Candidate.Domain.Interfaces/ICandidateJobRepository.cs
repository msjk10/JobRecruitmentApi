using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.Domain.Interfaces
{
    public interface ICandidateJobRepository
    {
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateNewJobsSummary(CandidateJobCategoryBodyModel candidateJobCategoryBodyModel);
        Task<BookmarkJob> AddBookmarkJob(BookmarkJob bookmarkJob);
        Task<BookmarkJob> UpdateBookmarkJob(BookmarkJob bookmarkJob);
        Task<IEnumerable<CandidateBookmarkJobSummaryViewModel>> GetCandidateBookmarkJobsSummary(CandidateBookmarkJobBodyModel candidateBookmarkJobBodyModel);
        Task<JobDetailsViewModel> GetJobDetails(int jobId);
        Task<JobQuestionsViewModel> GetJobWiseQuestions(int jobId);
        Task<AppliedJobs> AddCandidateApplyingJob(AppliedJobs appliedJob,IEnumerable<AnswerSheet> answerSheets);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateAppliedJobsSummary(int candidateId);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateVideoInterviewJobsSummary(int candidateId);
        int GetMatchJobCountOfCandidate(CandidateWellcomeBodyModel bodyModel);
        Task<JobDetailsViewModel> GetAppliedJobDetails(AppliedJobDetailsBodyModel appliedJob);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateShortlistedJobsSummary(int candidateId);
        Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateHiredJobsSummary(int candidateId);
    }
}
