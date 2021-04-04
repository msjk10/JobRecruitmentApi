using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces
{
    public interface ICommonAddressRepository
    {
        Task<Countries> AddCountry(CountryBodyModel countryBodyModel);
        Task<IEnumerable<Countries>> GetAllActiveCountry();
        Task<District> AddDistrict(District district);
        Task<IEnumerable<District>> GetAllActiveDistrict();
        Task<Thana> AddThana(Thana thana);
        Task<IEnumerable<Thana>> GetAllActiveThana();
    }
}
