using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.Entities.DataModel;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Common
{
    [Route("api/degree")]
    public class DegreeController : Controller
    {
        private readonly IDegreeService _degreeService;
        public DegreeController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("adddegree")]
        public async Task<IActionResult> AddDegree([FromBody] Degree degree)
        {
            try
            {
                var data = await _degreeService.AddDegree(degree);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@degree} on {AddDegree}", degree, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivedegree/{degreeLevelId}")]
        public async Task<IActionResult> GetAllActiveDegree(int degreeLevelId)
        {
            try
            {
                var data = await _degreeService.GetAllActiveDegree(degreeLevelId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveDegree}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("adddegreelevel")]
        public async Task<IActionResult> AddDegreeLevel([FromBody] DegreeLevel degreeLevel)
        {
            try
            {
                var data = await _degreeService.AddDegreeLevel(degreeLevel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@degreeLevel} on {AddDegreeLevel}", degreeLevel, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivedegreelevel")]
        public async Task<IActionResult> GetAllActiveDegreeLevel()
        {
            try
            {
                var data = await _degreeService.GetAllActiveDegreeLevel();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveDegreeLevel}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("adddegreemapping")]
        public async Task<IActionResult> AddDegreeMapping([FromBody] DegreeMapping degreeMapping)
        {
            try
            {
                var data = await _degreeService.AddDegreeMapping(degreeMapping);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@degreeMapping} on {AddDegreeMapping}", degreeMapping, DateTime.Now);
                throw exception;
            }
        }
    }
}
