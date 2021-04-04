using Common.Domain.Entities.BodyModel;
using Employee.Domain.Entities.BodyModel;
using Employee.Domain.Entities.DataModel;
using Employee.Domain.Entities.ViewModel;
using Employee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Employee
{
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addtemporaryjobfirststage")]
        public async Task<IActionResult> AddTemporaryJobFirstStage([FromBody] TemporaryJobFirstStage temporaryJobFirstStage)
        {
            try
            {
                var data = await _jobService.AddTemporaryJobFirstStage(temporaryJobFirstStage);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@temporaryJobFirstStage} on {AddTemporaryJobFirstStage}", temporaryJobFirstStage, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("gettemporaryjobfirststage/{companyId}")]
        public async Task<IActionResult> GetTemporaryJobFirstStage(int companyId)
        {
            try
            {
                var data = await _jobService.GetTemporaryJobFirstStage(companyId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetTemporaryJobFirstStage}", DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetTemporaryJobFirstStageList/{companyId}")]
        public async Task<IActionResult> GetTemporaryJobFirstStageList(int companyId)
        {
            try
            {
                var data = await _jobService.GetTemporaryJobFirstStageList(companyId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetTemporaryJobFirstStage}", DateTime.Now);
                throw exception;
            }
        }


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateTemporaryJobFirstStage")]
        public async Task<IActionResult> UpdateTemporaryJobFirstStage([FromBody] TemporaryJobFirstStage temporaryJobFirstStage)
        {
            try
            {
                var data = await _jobService.UpdateTemporaryJobFirstStage(temporaryJobFirstStage);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@temporaryJobFirstStage} on {UpdateTemporaryJobFirstStage}", temporaryJobFirstStage, DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addtemporaryjobsecondstage")]
        public async Task<IActionResult> AddTemporaryJobSecondtStage([FromBody] JobSecondStageBodyModel jobSecondStageBodyModel)
        {
            try
            {
                var data = await _jobService.AddTemporaryJobSecondtStage(jobSecondStageBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobSecondStageBodyModel} on {AddTemporaryJobSecondtStage}", jobSecondStageBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("Getjobsecondstageasync/{tempJobId}")]
        public async Task<IActionResult> GetJobSecondStageAsync(int tempJobId)
        {
            try
            {
                var data = await _jobService.GetJobSecondStageAsync(tempJobId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetJobSecondStageAsync}", DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addtemporaryjobthirdstage")]
        public async Task<IActionResult> AddTemporaryJobThirdtStage([FromBody] JobThirdStageBodyModel jobThirdStageBodyModel)
        {
            try
            {
                var data = await _jobService.AddTemporaryJobThirdtStage(jobThirdStageBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobThirdStageBodyModel} on {AddTemporaryJobThirdtStage}", jobThirdStageBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getjobthirdstage/{tempJobId}")]
        public async Task<IActionResult> GetJobThirdStage(int tempJobId)
        {
            try
            {
                var data = await _jobService.GetJobThirdStage(tempJobId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetJobThirdStage}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addjob")]
        public async Task<IActionResult> AddJob([FromBody] JobBodyModel jobBodyModel)
        {
            try
            {
                var data = await _jobService.AddJob(jobBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobBodyModel} on {AddJob}", jobBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetCompanyJobsSummary")]
        public async Task<IActionResult> GetCompanyJobsSummary([FromBody] OrderByJobsBodyModel orderByJobs)
        {
            try
            {
                var data = await _jobService.GetCompanyJobsSummary(orderByJobs);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCompanyJobsSummary}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getjobwiseappliedcandidates")]
        public async Task<IActionResult> GetJobWiseAppliedCandidateList([FromBody] JobWiseAppliedCandidateBodyModel bodyModel)
        {
            try
            {
                var data = await _jobService.GetJobWiseAppliedCandidateList(bodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@bodyModel} on {GetJobWiseAppliedCandidateList}", bodyModel, DateTime.Now);
                throw exception;
            }

        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getnewcandidates")]
        public async Task<IActionResult> GetNewCandidateList([FromBody] JobWiseAppliedCandidateBodyModel bodyModel)
        {
            try
            {
                var data = await _jobService.GetNewCandidateList(bodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetNewCandidateList}", DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getappliedcandidateassissmentdetails")]
        public async Task<IActionResult> GetAppliedCandidateAssissmentDetails([FromBody] CandidateAssessmentBodyModel bodyModel)
        {
            try
            {
                var data = await _jobService.GetAppliedCandidateAssissmentDetails(bodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@bodyModel} on {GetAppliedCandidateAssissmentDetails}", bodyModel, DateTime.Now);
                throw exception;
            }
        }



        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetJobWiseCandidateScreening")]
        public async Task<IActionResult> GetJobWiseCandidateScreening([FromBody] CandidateAssessmentBodyModel bodyModel)
        {
            try
            {
                var data = await _jobService.GetJobWiseCandidateScreening(bodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@bodyModel} on {GetJobWiseCandidateScreening}", bodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            try
            {
                var data = await _jobService.GetAllStatus();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllStatus}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateAppliedCandidateJobStatus")]
        public async Task<IActionResult> UpdateAppliedCandidateJobStatus([FromBody] JobStatusChangeBodyModel jobStatusChangeBodyModel)
        {
            try
            {
                var data = await _jobService.UpdateAppliedCandidateJobStatus(jobStatusChangeBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobStatusChangeBodyModel} on {UpdateAppliedCandidateJobStatus}", jobStatusChangeBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetEmployerWellcomeNote/{companyId}")]
        public async Task<IActionResult> GetEmployerWellcomeNote(int companyId)
        {
            try
            {
                var data =await _jobService.GetEmployerWellcomeNote(companyId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetEmployerWellcomeNote}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateApplyedJobScheduleDate")]
        public async Task<IActionResult> UpdateApplyedJobScheduleDate([FromBody] JobScheduleBodyModel jobScheduleBodyModel)
        {
            try
            {
                var data = await _jobService.UpdateApplyedJobScheduleDate(jobScheduleBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobScheduleBodyModel} on {UpdateApplyedJobScheduleDate}", jobScheduleBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateApplyedCandidateProfileView")]
        public async Task<IActionResult> UpdateApplyedCandidateProfileView( [FromBody]  ProfileViewBodyModel profileViewBodyModel)
        {
            try
            {
                var data = await _jobService.UpdateApplyedCandidateProfileView(profileViewBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@profileViewBodyModel} on {UpdateApplyedCandidateProfileView}", profileViewBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetStatusWiseCompanyJobsSummary")]
        public async Task<IActionResult> GetStatusWiseCompanyJobsSummary([FromBody] JobStatusBodyModel jobStatus)
        {
            try
            {
                var data = await _jobService.GetStatusWiseCompanyJobsSummary(jobStatus);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobStatus} on {GetStatusWiseCompanyJobsSummary}", jobStatus, DateTime.Now);
                throw exception;
            }
        }



    }
}
