using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data;
using Common.Services.Interfaces;
using Common.Services.Interfaces.Security;
using System;
using System.Threading.Tasks;

namespace Common.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographicService _cryptographicService;
        public UserService(IUserRepository userRepository, ICryptographicService cryptographicService)
        {
            _userRepository = userRepository;
            _cryptographicService = cryptographicService;
        }
        public async Task<UserRegistrationViewModel> UserRegistration(UserEmployerRegistrationBodyModel userRegistrationBodyModel)
        {
            try
            {
                userRegistrationBodyModel.UserPassword= _cryptographicService.EncryptionProcess(userRegistrationBodyModel.UserPassword);

                var response = await _userRepository.UserRegistration(userRegistrationBodyModel);
                return response;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<UserLoginViewModel> UserLogin(UserLoginBodyModel userLoginBodyModel)
        {
            try
            {
                var loginUserInfo = await _userRepository.UserLogin(userLoginBodyModel);

                loginUserInfo.UserPassword = _cryptographicService.DecryptionProcess(loginUserInfo.UserPassword);
                if (loginUserInfo.UserPassword == userLoginBodyModel.UserPassword)
                {
                    if(loginUserInfo.UserType== "candidate")
                    {
                        var data = await _userRepository.GetCandidateInfo(loginUserInfo.UserId);
                        loginUserInfo.UserInfoId = data.CandidateId;
                        loginUserInfo.UserName = data.CandidateName;
                        loginUserInfo.JobCategoryId = data.JobCategoryId;

                        var category =await _userRepository.CandidateJobCategory(loginUserInfo.JobCategoryId);
                        loginUserInfo.JobCategoryName = category == null ? "" : category.JobCategoryName;

                        try
                        {
                            dynamic month = new { };
                            var monthCal = 0;
                            int years = 0;
                            var dateViewModel = await _userRepository.GetCandidateExperiance(loginUserInfo.UserInfoId);
                            foreach(var date in dateViewModel)
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
                            loginUserInfo.YearOfExperiance = years;
                        }
                        catch(Exception ex)
                        {
                            loginUserInfo.YearOfExperiance=0;
                        }
                        

                        loginUserInfo.Skills = await _userRepository.GetCandidateSkills(loginUserInfo.UserInfoId);
                        return loginUserInfo;
                    }
                    else if(loginUserInfo.UserType == "company")
                    {
                        var data = await _userRepository.GetCompanyInfo(loginUserInfo.UserId);
                        loginUserInfo.UserInfoId = data.CompanyId;
                        loginUserInfo.UserName = data.CompanyName;
                        loginUserInfo.CompanyExecutiveName = data.ContactPersonName;
                        return loginUserInfo;
                    }

                    return null;
                }
                else
                {
                    return null;
                }
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
