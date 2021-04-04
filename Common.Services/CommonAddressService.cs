using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Interfaces;
using Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class CommonAddressService: ICommonAddressService
    {
        private readonly ICommonAddressRepository _commonAddressRepository;
        public CommonAddressService(ICommonAddressRepository commonAddressRepository)
        {
            _commonAddressRepository = commonAddressRepository;
        }
        public async Task<Countries> AddCountry(CountryBodyModel countryBodyModel)
        {
            try
            {
                return await _commonAddressRepository.AddCountry(countryBodyModel);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Countries>> GetAllActiveCountry()
        {
            try
            {
                return await _commonAddressRepository.GetAllActiveCountry();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<District>> GetAllActiveDistrict()
        {
            try
            {
                return await _commonAddressRepository.GetAllActiveDistrict();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<District> AddDistrict(District district)
        {
            try
            {
                return await _commonAddressRepository.AddDistrict(district);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Thana> AddThana(Thana thana)
        {
            try
            {
                return await _commonAddressRepository.AddThana(thana);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Thana>> GetAllActiveThana()
        {
            try
            {
                return await _commonAddressRepository.GetAllActiveThana();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
