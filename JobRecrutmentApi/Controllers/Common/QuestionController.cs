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
    [Route("api/question")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addquestioncategory")]
        public async Task<IActionResult> AddQuestionCategory([FromBody] QuestionCategory questionCategory)
        {
            try
            {
                var data = await _questionService.AddQuestionCategory(questionCategory);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@questionCategory} on {AddQuestionCategory}", questionCategory, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivequestioncategories")]
        public async Task<IActionResult> GetAllActiveQuestionCategories()
        {
            try
            {
                var data = await _questionService.GetAllActiveQuestionCategories();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveQuestionCategories}", DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addquestion")]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionBankBodyModel questionBankBodyModel)
        {
            try
            {
                var data = await _questionService.AddQuestion(questionBankBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@questionBankBodyModel} on {AddQuestion}", questionBankBodyModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getcategorywisequestiondetails")]
        public async Task<IActionResult> GetCategoryWiseQuestionDetails([FromBody] QuestionCategoryBodyModel questionCategoryBodyModel)
        {
            try
            {
                var data = await _questionService.GetCategoryWiseQuestionDetails(questionCategoryBodyModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@questionCategoryBodyModel} on {GetCategoryWiseQuestionDetails}", questionCategoryBodyModel, DateTime.Now);
                throw exception;
            }
        }
    }
}
