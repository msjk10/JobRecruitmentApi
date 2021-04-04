using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Domain.Entities.ViewModel;
using Candidate.Domain.Interfaces;
using Common.Domain.Entities.DataModel;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate.Infrastructure.Data
{
    public class CandidateJobRepository : ICandidateJobRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public CandidateJobRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateNewJobsSummary(CandidateJobCategoryBodyModel candidateJobCategoryBodyModel)
        {
            try
            {

                IQueryable<CandidateJobSummaryViewModel> data = (from j in _sqlServerContext.Jobs
                                                                 join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                                                                 join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                                                                 join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId     
                                                                 where j.JobCategoryId == candidateJobCategoryBodyModel.JobCategoryId && j.IsActive == true && j.ExpiredDate >= DateTime.Now.Date
                                                                 && ((from aj in _sqlServerContext.AppliedJob where j.JobId == aj.JobId && aj.CandidateId == candidateJobCategoryBodyModel.CandidateId select aj.ApplicationId).FirstOrDefault() < 1)
                                                                 orderby j.JobId descending
                                                                 select new CandidateJobSummaryViewModel
                                                                 {
                                                                     JobId = j.JobId,
                                                                     JobTitle = j.JobTitle,
                                                                     CompanyId = j.CompanyId,
                                                                     CompanyName = c.CompanyName,
                                                                     JobCategoryId = j.JobCategoryId,
                                                                     JobCategoryName = jc.JobCategoryName,
                                                                     MaxSalary = j.MaxSalary,
                                                                     MinSalary = j.MinSalary,
                                                                     SeniorityLevel = j.SeniorityLevel,
                                                                     JobStatus = j.JobStatus,
                                                                     JobLocationId = j.JobLocation,
                                                                     JobLocationName = d.DistrictName,
                                                                     PublishedDate = j.PublishedDate,
                                                                     ExpiredDate = j.ExpiredDate,
                                                                     IsBookmark = (from bj in _sqlServerContext.BookmarkJob where j.JobId == bj.JobId && bj.CandidateId == candidateJobCategoryBodyModel.CandidateId select bj.IsBookmark).FirstOrDefault(),
                                                                     BookmarkId = (from bj in _sqlServerContext.BookmarkJob where j.JobId == bj.JobId && bj.CandidateId == candidateJobCategoryBodyModel.CandidateId select bj.BookmarkId).FirstOrDefault(),

                                                                 }).Distinct();
                return await data.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        
        public async Task<BookmarkJob> AddBookmarkJob(BookmarkJob bookmarkJob)
        {
            try
            {
                var entity = await _sqlServerContext.BookmarkJob.FirstOrDefaultAsync(item => item.CandidateId == bookmarkJob.CandidateId && item.JobId == bookmarkJob.JobId);
                if (entity == null)
                {

                    await _sqlServerContext.BookmarkJob.AddAsync(bookmarkJob);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    if(entity.IsBookmark==false)
                    {
                        entity.IsBookmark = true;

                        _sqlServerContext.BookmarkJob.Update(entity);
                        await _sqlServerContext.SaveChangesAsync();

                        bookmarkJob.CandidateId = entity.CandidateId;
                        bookmarkJob.JobId = entity.JobId;
                        bookmarkJob.IsBookmark = entity.IsBookmark;
                        bookmarkJob.BookmarkId = entity.BookmarkId;
                    }
                    else
                    {
                        bookmarkJob.BookmarkId = 0;
                        bookmarkJob.CandidateId = 0;
                        bookmarkJob.JobId = 0;
                        bookmarkJob.IsBookmark = false;
                    }

                    

                }
                return bookmarkJob;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<BookmarkJob> UpdateBookmarkJob(BookmarkJob bookmarkJob)
        {
            try
            {
                var entity = await _sqlServerContext.BookmarkJob.FirstOrDefaultAsync(item => item.BookmarkId == bookmarkJob.BookmarkId);
                if (entity != null)
                {
                    entity.CandidateId = bookmarkJob.CandidateId;
                    entity.JobId = bookmarkJob.JobId;
                    entity.IsBookmark = bookmarkJob.IsBookmark;

                    _sqlServerContext.BookmarkJob.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();

                    bookmarkJob.CandidateId = entity.CandidateId;
                    bookmarkJob.JobId = entity.JobId;
                    bookmarkJob.IsBookmark = entity.IsBookmark;
                    bookmarkJob.BookmarkId = entity.BookmarkId;
                }
                else
                {
                    bookmarkJob.BookmarkId = 0;
                    bookmarkJob.CandidateId = 0;
                    bookmarkJob.JobId = 0;
                    bookmarkJob.IsBookmark = false;

                }
                return bookmarkJob;
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

                IQueryable<CandidateBookmarkJobSummaryViewModel> data = (from j in _sqlServerContext.Jobs
                                                                         join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                                                                         join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                                                                         join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId
                                                                         join b in _sqlServerContext.BookmarkJob on j.JobId equals b.JobId
                                                                         where j.IsActive == true && b.CandidateId == candidateBookmarkJobBodyModel.CandidateId
                                                                         && b.IsBookmark == true
                                                                         orderby b.BookmarkId descending
                                                                         select new CandidateBookmarkJobSummaryViewModel
                                                                         {
                                                                             JobId = j.JobId,
                                                                             JobTitle = j.JobTitle,
                                                                             CompanyId = j.CompanyId,
                                                                             CompanyName = c.CompanyName,
                                                                             JobCategoryId = j.JobCategoryId,
                                                                             JobCategoryName = jc.JobCategoryName,
                                                                             MaxSalary = j.MaxSalary,
                                                                             MinSalary = j.MinSalary,
                                                                             SeniorityLevel = j.SeniorityLevel,
                                                                             JobStatus = j.JobStatus,
                                                                             JobLocationId = j.JobLocation,
                                                                             JobLocationName = d.DistrictName,
                                                                             PublishedDate = j.PublishedDate,
                                                                             IsBookmark = b.IsBookmark,
                                                                             CandidateId = b.CandidateId,
                                                                             BookmarkId= b.BookmarkId
                                                                         });
                return await data.ToListAsync();
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
                IQueryable<JobDetailsViewModel> data = (from j in _sqlServerContext.Jobs
                                                        join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                                                        join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId
                                                        join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                                                        where j.JobId == jobId && j.IsActive == true
                                                        select new JobDetailsViewModel
                                                        {
                                                            JobId = j.JobId,
                                                            JobTitle = j.JobTitle,
                                                            JobLocationId = j.JobLocation,
                                                            JobLocation = d.DistrictName,
                                                            JobCategoryId = j.JobCategoryId,
                                                            JobCategory = jc.JobCategoryName,
                                                            JobStatus = j.JobStatus,
                                                            SeniorityLevel = j.SeniorityLevel,
                                                            MaxSalary = j.MaxSalary,
                                                            MinSalary = j.MinSalary,
                                                            ExpiredDate = j.ExpiredDate,
                                                            JobStartingDate = j.JobStartingDate,
                                                            JobOverview = j.JobOverview,
                                                            JobResponsibilities = j.Responsibilities,
                                                            CompanyId = j.CompanyId,
                                                            BusinessCategory = c.BusinessCategory,
                                                            BusinessDescription = c.BusinessDescription,
                                                            CompanyName = c.CompanyName,
                                                            YearOfExperiance = j.YearOfExperience,
                                                            JobQualifications = (from q in _sqlServerContext.Qualifications
                                                                                 join dl in _sqlServerContext.DegreeLevel on q.DegreeLevelId equals dl.DegreeLevelId
                                                                                 join d in _sqlServerContext.Degree on q.DegreeId equals d.DegreeId
                                                                                 where q.JobId == jobId
                                                                                 select new JobQualificationViewModel
                                                                                 {
                                                                                     JobQualificationId = q.JobQualificationId,
                                                                                     JobId = q.JobId,
                                                                                     DegreeLevelId = q.DegreeLevelId,
                                                                                     DegreeLevelName = dl.DegreeLevelName,
                                                                                     DegreeId = q.DegreeId,
                                                                                     DegreeName = d.DegreeName,
                                                                                 }).Distinct(),
                                                            JobSkills = (from js in _sqlServerContext.JobSkills
                                                                         join s in _sqlServerContext.Skills on js.SkillId equals s.SkillId
                                                                         where js.JobId == jobId
                                                                         select new JobSkillsViewModel
                                                                         {
                                                                             JobSkillId = js.JobSkillId,
                                                                             JobId = js.JobId,
                                                                             SkillCategoryId = js.SkillCategoryId,
                                                                             SkillId = js.SkillId,
                                                                             SkillName = s.SkillName,
                                                                         }).Distinct()
                                                        });
                return await data.FirstOrDefaultAsync();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<JobQuestionsViewModel> GetJobWiseQuestions(int jobId)
        {
            try
            {
                IQueryable<JobQuestionsViewModel> data = (from j in _sqlServerContext.Jobs
                                                        where j.JobId == jobId
                                                        select new JobQuestionsViewModel
                                                        {
                                                            JobId=j.JobId,
                                                            TotalScore=j.TotalScore,
                                                            JobQuestionBank=(from gq in _sqlServerContext.GamificationQuestions
                                                                             join qb in _sqlServerContext.QuestionBank on gq.QuestionId equals qb.QuestionId
                                                                             group qb by qb.QuestionId into questions
                                                                             select new JobQuestionBankViewModel
                                                                             {
                                                                                 QuestionId= questions.Key,
                                                                                 Question= (from q in questions select q.Question).FirstOrDefault(),
                                                                                 Point = (from q in questions select q.Point).FirstOrDefault(),
                                                                                 TimeLimit = (from q in questions select q.TimeLimit).FirstOrDefault(),
                                                                                 QuestionDetails=(from q in questions
                                                                                                  join qd in _sqlServerContext.QuestionDetails on q.QuestionId equals qd.QuestionId
                                                                                                  group qd by qd.QuestionDetailsId into answerBank
                                                                                                  select new QuestionDetails {
                                                                                                      QuestionDetailsId = answerBank.Key,
                                                                                                      QuestionId = (from a in answerBank select a.QuestionId).FirstOrDefault(),
                                                                                                      OptionValue = (from a in answerBank select a.OptionValue).FirstOrDefault(),
                                                                                                      IsCorrectAnswer = (from a in answerBank select a.IsCorrectAnswer).FirstOrDefault()
                                                                                                  })
                                                                             })
                                                        });
                return await data.FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<AppliedJobs> AddCandidateApplyingJob(AppliedJobs appliedJob, IEnumerable<AnswerSheet> answerSheets)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var answers =new List<AnswerSheet>();

                    var entity = await _sqlServerContext.AppliedJob.FirstOrDefaultAsync(i => i.JobId == appliedJob.JobId && i.CandidateId==appliedJob.CandidateId && i.CompanyId==appliedJob.CompanyId);
                    if(entity == null)
                    {
                        await _sqlServerContext.AppliedJob.AddAsync(appliedJob);
                        await _sqlServerContext.SaveChangesAsync();

                        if(appliedJob.ApplicationId>0)
                        {
                            if(answerSheets !=null)
                            {
                                foreach(var a in answerSheets)
                                {
                                    var answer = new AnswerSheet
                                    {
                                        AnswerId = 0,
                                        ApplicationId = appliedJob.ApplicationId,
                                        QuestionId = a.QuestionId,
                                        Answer = a.Answer,
                                        QuestionDetailsId = a.QuestionDetailsId,
                                        CompanyId = a.CompanyId,
                                        CandidateId = a.CandidateId,
                                        IsSubmittedAnswer = a.IsSubmittedAnswer
                                    };
                                    answers.Add(answer);
                                }

                                await _sqlServerContext.AnswerSheet.AddRangeAsync(answers);
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
                    transaction.Commit();
                    return appliedJob;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
              
        }

        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateAppliedJobsSummary(int candidateId)
        {
            try
            {

                var data = (from j in _sqlServerContext.Jobs
                            join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                            join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                            join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId
                            join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                            where aj.CandidateId == candidateId
                            orderby aj.AppliedDate descending
                            select new CandidateJobSummaryViewModel
                            {
                                JobId = j.JobId,
                                JobTitle = j.JobTitle,
                                CompanyId = j.CompanyId,
                                CompanyName = c.CompanyName,
                                JobCategoryId = j.JobCategoryId,
                                JobCategoryName = jc.JobCategoryName,
                                MaxSalary = j.MaxSalary,
                                MinSalary = j.MinSalary,
                                SeniorityLevel = j.SeniorityLevel,
                                JobStatus = j.JobStatus,
                                JobLocationId = j.JobLocation,
                                JobLocationName = d.DistrictName,
                                PublishedDate = (j.PublishedDate == null ? DateTime.Now : j.PublishedDate),
                                StatusId = aj.StatusId,
                                AppliedDate = aj.AppliedDate

                            });
                return await data.ToListAsync();
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

                IQueryable<CandidateJobSummaryViewModel> data = (from j in _sqlServerContext.Jobs
                                                                 join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                                                                 join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                                                                 join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId
                                                                 join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                                                                 where aj.CandidateId == candidateId && aj.StatusId==2 && aj.ScheduleDate>=DateTime.Now.Date
                                                                 orderby aj.AppliedDate ascending
                                                                 select new CandidateJobSummaryViewModel
                                                                 {
                                                                     JobId = j.JobId,
                                                                     JobTitle = j.JobTitle,
                                                                     CompanyId = j.CompanyId,
                                                                     CompanyName = c.CompanyName,
                                                                     JobCategoryId = j.JobCategoryId,
                                                                     JobCategoryName = jc.JobCategoryName,
                                                                     MaxSalary = j.MaxSalary,
                                                                     MinSalary = j.MinSalary,
                                                                     SeniorityLevel = j.SeniorityLevel,
                                                                     JobStatus = j.JobStatus,
                                                                     JobLocationId = j.JobLocation,
                                                                     JobLocationName = d.DistrictName,
                                                                     PublishedDate = j.PublishedDate,
                                                                     AppliedDate = aj.AppliedDate,
                                                                     ScheduleDate = aj.ScheduleDate

                                                                 });
                return await data.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateShortlistedJobsSummary(int candidateId)
        {
            try
            {

                IQueryable<CandidateJobSummaryViewModel> data = (from j in _sqlServerContext.Jobs
                                                                 join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                                                                 join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                                                                 join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                                                                 join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId
                                                                 where aj.CandidateId == candidateId && j.IsActive == true && aj.StatusId == 1
                                                                 orderby aj.AppliedDate ascending
                                                                 select new CandidateJobSummaryViewModel
                                                                 {
                                                                     JobId = j.JobId,
                                                                     JobTitle = j.JobTitle,
                                                                     CompanyId = j.CompanyId,
                                                                     CompanyName = c.CompanyName,
                                                                     JobCategoryId = j.JobCategoryId,
                                                                     JobCategoryName = jc.JobCategoryName,
                                                                     MaxSalary = j.MaxSalary,
                                                                     MinSalary = j.MinSalary,
                                                                     SeniorityLevel = j.SeniorityLevel,
                                                                     JobStatus = j.JobStatus,
                                                                     JobLocationId = j.JobLocation,
                                                                     JobLocationName = d.DistrictName,
                                                                     PublishedDate = j.PublishedDate,
                                                                     AppliedDate = aj.AppliedDate,
                                                                     ExpiredDate = j.ExpiredDate,

                                                                 });
                return await data.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<CandidateJobSummaryViewModel>> GetCandidateHiredJobsSummary(int candidateId)
        {
            try
            {

                IQueryable<CandidateJobSummaryViewModel> data = (from j in _sqlServerContext.Jobs
                                                                 join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                                                                 join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                                                                 join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                                                                 join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId
                                                                 where aj.CandidateId == candidateId && j.IsActive == true && aj.ScheduleDate >= DateTime.Now.Date && aj.StatusId == 3
                                                                 orderby aj.AppliedDate ascending
                                                                 select new CandidateJobSummaryViewModel
                                                                 {
                                                                     JobId = j.JobId,
                                                                     JobTitle = j.JobTitle,
                                                                     CompanyId = j.CompanyId,
                                                                     CompanyName = c.CompanyName,
                                                                     JobCategoryId = j.JobCategoryId,
                                                                     JobCategoryName = jc.JobCategoryName,
                                                                     MaxSalary = j.MaxSalary,
                                                                     MinSalary = j.MinSalary,
                                                                     SeniorityLevel = j.SeniorityLevel,
                                                                     JobStatus = j.JobStatus,
                                                                     JobLocationId = j.JobLocation,
                                                                     JobLocationName = d.DistrictName,
                                                                     PublishedDate = j.PublishedDate,
                                                                     AppliedDate = aj.AppliedDate,
                                                                     ExpiredDate = j.ExpiredDate,

                                                                 });
                return await data.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public int GetMatchJobCountOfCandidate(CandidateWellcomeBodyModel bodyModel)
        {
            var jobCount = _sqlServerContext.Jobs.Count(x => x.JobCategoryId.Equals(bodyModel.JobCategoryId) 
                                                        && x.PublishedDate.Year == DateTime.Now.Year
                                                        && x.PublishedDate.Month == DateTime.Now.Month
                                                        && x.PublishedDate.Day == DateTime.Now.Day);
            return jobCount;
        }

        public async Task<JobDetailsViewModel> GetAppliedJobDetails(AppliedJobDetailsBodyModel appliedJob)
        {
            try
            {
                IQueryable<JobDetailsViewModel> data = (from j in _sqlServerContext.Jobs
                                                        join jc in _sqlServerContext.JobCategory on j.JobCategoryId equals jc.JobCategoryId
                                                        join d in _sqlServerContext.District on j.JobLocation equals d.DistrictId
                                                        join c in _sqlServerContext.Companies on j.CompanyId equals c.CompanyId
                                                        join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId into applied
                                                        from x in applied.DefaultIfEmpty()
                                                        where j.JobId == appliedJob.JobId && j.IsActive == true && x.CandidateId== appliedJob.CandidateId
                                                        select new JobDetailsViewModel
                                                        {
                                                            JobId = j.JobId,
                                                            JobTitle = j.JobTitle,
                                                            JobLocationId = j.JobLocation,
                                                            JobLocation = d.DistrictName,
                                                            JobCategoryId = j.JobCategoryId,
                                                            JobCategory = jc.JobCategoryName,
                                                            JobStatus = j.JobStatus,
                                                            SeniorityLevel = j.SeniorityLevel,
                                                            MaxSalary = j.MaxSalary,
                                                            MinSalary = j.MinSalary,
                                                            ExpiredDate = j.ExpiredDate,
                                                            JobStartingDate = j.JobStartingDate,
                                                            JobOverview = j.JobOverview,
                                                            JobResponsibilities = j.Responsibilities,
                                                            CompanyId = j.CompanyId,
                                                            BusinessCategory = c.BusinessCategory,
                                                            BusinessDescription = c.BusinessDescription,
                                                            CompanyName = c.CompanyName,
                                                            YearOfExperiance = j.YearOfExperience,
                                                            CandidateId = (x == null ? 0 : x.CandidateId),
                                                            StatusId = (x == null ? 0 : x.StatusId),
                                                            ApplicationId = (x == null ? 0 : x.ApplicationId),
                                                            JobQualifications = (from q in _sqlServerContext.Qualifications
                                                                                 join dl in _sqlServerContext.DegreeLevel on q.DegreeLevelId equals dl.DegreeLevelId
                                                                                 join d in _sqlServerContext.Degree on q.DegreeId equals d.DegreeId
                                                                                 where q.JobId == appliedJob.JobId
                                                                                 select new JobQualificationViewModel
                                                                                 {
                                                                                     JobQualificationId = q.JobQualificationId,
                                                                                     JobId = q.JobId,
                                                                                     DegreeLevelId = q.DegreeLevelId,
                                                                                     DegreeLevelName = dl.DegreeLevelName,
                                                                                     DegreeId = q.DegreeId,
                                                                                     DegreeName = d.DegreeName,
                                                                                 }).Distinct(),
                                                            JobSkills = (from js in _sqlServerContext.JobSkills
                                                                         join s in _sqlServerContext.Skills on js.SkillId equals s.SkillId
                                                                         where js.JobId == appliedJob.JobId
                                                                         select new JobSkillsViewModel
                                                                         {
                                                                             JobSkillId = js.JobSkillId,
                                                                             JobId = js.JobId,
                                                                             SkillCategoryId = js.SkillCategoryId,
                                                                             SkillId = js.SkillId,
                                                                             SkillName = s.SkillName,
                                                                         }).Distinct()
                                                        });
                return await data.FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}
