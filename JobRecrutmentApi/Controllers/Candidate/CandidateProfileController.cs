using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Candidate.Domain.Entities.BodyModel;
using Candidate.Domain.Entities.DataModel;
using Candidate.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Candidate
{
    [Route("api/candidateprofile")]
    public class CandidateProfileController : Controller
    {
        private readonly ICandidateProfileService _candidateProfileService;
        public CandidateProfileController(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("updatecustomjobcategory")]
        public async Task<IActionResult> UpdateCustomJobCategory([FromBody] CustomCategoryBodyModel customCategoryBodyModel)
        {
            try
            {
                var data = await _candidateProfileService.UpdateCustomJobCategory(customCategoryBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@customCategoryBodyModel} on {UpdateCustomJobCategory}", customCategoryBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("updatecandidatejobcategory")]
        public async Task<IActionResult> UpdateCandidateJobCategory([FromBody] CandidateJobCategoryBodyModel candidateJobCategoryBodyModel)
        {
            try
            {
                var data = await _candidateProfileService.UpdateCandidateJobCategory(candidateJobCategoryBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateJobCategoryBodyModel} on {UpdateCandidateJobCategory}", candidateJobCategoryBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addcandidateskills")]
        public async Task<IActionResult> AddCandidateSkills([FromBody] IEnumerable<CandidateSkills> candidateSkills)
        {
            try
            {
                var data = await _candidateProfileService.AddCandidateSkills(candidateSkills);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateSkills} on {AddCandidateSkillsAsync}", candidateSkills, DateTime.Now);
                throw exception;
            }
        }


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateCandidateSkills")]
        public async Task<IActionResult> UpdateCandidateSkills([FromBody] IEnumerable<CandidateSkills> candidateSkills)
        {
            try
            {
                var data = await _candidateProfileService.UpdateCandidateSkills(candidateSkills);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateSkills} on {UpdateCandidateSkills}", candidateSkills, DateTime.Now);
                throw exception;
            }
        }




        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addcandidateemploymenthistory")]
        public async Task<IActionResult> AddCandidateEmploymentHistory([FromBody] IEnumerable<EmploymentHistory> employmentHistories)
        {
            try
            {
                var data = await _candidateProfileService.AddCandidateEmploymentHistory(employmentHistories);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@employmentHistories} on {AddCandidateEmploymentHistory}", employmentHistories, DateTime.Now);
                throw exception;
            }
        }


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateCandidateEmploymentHistory")]
        public async Task<IActionResult> UpdateCandidateEmploymentHistory([FromBody] IEnumerable<EmploymentHistory> employmentHistory)
        {
            try
            {
                
                var data = await _candidateProfileService.UpdateCandidateEmploymentHistory(employmentHistory);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@employmentHistory} on {UpdateCandidateEmploymentHistory}", employmentHistory, DateTime.Now);
                throw exception;
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("DeleteCandidateEmploymentHistory/{employmentId}")]
        public async Task<IActionResult> DeleteCandidateEmploymentHistory(int employmentId)
        {
            try
            {
                var data = await _candidateProfileService.DeleteCandidateEmploymentHistory(employmentId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@employmentId} on {DeleteCandidateEmploymentHistory}", employmentId, DateTime.Now);
                throw exception;
            }
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcaldidateprofile/{candidateId}")]
        public async Task<IActionResult> GetCaldidateProfile(int candidateId)
        {
            try
            {
                var data = await _candidateProfileService.GetCaldidateProfile(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCaldidateProfile}", DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcaldidateprofilepercentage/{candidateId}")]
        public async Task<IActionResult> GetCandidateProfilePercentage(int candidateId)
        {
            try
            {
                var data = await _candidateProfileService.GetCandidateProfilePercentage(candidateId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetCandidateProfilePercentage}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateCarrerObjective")]
        public async Task<IActionResult> UpdateCarrerObjective([FromBody] CandidateCarrerObjectiveBodyModel candidateCarrerObjectiveBodyModel)
        {
            try
            {
                var data = await _candidateProfileService.UpdateCarrerObjective(candidateCarrerObjectiveBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateCarrerObjectiveBodyModel} on {UpdateCarrerObjective}", candidateCarrerObjectiveBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateCandidateContact")]
        public async Task<IActionResult> UpdateCandidateContact([FromBody] CandidateContactBodyModel candidateContactBodyModel)
        {
            try
            {
                var data = await _candidateProfileService.UpdateCandidateContact(candidateContactBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@candidateContactBodyModel} on {UpdateCandidateContact}", candidateContactBodyModel, DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("AddCandidateProject")]
        public async Task<IActionResult> AddCandidateProject([FromBody] IEnumerable<Project> projects)
        {
            try
            {
                var data = await _candidateProfileService.AddCandidateProject(projects);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@projects} on {AddCandidateProject}", projects, DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateCandidateProject")]
        public async Task<IActionResult> UpdateCandidateProject([FromBody] IEnumerable<Project> projects)
        {
            try
            {

                var data = await _candidateProfileService.UpdateCandidateProject(projects);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@projects} on {UpdateCandidateProject}", projects, DateTime.Now);
                throw exception;
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("DeleteCandidateProject/{projectId}")]
        public async Task<IActionResult> DeleteCandidateProject(int projectId)
        {
            try
            {
                var data = await _candidateProfileService.DeleteCandidateProject(projectId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@projectId} on {DeleteCandidateProject}", projectId, DateTime.Now);
                throw exception;
            }
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("AddCandidateCertification")]
        public async Task<IActionResult> AddCandidateCertification([FromBody] IEnumerable<Certification> certifications)
        {
            try
            {
                var data = await _candidateProfileService.AddCandidateCertification(certifications);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@certifications} on {AddCandidateCertification}", certifications, DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateCandidateCertification")]
        public async Task<IActionResult> UpdateCandidateCertification([FromBody] IEnumerable<Certification> certifications)
        {
            try
            {

                var data = await _candidateProfileService.UpdateCandidateCertification(certifications);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@certifications} on {UpdateCandidateCertification}", certifications, DateTime.Now);
                throw exception;
            }
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("DeleteCandidateCertification/{certificationId}")]
        public async Task<IActionResult> DeleteCandidateCertification(int certificationId)
        {
            try
            {

                var data = await _candidateProfileService.DeleteCandidateCertification(certificationId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@certificationId} on {DeleteCandidateCertification}", certificationId, DateTime.Now);
                throw exception;
            }
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("AddCandidateEducationalBackground")]
        public async Task<IActionResult> AddCandidateEducationalBackground([FromBody] IEnumerable<EducationalBackground> educations)
        {
            try
            {
                var data = await _candidateProfileService.AddCandidateEducationBackground(educations);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@educations} on {AddCandidateEducationalBackground}", educations, DateTime.Now);
                throw exception;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("UpdateCandidateEducationalBackground")]
        public async Task<IActionResult> UpdateCandidateEducationalBackground([FromBody] IEnumerable<EducationalBackground> educations)
        {
            try
            {

                var data = await _candidateProfileService.UpdateCandidateEducationalBackground(educations);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@educations} on {UpdateCandidateEducationalBackground}", educations, DateTime.Now);
                throw exception;
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("DeleteCandidateEducationalBackground/{educationBkId}")]
        public async Task<IActionResult> DeleteCandidateEducationalBackground(int educationBkId)
        {
            try
            {

                var data = await _candidateProfileService.DeleteCandidateEducationalBackground(educationBkId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@educationBkId} on {DeleteCandidateEducationalBackground}", educationBkId, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("AddCandidateProfileImage")]
        public async Task<IActionResult> AddCandidateProfileImage()
        {
            try
            {
                var getProfile = Request.Form["profile"];
                var candidateProfile = JsonConvert.DeserializeObject<CandidateImageBodyModel>(getProfile);
                
                var folderName = Path.Combine("Resources", "CandidateProfileImage", candidateProfile.CandidateId.ToString());
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (Request.Form.Files.Count > 0)
                {

                    var uniqueName = candidateProfile.CandidateId.ToString();
                    foreach (var key in Request.Form.Files)
                    {
                        IFormFile file = key;
                        var fileNameWithoutExt = Path.GetFileNameWithoutExtension(file.FileName) ?? "";
                        var fileName = Path.GetFileName(file.FileName) ?? "";
                        var newFileName = fileName.Replace(fileNameWithoutExt, uniqueName);
                        var fullPath = Path.Combine(pathToSave, newFileName);                        
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {                            
                            await file.CopyToAsync(stream);
                            candidateProfile.ProfileImagePath = fullPath;
                        }
                    }
                }
                if(candidateProfile.ProfileImagePath !="")
                {
                    var data = await _candidateProfileService.UpdateCandidatePersonalInformation(candidateProfile);
                    return Ok(data);
                }
                return Ok(candidateProfile);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {AddCandidateProfileImage}", DateTime.Now);
                throw exception;
            }
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("GetProfileImage")]
        public async Task<IActionResult> GetProfileImage([FromBody] CandidateImageBodyModel candidateImageBodyModel)
        {
            ////var stream = new FileStream(candidateImageBodyModel.ProfileImagePath, FileMode.Open);
            ////var response = File(stream, "application/octet-stream");
            ////return response;


            var image = System.IO.File.OpenRead(candidateImageBodyModel.ProfileImagePath);
            var response = File(image, "image/png");
            return response;
        }




    }
}
