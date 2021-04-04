using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserRegistrationViewModel> UserRegistration(UserEmployerRegistrationBodyModel userRegistrationBodyModel);
        Task<UserLoginViewModel> UserLogin(UserLoginBodyModel userLoginBodyModel);
    }
}
