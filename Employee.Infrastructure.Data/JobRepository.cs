using Candidate.Domain.Entities.DataModel;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Employee.Domain.Entities.BodyModel;
using Employee.Domain.Entities.DataModel;
using Employee.Domain.Entities.ViewModel;
using Employee.Domain.Interfaces;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Data
{
    public class JobRepository : IJobRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public JobRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<TemporaryJobFirstStage> AddTemporaryJobFirstStage(TemporaryJobFirstStage temporaryJobFirstStage)
        {
            try
            {

                await _sqlServerContext.TemporaryJobFirstStage.AddAsync(temporaryJobFirstStage);
                await _sqlServerContext.SaveChangesAsync();

                return temporaryJobFirstStage;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<TemporaryJobFirstStage> GetTemporaryJobFirstStage(int companyId)
        {
            try
            {

                IQueryable<TemporaryJobFirstStage> data = _sqlServerContext.TemporaryJobFirstStage.Where(d => d.CompanyId == companyId)
                                                                                                .OrderByDescending(d => d.TempJobId)
                                                                                                .GroupBy(d => d.TempJobId)
                                                                                                .Select(r => new TemporaryJobFirstStage
                                                                                                {
                                                                                                    TempJobId = r.Key,
                                                                                                    CompanyId = r.Select(f => f.CompanyId).FirstOrDefault(),
                                                                                                    JobTitle = r.Select(f => f.JobTitle).FirstOrDefault(),
                                                                                                    JobCategoryId = r.Select(f => f.JobCategoryId).FirstOrDefault(),
                                                                                                    JobOverview = r.Select(f => f.JobOverview).FirstOrDefault(),
                                                                                                    JobRequirements = r.Select(f => f.JobRequirements).FirstOrDefault(),
                                                                                                    Benefits = r.Select(f => f.Benefits).FirstOrDefault(),
                                                                                                    Closing = r.Select(f => f.Closing).FirstOrDefault(),
                                                                                                    MaxSalary = r.Select(f => f.MaxSalary).FirstOrDefault(),
                                                                                                    MinSalary = r.Select(f => f.MinSalary).FirstOrDefault(),
                                                                                                    JobStatus = r.Select(f => f.JobStatus).FirstOrDefault(),
                                                                                                    SeniorityLevel = r.Select(f => f.SeniorityLevel).FirstOrDefault(),
                                                                                                    YearsOfExperience = r.Select(f => f.YearsOfExperience).FirstOrDefault(),
                                                                                                    DistrictId = r.Select(f => f.DistrictId).FirstOrDefault(),
                                                                                                    PostalCode = r.Select(f => f.PostalCode).FirstOrDefault(),
                                                                                                    SubmissionDeadline = r.Select(f => f.SubmissionDeadline).FirstOrDefault(),
                                                                                                    JobStartingDate = r.Select(f => f.JobStartingDate).FirstOrDefault(),
                                                                                                    PerMonthYear = r.Select(f => f.PerMonthYear).FirstOrDefault(),

                                                                                                }).Take(1);
                return await data.FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public async Task<TemporaryJobFirstStage> UpdateTemporaryJobFirstStage(TemporaryJobFirstStage temporaryJobFirstStage)
        {
            try
            {
                var entity = await _sqlServerContext.TemporaryJobFirstStage.FirstOrDefaultAsync(x => x.TempJobId == temporaryJobFirstStage.TempJobId );
                if (entity != null)
                {
                    entity.TempJobId = temporaryJobFirstStage.TempJobId;
                    entity.CompanyId = temporaryJobFirstStage.CompanyId;
                    entity.JobTitle = temporaryJobFirstStage.JobTitle;
                    entity.JobCategoryId = temporaryJobFirstStage.JobCategoryId;
                    entity.JobOverview = temporaryJobFirstStage.JobOverview;
                    entity.JobRequirements = temporaryJobFirstStage.JobRequirements;
                    entity.Benefits = temporaryJobFirstStage.Benefits;
                    entity.Closing = temporaryJobFirstStage.Closing;
                    entity.MaxSalary = temporaryJobFirstStage.MaxSalary;
                    entity.MinSalary = temporaryJobFirstStage.MinSalary;
                    entity.JobStatus = temporaryJobFirstStage.JobStatus;
                    entity.SeniorityLevel = temporaryJobFirstStage.SeniorityLevel;
                    entity.YearsOfExperience = temporaryJobFirstStage.YearsOfExperience;
                    entity.DistrictId = temporaryJobFirstStage.DistrictId;
                    entity.PostalCode = temporaryJobFirstStage.PostalCode;
                    entity.SubmissionDeadline = temporaryJobFirstStage.SubmissionDeadline;
                    entity.JobStartingDate = temporaryJobFirstStage.JobStartingDate;
                    entity.PerMonthYear = temporaryJobFirstStage.PerMonthYear;

                    _sqlServerContext.TemporaryJobFirstStage.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task <IEnumerable<TemporaryJobFirstStage>> GetTemporaryJobFirstStageList(int companyId)
        {
            try
            {

                var data =await _sqlServerContext.TemporaryJobFirstStage.Where(d => d.CompanyId == companyId)
                                                                                                .OrderByDescending(d => d.TempJobId)
                                                                                                .Select(r => new TemporaryJobFirstStage
                                                                                                {
                                                                                                    TempJobId =r.TempJobId,
                                                                                                    CompanyId = r.CompanyId,
                                                                                                    JobTitle = r.JobTitle,
                                                                                                    JobCategoryId = r.JobCategoryId,
                                                                                                    JobOverview = r.JobOverview,
                                                                                                    JobRequirements = r.JobRequirements,
                                                                                                    Benefits = r.Benefits,
                                                                                                    Closing = r.Closing,
                                                                                                    MaxSalary = r.MaxSalary,
                                                                                                    MinSalary = r.MinSalary,
                                                                                                    JobStatus = r.JobStatus,
                                                                                                    SeniorityLevel = r.SeniorityLevel,
                                                                                                    YearsOfExperience = r.YearsOfExperience,
                                                                                                    DistrictId = r.DistrictId,
                                                                                                    PostalCode = r.PostalCode,
                                                                                                    SubmissionDeadline = r.SubmissionDeadline,
                                                                                                    JobStartingDate = r.JobStartingDate,
                                                                                                    PerMonthYear = r.PerMonthYear

                                                                                                }).ToArrayAsync();
                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public async Task<JobSecondStageBodyModel> AddTemporaryJobSecondtStage(TempJobSecondStage tempJobSecondStage, IEnumerable<TempSkill> tempSkills, IEnumerable<TempDegree> tempDegrees, IEnumerable<TempGender> tempGenders)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var jobSecondStageBodyModel = new JobSecondStageBodyModel();

                    await _sqlServerContext.TempJobSecondStage.AddAsync(tempJobSecondStage);
                    await _sqlServerContext.SaveChangesAsync();
                    if (tempJobSecondStage.JobSecondStageId > 0)
                    {
                        await _sqlServerContext.TempSkill.AddRangeAsync(tempSkills);
                        await _sqlServerContext.SaveChangesAsync();

                        await _sqlServerContext.TempDegree.AddRangeAsync(tempDegrees);
                        await _sqlServerContext.SaveChangesAsync();

                        await _sqlServerContext.TempGender.AddRangeAsync(tempGenders);
                        await _sqlServerContext.SaveChangesAsync();


                        jobSecondStageBodyModel.JobSecondStageId = tempJobSecondStage.JobSecondStageId;
                        jobSecondStageBodyModel.TempJobId = tempJobSecondStage.TempJobId;
                        jobSecondStageBodyModel.MaxAge = tempJobSecondStage.MaxAge;
                        jobSecondStageBodyModel.MinAge = tempJobSecondStage.MinAge;
                        jobSecondStageBodyModel.PreferredLanguage = tempJobSecondStage.PreferredLanguage;
                        jobSecondStageBodyModel.PreferredInstitution = tempJobSecondStage.PreferredInstitution;
                        jobSecondStageBodyModel.ProfessionalCertification = tempJobSecondStage.ProfessionalCertification;
                        jobSecondStageBodyModel.TempSkills = tempSkills;
                        jobSecondStageBodyModel.TempDegrees = tempDegrees;
                        jobSecondStageBodyModel.TempGenders = tempGenders;


                    }
                    else
                    {
                        transaction.Rollback();
                    }

                    transaction.Commit();
                    return jobSecondStageBodyModel;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }

        public async Task<JobSecondStageBodyModel> GetJobSecondStage(int tempJobId)
        {
            try
            {
                IQueryable<JobSecondStageBodyModel> data = (from js in _sqlServerContext.TempJobSecondStage
                                                            orderby js.JobSecondStageId descending
                                                            where js.TempJobId == tempJobId
                                                            group js by js.JobSecondStageId into tempJob
                                                            select new JobSecondStageBodyModel
                                                            {
                                                                JobSecondStageId = tempJob.Key,
                                                                TempJobId = (from a in tempJob select a.TempJobId).FirstOrDefault(),
                                                                MaxAge = (from a in tempJob select a.MaxAge).FirstOrDefault(),
                                                                MinAge = (from a in tempJob select a.MinAge).FirstOrDefault(),
                                                                PreferredLanguage = (from a in tempJob select a.PreferredLanguage).FirstOrDefault(),
                                                                PreferredInstitution = (from a in tempJob select a.PreferredInstitution).FirstOrDefault(),
                                                                ProfessionalCertification = (from a in tempJob select a.ProfessionalCertification).FirstOrDefault(),
                                                                TempSkills = (from ts in _sqlServerContext.TempSkill
                                                                              where ts.TempJobId == tempJobId
                                                                              group ts by ts.TempSkillId into tempSkill
                                                                              select new TempSkill
                                                                              {
                                                                                  TempSkillId = tempSkill.Key,
                                                                                  TempJobId = (from a in tempSkill select a.TempJobId).FirstOrDefault(),
                                                                                  SkillCategoryId = (from a in tempSkill select a.SkillCategoryId).FirstOrDefault(),
                                                                                  SkillId = (from a in tempSkill select a.SkillId).FirstOrDefault()
                                                                              }),
                                                                TempDegrees = (from td in _sqlServerContext.TempDegree
                                                                               where td.TempJobId == tempJobId
                                                                               group td by td.TempDegreeId into tempDegree
                                                                               select new TempDegree
                                                                               {
                                                                                   TempDegreeId = tempDegree.Key,
                                                                                   TempJobId = (from a in tempDegree select a.TempJobId).FirstOrDefault(),
                                                                                   DegreeLevelId = (from a in tempDegree select a.DegreeLevelId).FirstOrDefault(),
                                                                                   DegreeId = (from a in tempDegree select a.DegreeId).FirstOrDefault(),
                                                                               }),
                                                                TempGenders = (from tg in _sqlServerContext.TempGender
                                                                               where tg.TempJobId == tempJobId
                                                                               group tg by tg.TempGenderId into tempGender
                                                                               select new TempGender
                                                                               {
                                                                                   TempGenderId = tempGender.Key,
                                                                                   TempJobId = (from a in tempGender select a.TempJobId).FirstOrDefault(),
                                                                                   GenderValue = (from a in tempGender select a.GenderValue).FirstOrDefault(),
                                                                               })
                                                            });
                return await data.FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<JobThirdStageBodyModel> AddTemporaryJobThirdtStage(TempQuestionScoring tempQuestionScoring, IEnumerable<TempQuestion> tempQuestions)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var jobThirdStageBodyModel = new JobThirdStageBodyModel();

                    await _sqlServerContext.TempQuestionScoring.AddAsync(tempQuestionScoring);
                    await _sqlServerContext.SaveChangesAsync();

                    if (tempQuestionScoring.ScoreId > 0)
                    {
                        await _sqlServerContext.TempQuestion.AddRangeAsync(tempQuestions);
                        await _sqlServerContext.SaveChangesAsync();

                        jobThirdStageBodyModel.ScoreId = tempQuestionScoring.ScoreId;
                        jobThirdStageBodyModel.TempJobId = tempQuestionScoring.TempJobId;
                        jobThirdStageBodyModel.TotalScore = tempQuestionScoring.TotalScore;
                        jobThirdStageBodyModel.PassingScore = tempQuestionScoring.PassingScore;
                        jobThirdStageBodyModel.IsAcceptPassingScore = tempQuestionScoring.IsAcceptPassingScore;
                        jobThirdStageBodyModel.tempQuestions = tempQuestions;
                    }
                    else
                    {
                        transaction.Rollback();
                    }

                    transaction.Commit();
                    return jobThirdStageBodyModel;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }

        public async Task<JobThirdStageViewModel> GetJobThirdStage(int tempJobId)
        {
            try
            {
                IQueryable<JobThirdStageViewModel> data = (from js in _sqlServerContext.TempQuestionScoring
                                                           orderby js.ScoreId descending
                                                           where js.TempJobId == tempJobId
                                                           group js by js.ScoreId into tempJob
                                                           select new JobThirdStageViewModel
                                                           {
                                                               ScoreId = tempJob.Key,
                                                               TempJobId = (from a in tempJob select a.TempJobId).FirstOrDefault(),
                                                               TotalScore = (from a in tempJob select a.TotalScore).FirstOrDefault(),
                                                               PassingScore = (from a in tempJob select a.PassingScore).FirstOrDefault(),
                                                               IsAcceptPassingScore = (from a in tempJob select a.IsAcceptPassingScore).FirstOrDefault(),
                                                               QuestionCategories = (from tq in _sqlServerContext.TempQuestion
                                                                                     join qc in _sqlServerContext.QuestionCategory on tq.CategoryId equals qc.QuestionCategoryId
                                                                                     where tq.TempJobId == tempJobId
                                                                                     select new QuestionCategory
                                                                                     {
                                                                                         QuestionCategoryId = qc.QuestionCategoryId,
                                                                                         QuestionCategoryName = qc.QuestionCategoryName
                                                                                     }).Distinct(),
                                                               QuestionBanks = (from tq in _sqlServerContext.TempQuestion
                                                                                join q in _sqlServerContext.QuestionBank on tq.QuestionId equals q.QuestionId
                                                                                where tq.TempJobId == tempJobId
                                                                                group q by q.QuestionId into questionBank
                                                                                select new QuestionBankBodyModel
                                                                                {
                                                                                    QuestionId = questionBank.Key,
                                                                                    QuestionCategoryId = (from o in questionBank select o.QuestionCategoryId).FirstOrDefault(),
                                                                                    Question = (from o in questionBank select o.Question).FirstOrDefault(),
                                                                                    Point = (from o in questionBank select o.Point).FirstOrDefault(),
                                                                                    TimeLimit = (from o in questionBank select o.TimeLimit).FirstOrDefault(),
                                                                                    QuestionDetails = (from q in questionBank
                                                                                                       join qd in _sqlServerContext.QuestionDetails
                                                                                                       on q.QuestionId equals qd.QuestionId
                                                                                                       group qd by qd.QuestionDetailsId into answerBank
                                                                                                       select new QuestionDetails
                                                                                                       {
                                                                                                           QuestionDetailsId = answerBank.Key,
                                                                                                           QuestionId = (from a in answerBank select a.QuestionId).FirstOrDefault(),
                                                                                                           OptionValue = (from a in answerBank select a.OptionValue).FirstOrDefault(),
                                                                                                           IsCorrectAnswer = (from a in answerBank select a.IsCorrectAnswer).FirstOrDefault(),
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

        public async Task<JobInsertViewModel> GetTemporaryJobInfo(JobBodyModel jobBodyModel)
        {
            try
            {
                IQueryable<JobInsertViewModel> response = (from tf in _sqlServerContext.TemporaryJobFirstStage
                                                           join ts in _sqlServerContext.TempJobSecondStage on tf.TempJobId equals ts.TempJobId
                                                           join tt in _sqlServerContext.TempQuestionScoring on tf.TempJobId equals tt.TempJobId
                                                           orderby tf.TempJobId descending
                                                           where tf.CompanyId == jobBodyModel.CompanyId && tf.TempJobId == tf.TempJobId
                                                           select new JobInsertViewModel
                                                           {
                                                               TempJobId = tf.TempJobId,
                                                               JobTitle = tf.JobTitle,
                                                               JobCategoryId = tf.JobCategoryId,
                                                               CompanyId = tf.CompanyId,
                                                               JobOverview = tf.JobOverview,
                                                               JobRequirements = tf.JobRequirements,
                                                               Benefits = tf.Benefits,
                                                               Closing = tf.Closing,
                                                               JobStatus = tf.JobStatus,
                                                               MaxSalary = tf.MaxSalary,
                                                               MinSalary = tf.MinSalary,
                                                               PerMonthYear = tf.PerMonthYear,
                                                               SeniorityLevel = tf.SeniorityLevel,
                                                               YearsOfExperience = tf.YearsOfExperience,
                                                               DistrictId = tf.DistrictId,
                                                               PostalCode = tf.PostalCode,
                                                               MaxAge = ts.MaxAge,
                                                               MinAge = ts.MinAge,
                                                               PreferredLanguage = ts.PreferredLanguage,
                                                               PreferredInstitution = ts.PreferredInstitution,
                                                               ProfessionalCertification = ts.ProfessionalCertification,
                                                               SubmissionDeadline = tf.SubmissionDeadline,
                                                               JobStartingDate = tf.JobStartingDate,
                                                               TotalScore = tt.TotalScore,
                                                               PassingScore = tt.PassingScore,
                                                               IsAcceptPassingScore = tt.IsAcceptPassingScore,

                                                               TempSkills = (from ts in _sqlServerContext.TempSkill
                                                                             where ts.TempJobId == jobBodyModel.TempJobId
                                                                             group ts by ts.TempSkillId into tempSkill
                                                                             select new TempSkill
                                                                             {
                                                                                 TempSkillId = tempSkill.Key,
                                                                                 TempJobId = (from a in tempSkill select a.TempJobId).FirstOrDefault(),
                                                                                 SkillCategoryId = (from a in tempSkill select a.SkillCategoryId).FirstOrDefault(),
                                                                                 SkillId = (from a in tempSkill select a.SkillId).FirstOrDefault()
                                                                             }),
                                                               TempDegrees = (from td in _sqlServerContext.TempDegree
                                                                              where td.TempJobId == jobBodyModel.TempJobId
                                                                              group td by td.TempDegreeId into tempDegree
                                                                              select new TempDegree
                                                                              {
                                                                                  TempDegreeId = tempDegree.Key,
                                                                                  TempJobId = (from a in tempDegree select a.TempJobId).FirstOrDefault(),
                                                                                  DegreeLevelId = (from a in tempDegree select a.DegreeLevelId).FirstOrDefault(),
                                                                                  DegreeId = (from a in tempDegree select a.DegreeId).FirstOrDefault(),
                                                                              }),
                                                               TempGenders = (from tg in _sqlServerContext.TempGender
                                                                              where tg.TempJobId == jobBodyModel.TempJobId
                                                                              group tg by tg.TempGenderId into tempGender
                                                                              select new TempGender
                                                                              {
                                                                                  TempGenderId = tempGender.Key,
                                                                                  TempJobId = (from a in tempGender select a.TempJobId).FirstOrDefault(),
                                                                                  GenderValue = (from a in tempGender select a.GenderValue).FirstOrDefault(),
                                                                              }),
                                                               TempQuestions = (from tq in _sqlServerContext.TempQuestion
                                                                                where tq.TempJobId == jobBodyModel.TempJobId
                                                                                group tq by tq.TempQuestionId into tempQuestion
                                                                                select new TempQuestion
                                                                                {
                                                                                    TempQuestionId = tempQuestion.Key,
                                                                                    TempJobId = (from a in tempQuestion select a.TempJobId).FirstOrDefault(),
                                                                                    QuestionId = (from a in tempQuestion select a.QuestionId).FirstOrDefault(),
                                                                                    CategoryId = (from a in tempQuestion select a.QuestionId).FirstOrDefault(),
                                                                                })
                                                           });
                return await response.FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Jobs> AddJob(Jobs job, IEnumerable<JobSkills> jobSkills, IEnumerable<GamificationQuestions> questions, IEnumerable<Gender> gender, IEnumerable<Qualifications> qualifications, int deleteId)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {

                    var skills = new List<JobSkills>();
                    var question = new List<GamificationQuestions>();
                    var genders = new List<Gender>();
                    var degrees = new List<Qualifications>();

                    await _sqlServerContext.Jobs.AddAsync(job);
                    await _sqlServerContext.SaveChangesAsync();

                    if (job.JobId > 0)
                    {

                        if (jobSkills != null)
                        {
                            foreach (var s in jobSkills)
                            {
                                var skill = new JobSkills
                                {
                                    JobSkillId = 0,
                                    JobId = job.JobId,
                                    SkillId = s.SkillId,
                                    SkillCategoryId = s.SkillCategoryId
                                };
                                skills.Add(skill);
                            }
                        }
                        if (questions != null)
                        {
                            foreach (var q in questions)
                            {
                                var ques = new GamificationQuestions
                                {
                                    JobQuestionId = 0,
                                    JobId = job.JobId,
                                    QuestionId = q.QuestionId
                                };
                                question.Add(ques);
                            }

                        }
                        if (genders != null)
                        {
                            foreach (var g in genders)
                            {
                                var gen = new Gender
                                {
                                    GenderId = 0,
                                    JobId = job.JobId,
                                    GenderValue = g.GenderValue
                                };
                                genders.Add(gen);
                            }
                        }
                        if (qualifications != null)
                        {
                            foreach (var d in qualifications)
                            {
                                var degree = new Qualifications
                                {
                                    JobQualificationId = 0,
                                    JobId = job.JobId,
                                    DegreeLevelId = d.DegreeLevelId,
                                    DegreeId = d.DegreeId
                                };
                                degrees.Add(degree);
                            }
                        }



                        var firstData = _sqlServerContext.TemporaryJobFirstStage.Where(f => f.TempJobId == deleteId).ToList();
                        var secondData = _sqlServerContext.TempJobSecondStage.Where(f => f.TempJobId == deleteId).ToList();
                        var tempquestion = _sqlServerContext.TempQuestionScoring.Where(f => f.TempJobId == deleteId).ToList();

                        //delete data
                        _sqlServerContext.TemporaryJobFirstStage.RemoveRange(firstData);
                        await _sqlServerContext.SaveChangesAsync();

                        _sqlServerContext.TempJobSecondStage.RemoveRange(secondData);
                        await _sqlServerContext.SaveChangesAsync();


                        _sqlServerContext.TempQuestionScoring.RemoveRange(tempquestion);
                        await _sqlServerContext.SaveChangesAsync();


                        //skill

                        await _sqlServerContext.JobSkills.AddRangeAsync(skills);
                        await _sqlServerContext.SaveChangesAsync();

                        var tempSkill = _sqlServerContext.TempSkill.Where(f => f.TempJobId == deleteId).ToList();
                        _sqlServerContext.TempSkill.RemoveRange(tempSkill);
                        await _sqlServerContext.SaveChangesAsync();


                        //Question
                        await _sqlServerContext.GamificationQuestions.AddRangeAsync(question);
                        await _sqlServerContext.SaveChangesAsync();

                        var tempQuestion = _sqlServerContext.TempQuestion.Where(f => f.TempJobId == deleteId).ToList();
                        _sqlServerContext.TempQuestion.RemoveRange(tempQuestion);
                        await _sqlServerContext.SaveChangesAsync();

                        //gender
                        await _sqlServerContext.Gender.AddRangeAsync(genders);
                        await _sqlServerContext.SaveChangesAsync();

                        var tempGender = _sqlServerContext.TempGender.Where(f => f.TempJobId == deleteId).ToList();
                        _sqlServerContext.TempGender.RemoveRange(tempGender);
                        await _sqlServerContext.SaveChangesAsync();

                        //degree
                        await _sqlServerContext.Qualifications.AddRangeAsync(degrees);
                        await _sqlServerContext.SaveChangesAsync();

                        var tempDegree = _sqlServerContext.TempDegree.Where(f => f.TempJobId == deleteId).ToList();
                        _sqlServerContext.TempDegree.RemoveRange(tempDegree);
                        await _sqlServerContext.SaveChangesAsync();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                    transaction.Commit();
                    return job;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }

        public async Task<IEnumerable<JobSummaryViewModel>> GetCompanyJobsSummary(OrderByJobsBodyModel orderByJobs)
        {
            try
            {

                var data = await (from tf in _sqlServerContext.Jobs
                                  where tf.CompanyId == orderByJobs.CompanyId
                                  select new JobSummaryViewModel
                                  {
                                      JobId = tf.JobId,
                                      JobTitle = tf.JobTitle,
                                      CompanyId = tf.CompanyId,
                                      IsActive = (tf.IsActive == null ? false : tf.IsActive),
                                      PublishedDate = tf.PublishedDate,
                                      ExpiredDate = tf.ExpiredDate,
                                      ApprovalStatus = (tf.ApprovalStatus == null ? 0: tf.ApprovalStatus),
                                  }).ToListAsync();
                if (orderByJobs.IsActive > -1)
                {
                    if (orderByJobs.IsActive == 0)
                    {
                        data = data.Where(x => x.IsActive == false).ToList();
                    }
                    if (orderByJobs.IsActive == 1)
                    {
                        data = data.Where(x => x.IsActive == true && x.ExpiredDate >= DateTime.Now.Date).ToList();
                    }
                    if (orderByJobs.IsActive == 2)
                    {
                        data = data.Where(x => x.IsActive == true && x.ExpiredDate < DateTime.Now.Date).ToList();
                    }
                }

                switch (orderByJobs.OrderByStatus)
                {
                    case "descending":
                        data = data.OrderByDescending(s => s.JobId).ToList();
                        break;
                    case "orderby":
                        data = data.OrderBy(s => s.JobId).ToList();
                        break;
                }
                var result = JobWiseCandidateCount(data);

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private IEnumerable<JobSummaryViewModel> JobWiseCandidateCount(IEnumerable<JobSummaryViewModel> requestData)
        {

            //from p in context.ParentTable
            //join c in context.ChildTable on p.ParentId equals c.ChildParentId into j1
            //from j2 in j1.DefaultIfEmpty()
            //group j2 by p.ParentId into grouped
            //select new { ParentId = grouped.Key, Count = grouped.Count(t => t.ChildId != null) }
            var jobSummaryViewModel = new List<JobSummaryViewModel>();

            var data = (from j in requestData
                        join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                        
                        select new AppliedJobs
                        {
                            JobId = j.JobId,
                            CandidateId=aj.CandidateId
                        }).ToList();


            foreach(var j in requestData)
            {
                var candidateCount = data.Where(x => x.JobId == j.JobId).Count();
                var model = new JobSummaryViewModel
                {
                    JobId = j.JobId,
                    JobTitle = j.JobTitle,
                    CompanyId = j.CompanyId,
                    PublishedDate = j.PublishedDate,
                    ExpiredDate = j.ExpiredDate,
                    IsActive = j.IsActive,
                    ApprovalStatus = j.ApprovalStatus,
                    CandidateCount= candidateCount
                };
                jobSummaryViewModel.Add(model);


            }
            return jobSummaryViewModel;

        }

        public async Task<IEnumerable<ApplyedCandidateViewModel>> GetJobWiseAppliedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel)
        {
            try
            {
                IQueryable<ApplyedCandidateViewModel> response = (from j in _sqlServerContext.Jobs
                                                                  join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                                                                  join c in _sqlServerContext.Candidates on aj.CandidateId equals c.CandidateId
                                                                  where j.ExpiredDate >= DateTime.Now.Date && j.JobId == bodyModel.JobId && j.CompanyId == bodyModel.CompanyId
                                                                  && aj.StatusId == bodyModel.StatusId
                                                                  orderby aj.ApplicationId descending
                                                                  select new ApplyedCandidateViewModel
                                                                  {
                                                                      JobId = j.JobId,
                                                                      ApplicationId = aj.ApplicationId,
                                                                      CompanyId = aj.CompanyId,
                                                                      StatusId = aj.StatusId,
                                                                      JobTitle = j.JobTitle,
                                                                      TotalExamMarks = aj.TotalExamMarks,
                                                                      ObtainMarks = aj.ObtainMarks,
                                                                      MarkPercentage = aj.MarkPercentage,
                                                                      CandidateId = aj.CandidateId,
                                                                      CandidateName = c.CandidateName,
                                                                      AppliedDate = aj.AppliedDate,
                                                                      ScheduleDate = aj.ScheduleDate,
                                                                      IsProfileMatch = aj.IsProfileMatch,
                                                                      IsProfileView = aj.IsProfileView,
                                                                      ExpiredDate = j.ExpiredDate,
                                                                  });
                return await response.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<ApplyedCandidateViewModel>> GetCompanyWiseAppliedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel)
        {
            try
            {
                IQueryable<ApplyedCandidateViewModel> response = (from j in _sqlServerContext.Jobs
                                                                  join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                                                                  join c in _sqlServerContext.Candidates on aj.CandidateId equals c.CandidateId
                                                                  where j.CompanyId == bodyModel.CompanyId
                                                                  && aj.StatusId == bodyModel.StatusId && j.ExpiredDate >= DateTime.Now.Date
                                                                  orderby aj.ApplicationId descending
                                                                  select new ApplyedCandidateViewModel
                                                                  {
                                                                      JobId = j.JobId,
                                                                      ApplicationId = aj.ApplicationId,
                                                                      CompanyId = aj.CompanyId,
                                                                      StatusId = aj.StatusId,
                                                                      JobTitle = j.JobTitle,
                                                                      ExpiredDate = j.ExpiredDate,
                                                                      TotalExamMarks = aj.TotalExamMarks,
                                                                      ObtainMarks = aj.ObtainMarks,
                                                                      MarkPercentage = aj.MarkPercentage,
                                                                      CandidateId = aj.CandidateId,
                                                                      CandidateName = c.CandidateName,
                                                                      AppliedDate = aj.AppliedDate,
                                                                      ScheduleDate = aj.ScheduleDate,
                                                                  });
                return await response.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<ApplyedCandidateViewModel>> GetNewCandidateList(JobWiseAppliedCandidateBodyModel bodyModel)
        {
            try
            {
                IQueryable<ApplyedCandidateViewModel> response = (from j in _sqlServerContext.Jobs
                                                                  join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                                                                  join c in _sqlServerContext.Candidates on aj.CandidateId equals c.CandidateId
                                                                  where j.CompanyId == bodyModel.CompanyId && aj.StatusId == bodyModel.StatusId
                                                                  && aj.IsProfileView.Equals(false)
                                                                  orderby aj.ApplicationId descending
                                                                  select new ApplyedCandidateViewModel
                                                                  {
                                                                      JobId = j.JobId,
                                                                      JobTitle = j.JobTitle,
                                                                      TotalExamMarks = aj.TotalExamMarks,
                                                                      ObtainMarks = aj.ObtainMarks,
                                                                      MarkPercentage = aj.MarkPercentage,
                                                                      CandidateId = aj.CandidateId,
                                                                      StatusId = aj.StatusId,
                                                                      CandidateName = c.CandidateName,
                                                                      ApplicationId = aj.ApplicationId,
                                                                      CompanyId = aj.CompanyId,
                                                                      IsProfileMatch = aj.IsProfileMatch,
                                                                      IsProfileView = aj.IsProfileView,
                                                                      PublishedDate = j.PublishedDate,
                                                                      ExpiredDate = j.ExpiredDate,
                                                                      CandidateCount = (from ajs in _sqlServerContext.AppliedJob where j.JobId == ajs.JobId select ajs.CandidateId).Count(),
                                                                  });
                return await response.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<ApplyedCandidateViewModel>> GetShortListedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel)
        {
            try
            {
                IQueryable<ApplyedCandidateViewModel> data = (from j in _sqlServerContext.Jobs
                                                                  join aj in _sqlServerContext.AppliedJob on j.JobId equals aj.JobId
                                                                  join c in _sqlServerContext.Candidates on aj.CandidateId equals c.CandidateId
                                                                  where j.CompanyId == bodyModel.CompanyId && aj.StatusId == bodyModel.StatusId
                                                                  orderby aj.ApplicationId descending
                                                                  select new ApplyedCandidateViewModel
                                                                  {
                                                                      JobId = j.JobId,
                                                                      JobTitle = j.JobTitle,
                                                                      TotalExamMarks = aj.TotalExamMarks,
                                                                      ObtainMarks = aj.ObtainMarks,
                                                                      MarkPercentage = aj.MarkPercentage,
                                                                      CandidateId = aj.CandidateId,
                                                                      StatusId = aj.StatusId,
                                                                      CandidateName = c.CandidateName,
                                                                      ApplicationId = aj.ApplicationId,
                                                                      CompanyId = aj.CompanyId,
                                                                      IsProfileMatch = aj.IsProfileMatch,
                                                                      IsProfileView = aj.IsProfileView,
                                                                      PublishedDate = j.PublishedDate,
                                                                      ExpiredDate = j.ExpiredDate,
                                                                      CandidateCount = (from ajs in _sqlServerContext.AppliedJob where j.JobId == ajs.JobId select ajs.CandidateId).Count(),
                                                                  });
                return await data.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        

        public async Task<AppliedJobAssissmentViewModel> GetAppliedCandidateAssissmentDetails(CandidateAssessmentBodyModel bodyModel)
        {
            try
            {
                IQueryable<AppliedJobAssissmentViewModel> query = (from a in _sqlServerContext.AppliedJob
                                                                   where a.ApplicationId == bodyModel.ApplicationId && a.JobId == bodyModel.JobId
                                                                   && a.CandidateId == bodyModel.CandidateId && a.CompanyId == bodyModel.CompanyId
                                                                   select new AppliedJobAssissmentViewModel
                                                                   {
                                                                       ApplicationId = a.ApplicationId,
                                                                       CandidateId = a.CandidateId,
                                                                       CompanyId = a.CompanyId,
                                                                       JobId = a.JobId,
                                                                       TotalExamMarks = a.TotalExamMarks,
                                                                       ObtainMarks = a.ObtainMarks,
                                                                       //QuestionBank= (from gq in _sqlServerContext.GamificationQuestions
                                                                       //               join qb in _sqlServerContext.QuestionBank on gq.QuestionId equals qb.QuestionId
                                                                       //               where gq.JobId== bodyModel.JobId
                                                                       //               group qb by qb.QuestionId into questions
                                                                       //               select new SubmitQuestionBankViewModel
                                                                       //               {
                                                                       //                   QuestionId = questions.Key,
                                                                       //                   Question = (from q in questions select q.Question).FirstOrDefault(),
                                                                       //                   Point = (from q in questions select q.Point).FirstOrDefault(),
                                                                       //                   TimeLimit = (from q in questions select q.TimeLimit).FirstOrDefault(),
                                                                       //                   QuestionDetails = (from q in questions
                                                                       //                                      join qd in _sqlServerContext.QuestionDetails on q.QuestionId equals qd.QuestionId

                                                                       //                                      join sa in _sqlServerContext.AnswerSheet on q.QuestionId equals sa.QuestionId
                                                                       //                                      into answerGroup from answer in answerGroup.DefaultIfEmpty()

                                                                       //                                      group qd by qd.QuestionDetailsId into answerBank
                                                                       //                                      select new SubmitQuestionDetailsViewModel
                                                                       //                                      {
                                                                       //                                          QuestionDetailsId = answerBank.Key,
                                                                       //                                          QuestionId = (from ans in answerBank select ans.QuestionId).FirstOrDefault(),
                                                                       //                                          OptionValue = (from ans in answerBank select ans.OptionValue).FirstOrDefault(),
                                                                       //                                          IsCorrectAnswer = (from ans in answerBank select ans.IsCorrectAnswer).FirstOrDefault()
                                                                       //                                          //IsSelectedOption = (from ans in answerBank select ans.IsSelectedOption).FirstOrDefault(),
                                                                       //                                          //IsSubmittedAnswer = (from ans in answerBank select ans.IsSubmittedAnswer).FirstOrDefault(),
                                                                       //                                      })
                                                                       //               })

                                                                   });

                var res = SetQuestionBank(bodyModel, query);
                return res;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private AppliedJobAssissmentViewModel SetQuestionBank(CandidateAssessmentBodyModel bodyModel, IEnumerable<AppliedJobAssissmentViewModel> assissmentViewModels)
        {
            var allQuestions = from gq in _sqlServerContext.GamificationQuestions
                               join qb in _sqlServerContext.QuestionBank on gq.QuestionId equals qb.QuestionId
                               where gq.JobId == bodyModel.JobId
                               group qb by qb.QuestionId into questions
                               select new SubmitQuestionBankViewModel
                               {
                                   QuestionId = questions.Key,
                                   Question = (from q in questions where q.QuestionId == questions.Key select q.Question).FirstOrDefault(),
                                   Point = (from q in questions where q.QuestionId == questions.Key select q.Point).FirstOrDefault(),
                                   TimeLimit = (from q in questions where q.QuestionId == questions.Key select q.TimeLimit).FirstOrDefault()
                               };
            var questionIds = allQuestions.Select(x => x.QuestionId).Distinct();
            var questionOptions = _sqlServerContext.QuestionDetails.Where(x => questionIds.Contains(x.QuestionId));
            var questionAnswers = _sqlServerContext.AnswerSheet.Where(x => questionIds.Contains(x.QuestionId) && x.CandidateId == bodyModel.CandidateId && x.ApplicationId == bodyModel.ApplicationId && x.CompanyId == bodyModel.CompanyId);
            var assissmentInfo = assissmentViewModels.FirstOrDefault();
            var questionbank = new List<SubmitQuestionBankViewModel>();
            foreach (var item in allQuestions)
            {
                var options = questionOptions.Where(x => x.QuestionId == item.QuestionId);
                var answers = questionAnswers.Where(x => x.QuestionId == item.QuestionId);
                var questionDetaisl = new List<SubmitQuestionDetailsViewModel>();
                foreach (var option in options)
                {
                    var details = new SubmitQuestionDetailsViewModel
                    {
                        QuestionDetailsId = option.QuestionDetailsId,
                        QuestionId = item.QuestionId,
                        OptionValue = option.OptionValue,
                        IsCorrectAnswer = option.IsCorrectAnswer,
                        IsSelectedOption = answers.FirstOrDefault(x => x.QuestionDetailsId == option.QuestionDetailsId) == null ? false : true,
                        IsSubmittedAnswer = answers.FirstOrDefault(x => x.QuestionDetailsId == option.QuestionDetailsId) == null ? false : answers.FirstOrDefault(x => x.QuestionDetailsId == option.QuestionDetailsId).IsSubmittedAnswer
                    };

                    questionDetaisl.Add(details);

                }

                var bank = new SubmitQuestionBankViewModel
                {
                    QuestionId = item.QuestionId,
                    Question = item.Question,
                    Point = item.Point,
                    TimeLimit = item.TimeLimit,
                    QuestionDetails = questionDetaisl
                };
                questionbank.Add(bank);
            }


            assissmentInfo.QuestionBank = questionbank;


            return assissmentInfo;

        }


        public async Task<CandidateScreeningViewModel> GetJobWiseCandidateScreening(CandidateAssessmentBodyModel bodyModel)
        {
            try
            {
                var query = (from a in _sqlServerContext.AppliedJob
                             join c in _sqlServerContext.Candidates on a.CandidateId equals c.CandidateId
                             join cat in _sqlServerContext.JobCategory on c.JobCategoryId equals cat.JobCategoryId
                             join job in _sqlServerContext.Jobs on a.JobId equals job.JobId
                             join jobcat in _sqlServerContext.JobCategory on job.JobCategoryId equals jobcat.JobCategoryId
                             where c.CandidateId == bodyModel.CandidateId && job.CompanyId == bodyModel.CompanyId
                             && a.ApplicationId == bodyModel.ApplicationId && a.JobId == bodyModel.JobId

                             select new CandidateScreeningViewModel
                             {
                                 CandidateJobCategoryId = c.JobCategoryId,
                                 CandidateJobCategoryName = cat.JobCategoryName,
                                 CompanyJobCategoryId = job.JobCategoryId,
                                 CompanyJobCategoryName = jobcat.JobCategoryName,
                                 JobYearOfExperience = job.YearOfExperience,
                                 MarkPercentage = a.MarkPercentage,
                                 JobSkills = (from js in _sqlServerContext.JobSkills
                                              join s in _sqlServerContext.Skills on js.SkillId equals s.SkillId
                                              where js.JobId == bodyModel.JobId
                                              select new Skills
                                              {
                                                  SkillId = s.SkillId,
                                                  SkillCategoryId = s.SkillCategoryId,
                                                  SkillName = s.SkillName
                                              }).Take(6),
                                 CandidateSkills = (from cs in _sqlServerContext.CandidateSkills
                                                    join s in _sqlServerContext.Skills
                                                    on cs.SkillId equals s.SkillId
                                                    where cs.CandidateId == bodyModel.CandidateId
                                                    select new Skills
                                                    {

                                                        SkillId = s.SkillId,
                                                        SkillName = s.SkillName
                                                    }).Take(6)

                             }).FirstOrDefaultAsync();
                return await query;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Status>> GetAllStatus()
        {
            try
            {
                var data = (from s in _sqlServerContext.Status
                            select new Status
                            {
                                StatusId = s.StatusId,
                                StatusName = s.StatusName
                            }).ToListAsync();
                return await data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public async Task<AppliedJobs> UpdateAppliedCandidateJobStatus(JobStatusChangeBodyModel bodyModel)
        {
            try
            {
                var entity = await _sqlServerContext.AppliedJob.FirstOrDefaultAsync(x => x.ApplicationId == bodyModel.ApplicationId && x.CandidateId == bodyModel.CandidateId && x.JobId == bodyModel.JobId);
                if (entity != null)
                {
                    entity.StatusId = bodyModel.StatusId;

                    _sqlServerContext.AppliedJob.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        



        public int GetCompanyWiseNotProfileViewCandidateCount(int companyId)
        {
            try
            {
                var candidateCount = _sqlServerContext.AppliedJob.Count(x => x.CompanyId == companyId && x.IsProfileView == false && x.IsProfileMatch==true);
                return candidateCount;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int GetCurrentDateOnlineInterviewCandidatesCount(int companyId)
        {
            try
            {
                int candidateCount = _sqlServerContext.AppliedJob.Count(x => x.CompanyId.Equals(companyId) 
                                                                        && x.ScheduleDate.Year == DateTime.Now.Year
                                                                        && x.ScheduleDate.Month == DateTime.Now.Month
                                                                        && x.ScheduleDate.Day == DateTime.Now.Day
                                                                        && x.StatusId == 2);


                return candidateCount;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<AppliedJobs> UpdateApplyedJobScheduleDate(JobScheduleBodyModel jobScheduleBodyModel)
        {
            try
            {
                var entity = await _sqlServerContext.AppliedJob.FirstOrDefaultAsync(x => x.ApplicationId == jobScheduleBodyModel.ApplicationId);
                if (entity != null)
                {
                    entity.ScheduleDate = jobScheduleBodyModel.ScheduleDate;

                    _sqlServerContext.AppliedJob.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<AppliedJobs> UpdateApplyedCandidateProfileView(ProfileViewBodyModel profileViewBodyModel)
        {
            try
            {
                var entity = await _sqlServerContext.AppliedJob.FirstOrDefaultAsync(x => x.ApplicationId == profileViewBodyModel.ApplicationId);
                if (entity != null)
                {
                    entity.IsProfileView = profileViewBodyModel.IsProfileView;

                    _sqlServerContext.AppliedJob.Update(entity);
                    await _sqlServerContext.SaveChangesAsync();
                }

                return entity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<JobSummaryViewModel>> GetStatusWiseCompanyJobsSummary(JobStatusBodyModel jobStatus)
        {
            try
            {

                IQueryable<JobSummaryViewModel> data = (from tf in _sqlServerContext.Jobs
                                                        where tf.CompanyId == jobStatus.CompanyId && tf.IsActive == jobStatus.IsActive && tf.ExpiredDate >= DateTime.Now.Date
                                                        orderby tf.JobId descending
                                                        select new JobSummaryViewModel
                                                        {
                                                            JobId = tf.JobId,
                                                            JobTitle = tf.JobTitle,
                                                            CompanyId = tf.CompanyId,
                                                            PublishedDate = tf.PublishedDate,
                                                            ExpiredDate = tf.ExpiredDate,
                                                        });
                var result = JobWiseCandidateCount(data);

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}
