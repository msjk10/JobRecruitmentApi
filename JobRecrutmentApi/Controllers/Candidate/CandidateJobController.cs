using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Candidate
{
    [Route("api/candidatejob")]
    public class CandidateJobController : Controller
    {
        private readonly ICandidateJobService _candidateJobService;
        public CandidateJobController(ICandidateJobService candidateJobService)
        {
            _candidateJobService = candidateJobService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcandidatenewjobssummary")]
        public async Task<IActionResult> GetCandidateNewJobsSummary([FromBody] CandidateJobCategoryBodyModel candidateJobCategoryBodyModel)
        {
            try
            {
                var data = await _candidateJobService.GetCandidateNewJobsSummary(candidateJobCategoryBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCandidateNewJobsSummary}", DateTime.Now);
                throw exception;
            }
        }
        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addbookmarkjob")]
        public async Task<IActionResult> AddBookmarkJob([FromBody] BookmarkJob bookmarkJob)
        {
            try
            {
                var data = await _candidateJobService.AddBookmarkJob(bookmarkJob);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@bookmarkJob} on {AddBookmarkJob}", bookmarkJob, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcandidatebookmarkjobssummary")]
        public async Task<IActionResult> GetCandidateBookmarkJobsSummary([FromBody] CandidateBookmarkJobBodyModel candidateBookmarkJobBodyModel)
        {
            try
            {
                var data = await _candidateJobService.GetCandidateBookmarkJobsSummary(candidateBookmarkJobBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateBookmarkJobBodyModel} on {GetCandidateBookmarkJobsSummary}", candidateBookmarkJobBodyModel, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getjobdetails/{jobId}")]
        public async Task<IActionResult> GetJobDetails(int jobId)
        {
            try
            {
                var data = await _candidateJobService.GetJobDetails(jobId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetJobDetails}", DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getjobwisequestions/{jobId}")]
        public async Task<IActionResult> GetJobWiseQuestions(int jobId)
        {
            try
            {
                var data = await _candidateJobService.GetJobWiseQuestions(jobId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetJobDetails}", DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("candidateapplyingjob")]
        public async Task<IActionResult> AddCandidateApplyingJob([FromBody] ApplyingJobBodyModel applyingJobBodyModel)
        {
            try
            {
                var response = await _candidateJobService.AddCandidateApplyingJob(applyingJobBodyModel);
                return Ok(response);
            }
            catch (Exception exception)
            {
               Log.Error(exception, "Error report generate {@applyingJobBodyModel} on {AddCandidateApplyingJob}", applyingJobBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcandidateappliedjobssummary/{candidateId}")]
        public async Task<IActionResult> GetCandidateAppliedJobsSummary(int candidateId)
        {
            try
            {
                var data = await _candidateJobService.GetCandidateAppliedJobsSummary(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCandidateAppliedJobsSummary}", DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetCandidateVideoInterviewJobsSummary/{candidateId}")]
        public async Task<IActionResult> GetCandidateVideoInterviewJobsSummary(int candidateId)
        {
            try
            {
                var data = await _candidateJobService.GetCandidateVideoInterviewJobsSummary(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCandidateAppliedJobsSummary}", DateTime.Now);
                throw exception;
            }
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcandidateshortlistedjobssummary/{candidateId}")]
        public async Task<IActionResult> GetCandidateShortlistedJobsSummary(int candidateId)
        {
            try
            {
                var data = await _candidateJobService.GetCandidateShortlistedJobsSummary(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCandidateShortlistedJobsSummary}", DateTime.Now);
                throw exception;
            }
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcandidatehiredjobssummary/{candidateId}")]
        public async Task<IActionResult> GetCandidateHiredJobsSummary(int candidateId)
        {
            try
            {
                var data = await _candidateJobService.GetCandidateHiredJobsSummary(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCandidateHiredJobsSummary}", DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("candidatewellcomenote")]
        public async Task<IActionResult> GetCandidateWellComeNote([FromBody] CandidateWellcomeBodyModel candidateWellcomeBodyModel)
        {
            try
            {
                var response = await _candidateJobService.GetCandidateWellComeNote(candidateWellcomeBodyModel);
                return Ok(response);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateWellcomeBodyModel} on {GetCandidateWellComeNote}", candidateWellcomeBodyModel, DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetAppliedJobDetails")]
        public async Task<IActionResult> GetAppliedJobDetails([FromBody] AppliedJobDetailsBodyModel appliedJob)
        {
            try
            {
                var response = await _candidateJobService.GetAppliedJobDetails(appliedJob);
                return Ok(response);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@appliedJob} on {GetAppliedJobDetails}", appliedJob, DateTime.Now);
                throw exception;
            }
        }



    }
}
