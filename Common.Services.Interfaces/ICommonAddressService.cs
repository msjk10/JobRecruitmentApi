using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface ICommonAddressService
    {
        Task<Countries> AddCountry(CountryBodyModel countryBodyModel);
        Task<IEnumerable<Countries>> GetAllActiveCountry();
        Task<IEnumerable<District>> GetAllActiveDistrict();
        Task<District> AddDistrict(District district);
        Task<Thana> AddThana(Thana thana);
        Task<IEnumerable<Thana>> GetAllActiveThana();
    }
}
