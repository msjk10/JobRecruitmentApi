using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Domain.Entities.ViewModel;
using Candidate.Domain.Interfaces;
using Candidate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidate.Services
{
    public class CandidateJobService: ICandidateJobService
    {
        private readonly ICandidateJobRepository _candidateJobRepository;
        public CandidateJobService(ICandidateJobRepository candidateJobRepository)
        {
            _candidateJobRepository = candidateJobRepository;
        }

        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateNewJobsSummary(CandidateJobCategoryBodyModel candidateJobCategoryBodyModel)
        {
            try
            {
                return await _candidateJobRepository.GetCandidateNewJobsSummary(candidateJobCategoryBodyModel);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateShortlistedJobsSummary(int candidateId)
        {
            try
            {
                return await _candidateJobRepository.GetCandidateShortlistedJobsSummary(candidateId);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateHiredJobsSummary(int candidateId)
        {
            try
            {
                return await _candidateJobRepository.GetCandidateHiredJobsSummary(candidateId);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<BookmarkJob> AddBookmarkJob(BookmarkJob bookmarkJob)
        {
            try
            {
                if(bookmarkJob.BookmarkId==0)
                {
                    return await _candidateJobRepository.AddBookmarkJob(bookmarkJob);
                }
                else
                {
                    return await _candidateJobRepository.UpdateBookmarkJob(bookmarkJob);
                }
                
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<CandidateBookmarkJobSummaryViewModel>> GetCandidateBookmarkJobsSummary(CandidateBookmarkJobBodyModel candidateBookmarkJobBodyModel)
        {

            try
            {
                return await _candidateJobRepository.GetCandidateBookmarkJobsSummary(candidateBookmarkJobBodyModel);

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<JobDetailsViewModel> GetJobDetails(int jobId)
        {

            try
            {
                return await _candidateJobRepository.GetJobDetails(jobId);

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<JobDetailsViewModel> GetAppliedJobDetails(AppliedJobDetailsBodyModel appliedJob)
        {

            try
            {
                return await _candidateJobRepository.GetAppliedJobDetails(appliedJob);

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<JobQuestionsViewModel> GetJobWiseQuestions(int jobId)
        {
            try
            {
                return await _candidateJobRepository.GetJobWiseQuestions(jobId);

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<AppliedJobs> AddCandidateApplyingJob(ApplyingJobBodyModel applyingJobBodyModel)
        {
            try
            {
                var appliedJob = new AppliedJobs();
                var answerSheet = new List<AnswerSheet>();

                appliedJob.ApplicationId = 0;
                appliedJob.CandidateId = applyingJobBodyModel.CandidateId;
                appliedJob.CompanyId = applyingJobBodyModel.CompanyId;
                appliedJob.JobId = applyingJobBodyModel.JobId;
                appliedJob.AppliedDate = DateTime.Now;
                appliedJob.TotalExamMarks = applyingJobBodyModel.TotalScore;
                appliedJob.StatusId = 0;
                appliedJob.ScheduleDate = DateTime.Now;
                appliedJob.IsProfileMatch = applyingJobBodyModel.IsProfileMatch;

                if (applyingJobBodyModel.Answers !=null)
                {
                    foreach(var a in applyingJobBodyModel.Answers)
                    {
                        var answer = new AnswerSheet
                        {
                            AnswerId = 0,
                            ApplicationId = 0,
                            QuestionId = a.QuestionId,
                            Answer = a.OptionValue,
                            QuestionDetailsId = a.QuestionDetailsId,
                            CompanyId= applyingJobBodyModel.CompanyId,
                            CandidateId = applyingJobBodyModel.CandidateId,
                            IsSubmittedAnswer= a.IsCorrectAnswer && a.IsSubmittedAnswer? true:false
                        };
                        if(a.IsCorrectAnswer && a.IsSubmittedAnswer)
                        {
                            appliedJob.ObtainMarks += a.Point;
                        }

                        answerSheet.Add(answer);
                    }
                }

                appliedJob.MarkPercentage = ((appliedJob.ObtainMarks*100) / appliedJob.TotalExamMarks);

                var response = await _candidateJobRepository.AddCandidateApplyingJob(appliedJob, answerSheet);
                return response;

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateAppliedJobsSummary(int candidateId)
        {
            try
            {
                return await _candidateJobRepository.GetCandidateAppliedJobsSummary(candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateVideoInterviewJobsSummary(int candidateId)
        {
            try
            {
                return await _candidateJobRepository.GetCandidateVideoInterviewJobsSummary(candidateId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CandidateWellcomeViewModel> GetCandidateWellComeNote(CandidateWellcomeBodyModel candidateWellcomeBodyModel)
        {
            try
            {
                var candidateWellcomeViewModel = new CandidateWellcomeViewModel();

                var interviewjob=await _candidateJobRepository.GetCandidateVideoInterviewJobsSummary(candidateWellcomeBodyModel.CandidateId);
                int interviewjobcount = 0;

                if(interviewjob != null)
                {
                    foreach (var i in interviewjob)
                    {
                        interviewjobcount++;
                    }
                }
                candidateWellcomeViewModel.InterviewJobCount = interviewjobcount;
                candidateWellcomeViewModel.NewJobCount = _candidateJobRepository.GetMatchJobCountOfCandidate(candidateWellcomeBodyModel);


                return candidateWellcomeViewModel;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}
