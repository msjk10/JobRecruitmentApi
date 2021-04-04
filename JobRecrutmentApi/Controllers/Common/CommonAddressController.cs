using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Common
{
    [Route("api/address")]
    public class CommonAddressController : Controller
    {
        private readonly ICommonAddressService _commonAddressService;
        public CommonAddressController(ICommonAddressService commonAddressService)
        {
            _commonAddressService = commonAddressService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addcountry")]
        public async Task<IActionResult> AddCountry([FromBody] CountryBodyModel countryBodyModel)
        {
            try
            {
                var data = await _commonAddressService.AddCountry(countryBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@countryBodyModel} on {AddCountry}", countryBodyModel, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivecountry")]
        public async Task<IActionResult> GetAllActiveCountry()
        {
            try
            {
                var data = await _commonAddressService.GetAllActiveCountry();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveCountry}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("adddistrict")]
        public async Task<IActionResult> AddDistrict([FromBody] District district)
        {
            try
            {
                var data = await _commonAddressService.AddDistrict(district);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@district} on {AddDistrict}", district, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivedistrict")]
        public async Task<IActionResult> GetAllActiveDistrict()
        {
            try
            {
                var data = await _commonAddressService.GetAllActiveDistrict();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveDistrict}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addthana")]
        public async Task<IActionResult> AddThana([FromBody] Thana thana)
        {
            try
            {
                var data = await _commonAddressService.AddThana(thana);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@thana} on {AddThana}", thana, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivethana")]
        public async Task<IActionResult> GetAllActiveThana()
        {
            try
            {
                var data = await _commonAddressService.GetAllActiveThana();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveThana}", DateTime.Now);
                throw exception;
            }
        }

    }
}
