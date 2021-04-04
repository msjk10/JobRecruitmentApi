using Candidate.Domain.Entities.DataModel;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data;
using Employee.Domain.Entities.BodyModel;
using Employee.Domain.Entities.DataModel;
using Employee.Domain.Entities.ViewModel;
using Employee.Domain.Interfaces;
using Employee.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Services
{
    public class JobService: IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        public JobService(IJobRepository jobRepository, IUserRepository userRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
        }

        public async Task<TemporaryJobFirstStage> AddTemporaryJobFirstStage(TemporaryJobFirstStage temporaryJobFirstStage)
        {
            try
            {
                return await _jobRepository.AddTemporaryJobFirstStage(temporaryJobFirstStage);
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
                return await _jobRepository.GetTemporaryJobFirstStage(companyId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<TemporaryJobFirstStage>> GetTemporaryJobFirstStageList(int companyId)
        {
            try
            {
                return await _jobRepository.GetTemporaryJobFirstStageList(companyId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }




        public async Task<JobSecondStageBodyModel> AddTemporaryJobSecondtStage(JobSecondStageBodyModel jobSecondStageBodyModel)
        {
            try
            {
                var tempJobSecondStage = new TempJobSecondStage();
                var tempSkill = new List<TempSkill>();
                var tempDegree = new List<TempDegree>();
                var tempGender = new List<TempGender>();

                if(jobSecondStageBodyModel !=null)
                {
                    tempJobSecondStage.JobSecondStageId = jobSecondStageBodyModel.JobSecondStageId;
                    tempJobSecondStage.TempJobId = jobSecondStageBodyModel.TempJobId;
                    tempJobSecondStage.MaxAge = jobSecondStageBodyModel.MaxAge;
                    tempJobSecondStage.MinAge = jobSecondStageBodyModel.MinAge;
                    tempJobSecondStage.PreferredLanguage = jobSecondStageBodyModel.PreferredLanguage;
                    tempJobSecondStage.PreferredInstitution = jobSecondStageBodyModel.PreferredInstitution;
                    tempJobSecondStage.ProfessionalCertification = jobSecondStageBodyModel.ProfessionalCertification;

                    if(jobSecondStageBodyModel.TempSkills !=null)
                    {
                        foreach(var s in jobSecondStageBodyModel.TempSkills)
                        {
                            tempSkill.Add(s);
                        }
                    }

                    if (jobSecondStageBodyModel.TempDegrees != null)
                    {
                        foreach (var d in jobSecondStageBodyModel.TempDegrees)
                        {
                            tempDegree.Add(d);
                        }
                    }

                    if (jobSecondStageBodyModel.TempGenders != null)
                    {
                        foreach (var g in jobSecondStageBodyModel.TempGenders)
                        {
                            tempGender.Add(g);
                        }
                    }
                }

                var data = await _jobRepository.AddTemporaryJobSecondtStage(tempJobSecondStage,tempSkill, tempDegree, tempGender);

                return data;


            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<JobSecondStageBodyModel> GetJobSecondStageAsync(int tempJobId)
        {
            try
            {
                return await _jobRepository.GetJobSecondStage(tempJobId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<JobThirdStageBodyModel> AddTemporaryJobThirdtStage(JobThirdStageBodyModel jobThirdStageBodyModel)
        {
            try
            {
                var tempQuestionScoring = new TempQuestionScoring();
                var tempQuestions = new List<TempQuestion>();

                if(jobThirdStageBodyModel != null)
                {
                    tempQuestionScoring.ScoreId = jobThirdStageBodyModel.ScoreId;
                    tempQuestionScoring.TempJobId = jobThirdStageBodyModel.TempJobId;
                    tempQuestionScoring.TotalScore = jobThirdStageBodyModel.TotalScore;
                    tempQuestionScoring.PassingScore = jobThirdStageBodyModel.PassingScore;
                    tempQuestionScoring.IsAcceptPassingScore = jobThirdStageBodyModel.IsAcceptPassingScore;

                    if(jobThirdStageBodyModel.tempQuestions !=null)
                    {
                        foreach(var q in jobThirdStageBodyModel.tempQuestions)
                        {
                            tempQuestions.Add(q);
                        }
                    }
                }
                var data = await _jobRepository.AddTemporaryJobThirdtStage(tempQuestionScoring, tempQuestions);
                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<JobThirdStageViewModel> GetJobThirdStage(int tempJobId)
        {
            try
            {
                return await _jobRepository.GetJobThirdStage(tempJobId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<Jobs> AddJob(JobBodyModel jobBodyModel)
        {
            try
            {
                var data = await _jobRepository.GetTemporaryJobInfo(jobBodyModel);

                var job = new Jobs();
                var skills = new List<JobSkills>();
                var question = new List<GamificationQuestions>();
                var genders = new List<Gender>();
                var degrees = new List<Qualifications>();
                int deleteId = data.TempJobId;

                if (data !=null)
                {
                    job.JobId = 0;
                    job.JobTitle = data.JobTitle;
                    job.JobCategoryId = data.JobCategoryId;
                    job.JobSubCategoryId = 0;
                    job.CompanyId = data.CompanyId;
                    job.JobOverview = data.JobOverview;
                    job.Responsibilities = data.JobRequirements;
                    job.Benifits = data.Benefits;
                    job.Closing = data.Closing;
                    job.JobStatus = data.JobStatus;
                    job.MaxSalary = data.MaxSalary;
                    job.MinSalary = data.MinSalary;
                    job.PerMonthYear = data.PerMonthYear;
                    job.SeniorityLevel = data.SeniorityLevel;
                    job.YearOfExperience = data.YearsOfExperience;
                    job.JobLocation = data.DistrictId;
                    job.PostalCode = data.PostalCode;
                    job.MaxAge = data.MaxAge;
                    job.MinAge = data.MinAge;
                    job.ApprovalStatus = 0;
                    job.PreferredLanguage = data.PreferredLanguage;
                    job.PreferredInstitute = data.PreferredInstitution;
                    job.ProfCertification = data.ProfessionalCertification;
                    job.PublishedDate = DateTime.Now;
                    job.ExpiredDate = data.SubmissionDeadline;
                    job.JobStartingDate = data.JobStartingDate;
                    job.TotalScore = data.TotalScore;
                    job.PassingScore = data.PassingScore;
                    job.IsAcceptPassingScore = data.IsAcceptPassingScore;
                    job.IsActive = false;
                    job.CreatedDate = DateTime.Now ;
                    job.CreatedBy = jobBodyModel.UserId ;
                    job.UpdatedDate = DateTime.Now;
                    job.UpdatedBy =0;

                    if(data.TempSkills !=null)
                    {
                        foreach(var s in data.TempSkills)
                        {
                            var skill = new JobSkills
                            {
                                JobSkillId=0,
                                JobId=0,
                                SkillId = s.SkillId,
                                SkillCategoryId = s.SkillCategoryId
                            };
                            skills.Add(skill);
                        }
                    }
                    if (data.TempQuestions != null)
                    {
                        foreach(var q in data.TempQuestions)
                        {
                            var questions = new GamificationQuestions
                            {
                                JobQuestionId = 0,
                                JobId = 0,
                                QuestionId = q.QuestionId
                            };
                            question.Add(questions);
                        }
                        
                    }
                    if (data.TempGenders != null)
                    {
                        foreach(var g in data.TempGenders)
                        {
                            var gender = new Gender
                            {
                                GenderId=0,
                                JobId=0,
                                GenderValue=g.GenderValue
                            };
                            genders.Add(gender);
                        }
                    }
                    if (data.TempDegrees != null)
                    {
                        foreach(var d in data.TempDegrees)
                        {
                            var degree = new Qualifications
                            {
                                JobQualificationId = 0,
                                JobId=0,
                                DegreeLevelId=d.DegreeLevelId,
                                DegreeId=d.DegreeId
                            };
                            degrees.Add(degree);
                        }
                    }
                    
                }
                var response = await _jobRepository.AddJob(job, skills, question, genders, degrees, deleteId);
                return job;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<JobSummaryViewModel>> GetCompanyJobsSummary(OrderByJobsBodyModel orderByJobs)
        {
            try
            {
                return await _jobRepository.GetCompanyJobsSummary(orderByJobs);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<ApplyedCandidateViewModel>> GetJobWiseAppliedCandidateList(JobWiseAppliedCandidateBodyModel bodyModel)
        {
            try
            {
                if(bodyModel.JobId==0)
                {
                    var model = new List<ApplyedCandidateViewModel>();

                    var data = await _jobRepository.GetCompanyWiseAppliedCandidateList(bodyModel);
                    foreach (var i in data)
                    {
                        var reqModel = new CandidateAssessmentBodyModel
                        {
                            CandidateId = i.CandidateId,
                            CompanyId = i.CompanyId,
                            JobId = i.JobId,
                            ApplicationId = i.ApplicationId
                        };

                        var response = await GetJobWiseCandidateScreening(reqModel);

                        var finalResponse = new ApplyedCandidateViewModel
                        {
                            JobId = i.JobId,
                            JobTitle = i.JobTitle,
                            TotalExamMarks = i.TotalExamMarks,
                            ObtainMarks = i.ObtainMarks,
                            MarkPercentage = i.MarkPercentage,
                            CandidateId = i.CandidateId,
                            StatusId = i.StatusId,
                            CandidateName = i.CandidateName,
                            ApplicationId = i.ApplicationId,
                            CompanyId = i.CompanyId,
                            IsProfileMatch = i.IsProfileMatch,
                            IsProfileView = i.IsProfileView,
                            AppliedDate = i.AppliedDate,
                            ScheduleDate = i.ScheduleDate,
                            ExpiredDate = i.ExpiredDate,
                            CandidateProfilePercentage = response.CandidateProfilePercentage
                        };
                        model.Add(finalResponse);
                    }

                    return model;
                }
                else
                {
                    var model = new List<ApplyedCandidateViewModel>();
                    var data = await _jobRepository.GetJobWiseAppliedCandidateList(bodyModel);

                    foreach (var i in data)
                    {
                        var reqModel = new CandidateAssessmentBodyModel
                        {
                            CandidateId = i.CandidateId,
                            CompanyId = i.CompanyId,
                            JobId = i.JobId,
                            ApplicationId = i.ApplicationId
                        };

                        var response = await GetJobWiseCandidateScreening(reqModel);

                        var finalResponse = new ApplyedCandidateViewModel
                        {
                            JobId = i.JobId,
                            JobTitle = i.JobTitle,
                            TotalExamMarks = i.TotalExamMarks,
                            ObtainMarks = i.ObtainMarks,
                            MarkPercentage = i.MarkPercentage,
                            CandidateId = i.CandidateId,
                            StatusId = i.StatusId,
                            CandidateName = i.CandidateName,
                            ApplicationId = i.ApplicationId,
                            CompanyId = i.CompanyId,
                            IsProfileMatch = i.IsProfileMatch,
                            IsProfileView = i.IsProfileView,
                            AppliedDate=i.AppliedDate,
                            ScheduleDate=i.ScheduleDate,
                            ExpiredDate = i.ExpiredDate,
                            CandidateProfilePercentage = response.CandidateProfilePercentage
                        };
                        model.Add(finalResponse);
                    }

                    return model;
                }
                
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
                
                if (bodyModel.StatusId==0)
                {
                    var model =new List<ApplyedCandidateViewModel>();

                    var data= await _jobRepository.GetNewCandidateList(bodyModel);

                    foreach(var i in data)
                    {
                        var reqModel = new CandidateAssessmentBodyModel {
                            CandidateId=i.CandidateId,
                            CompanyId=i.CompanyId,
                            JobId=i.JobId,
                            ApplicationId=i.ApplicationId
                        };

                        var response =await GetJobWiseCandidateScreening(reqModel);

                        var finalResponse = new ApplyedCandidateViewModel
                        {
                            JobId = i.JobId,
                            JobTitle = i.JobTitle,
                            TotalExamMarks = i.TotalExamMarks,
                            ObtainMarks = i.ObtainMarks,
                            MarkPercentage = i.MarkPercentage,
                            CandidateId = i.CandidateId,
                            StatusId = i.StatusId,
                            CandidateName = i.CandidateName,
                            ApplicationId = i.ApplicationId,
                            CompanyId = i.CompanyId,
                            IsProfileMatch = i.IsProfileMatch,
                            IsProfileView = i.IsProfileView,
                            AppliedDate = i.AppliedDate,
                            ScheduleDate = i.ScheduleDate,
                            ExpiredDate = i.ExpiredDate,
                            PublishedDate = i.PublishedDate,
                            CandidateCount = i.CandidateCount,
                            CandidateProfilePercentage = response.CandidateProfilePercentage
                        };
                        model.Add(finalResponse);
                    }

                    return model;


                }
                else
                {
                    var model = new List<ApplyedCandidateViewModel>();
                    var data= await _jobRepository.GetShortListedCandidateList(bodyModel);
                    foreach (var i in data)
                    {
                        var reqModel = new CandidateAssessmentBodyModel
                        {
                            CandidateId = i.CandidateId,
                            CompanyId = i.CompanyId,
                            JobId = i.JobId,
                            ApplicationId = i.ApplicationId
                        };

                        var response = await GetJobWiseCandidateScreening(reqModel);


                        var finalResponse = new ApplyedCandidateViewModel
                        {
                            JobId = i.JobId,
                            JobTitle = i.JobTitle,
                            TotalExamMarks = i.TotalExamMarks,
                            ObtainMarks = i.ObtainMarks,
                            MarkPercentage = i.MarkPercentage,
                            CandidateId = i.CandidateId,
                            StatusId = i.StatusId,
                            CandidateName = i.CandidateName,
                            ApplicationId = i.ApplicationId,
                            CompanyId = i.CompanyId,
                            IsProfileMatch = i.IsProfileMatch,
                            IsProfileView = i.IsProfileView,
                            AppliedDate = i.AppliedDate,
                            ScheduleDate = i.ScheduleDate,
                            ExpiredDate = i.ExpiredDate,
                            PublishedDate = i.PublishedDate,
                            CandidateCount = i.CandidateCount,
                            CandidateProfilePercentage = response.CandidateProfilePercentage
                        };
                        model.Add(finalResponse);
                    }

                    return model;
                }
               
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
                return await _jobRepository.GetAppliedCandidateAssissmentDetails(bodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CandidateScreeningViewModel> GetJobWiseCandidateScreening(CandidateAssessmentBodyModel bodyModel)
        {
            try
            {
                var data= await _jobRepository.GetJobWiseCandidateScreening(bodyModel);

                try
                {
                    dynamic month = new { };
                    var monthCal = 0;
                    int years = 0;
                    var dateViewModel = await _userRepository.GetCandidateExperiance(bodyModel.CandidateId);
                    foreach (var date in dateViewModel)
                    {
                        DateTime EndDate = DateTime.Now;
                        if (date.IsCurrentJob == false)
                        {
                            EndDate = date.EndDate;
                        }

                        month = GetDifferenceInYearsMonths(date.StartDate, EndDate);
                        if (month.yearsData > 0)
                        {
                            years += month.yearsData;
                            if (month.monthsData > 0)
                            {
                                monthCal += month.monthsData;
                                if (monthCal >= 12)
                                {
                                    years += 1;
                                    monthCal = monthCal - 12;
                                }
                            }

                        }
                    }
                    data.CandidateYearOfExperience = years;
                }
                catch (Exception ex)
                {
                    data.CandidateYearOfExperience = 0;
                }

                var candidateProfilePercentage = GetCandidateProfileScreeningPercentage(data);
                data.CandidateProfilePercentage = candidateProfilePercentage;

                return data;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        private decimal GetCandidateProfileScreeningPercentage(CandidateScreeningViewModel candidateScreeningViewModel)
        {
            try
            {
                decimal percentageValue =Convert.ToDecimal(100) / 3;
                decimal profilePercentage = 0;


                string a = candidateScreeningViewModel.JobYearOfExperience;
                string b = string.Empty;
                int jobYearOfExperience = 0; ;

                for (int i = 0; i < a.Length; i++)
                {
                    if (Char.IsDigit(a[i]))
                        b += a[i];
                }

                if (b.Length > 0)
                {
                    jobYearOfExperience = int.Parse(b);
                }
                    

                if (jobYearOfExperience <= candidateScreeningViewModel.CandidateYearOfExperience)
                {
                    profilePercentage += percentageValue;
                }

                if(candidateScreeningViewModel.CompanyJobCategoryId== candidateScreeningViewModel.CandidateJobCategoryId)
                {
                    profilePercentage += percentageValue;
                }

                if (candidateScreeningViewModel.JobSkills != null)
                {
                    int jobCounter = 0;
                    int candidateCounter = 0;
                    if (candidateScreeningViewModel.CandidateSkills != null)
                    {

                        foreach (var job in candidateScreeningViewModel.JobSkills)
                        {
                            jobCounter++;
                            foreach (var candidate in candidateScreeningViewModel.CandidateSkills)
                            {
                                if (job.SkillId == candidate.SkillId)
                                {
                                    candidateCounter++;
                                }
                            }

                        }
                    }

                    decimal skillValue = percentageValue / jobCounter;
                    decimal candidateValue = skillValue * candidateCounter;

                    profilePercentage += candidateValue;
                }



                return profilePercentage;
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
                return await _jobRepository.GetAllStatus();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<AppliedJobs> UpdateAppliedCandidateJobStatus(JobStatusChangeBodyModel JobStatusChangeBodyModel)
        {
            try
            {
                return await _jobRepository.UpdateAppliedCandidateJobStatus(JobStatusChangeBodyModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<EmployerWellcomeViewModel>  GetEmployerWellcomeNote(int companyId)
        {
            try
            {
                var response = new EmployerWellcomeViewModel();
                response.NewApplyeCandidateCount = _jobRepository.GetCompanyWiseNotProfileViewCandidateCount(companyId);
                response.OnlineInterviewCandidateCount = _jobRepository.GetCurrentDateOnlineInterviewCandidatesCount(companyId);
                return response;
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
                return await _jobRepository.UpdateApplyedJobScheduleDate(jobScheduleBodyModel);
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
                return await _jobRepository.UpdateApplyedCandidateProfileView(profileViewBodyModel);
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
                return await _jobRepository.GetStatusWiseCompanyJobsSummary(jobStatus);
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
                return await _jobRepository.UpdateTemporaryJobFirstStage(temporaryJobFirstStage);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public dynamic GetDifferenceInYearsMonths(DateTime startDate, DateTime endDate)
        {
            int years = 0; int months = 0; int days = 0;
            if (endDate < startDate)
            {
                DateTime date3 = endDate;
                endDate = startDate;
                startDate = date3;
            }
            TimeSpan ts = endDate - startDate;
            if ((endDate.Month <= startDate.Month) && (endDate.Day < startDate.Day))
            {
                years = (endDate.Year - startDate.Year - 1);
                months = 12 - startDate.Month + endDate.Month - 1;
                days = DateTime.DaysInMonth(startDate.Year, startDate.Month) - startDate.Day + endDate.Day;

                if (months == 12)
                {
                    months = 0;
                    years += 1;
                }
            }
            else if ((endDate.Month <= startDate.Month) && (endDate.Day >= startDate.Day))
            {
                years = endDate.Year - startDate.Year - 1;
                months = 12 - startDate.Month + endDate.Month;
                days = endDate.Day - startDate.Day;
                if (months == 12)
                {
                    months = 0;
                    years += 1;
                }
            }
            else if ((endDate.Month > startDate.Month) && (endDate.Day < startDate.Day))
            {
                years = endDate.Year - startDate.Year;
                months = endDate.Month - startDate.Month - 1;
                days = DateTime.DaysInMonth(startDate.Year, startDate.Month) - startDate.Day + endDate.Day;
            }
            else if ((endDate.Month > startDate.Month) && (endDate.Day >= startDate.Day))
            {
                years = endDate.Year - startDate.Year;
                months = endDate.Month - startDate.Month;
                days = endDate.Day - startDate.Day;
            }
            var dateData = new
            {
                yearsData = years,
                monthsData = months,
                daysData = days
            };
            return dateData;
        }


    }
}
