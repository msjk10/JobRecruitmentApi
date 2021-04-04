using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobRecrutmentApi.Controllers.Common
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addjobcategory")]
        public async Task<IActionResult> AddJobCategory([FromBody] JobCategory jobCategory)
        {
            try
            {
                var data = await _categoryService.AddJobCategory(jobCategory);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobCategory} on {AddJobCategory}", jobCategory, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addjobsubcategory")]
        public async Task<IActionResult> AddJobSubCategory([FromBody] JobSubCategory jobSubCategory)
        {
            try
            {
                var data = await _categoryService.AddJobSubCategory(jobSubCategory);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobSubCategory} on {AddJobSubCategory}", jobSubCategory, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addskillcategory")]
        public async Task<IActionResult> AddSkillCategories([FromBody] SkillCategories skillCategories)
        {
            try
            {
                var data = await _categoryService.AddSkillCategories(skillCategories);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@skillCategories} on {AddSkillCategories}", skillCategories, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactiveskillcategories")]
        public async Task<IActionResult> GetAllActiveSkillCategories()
        {
            try
            {
                var data = await _categoryService.GetAllActiveSkillCategories();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveSkillCategories}", DateTime.Now);
                throw exception;
            }
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addskill")]
        public async Task<IActionResult> AddSkills([FromBody] Skills skills)
        {
            try
            {
                var data = await _categoryService.AddSkills(skills);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@skills} on {AddSkills}", skills, DateTime.Now);
                throw exception;
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactiveskills")]
        public async Task<IActionResult> GetAllActiveSkills([FromBody] SkillCategoryViewModel skillCategoryViewModel)
        {
            try
            {
                var data = await _categoryService.GetAllActiveSkills(skillCategoryViewModel);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@skillCategoryId} on {GetAllActiveSkills}", skillCategoryViewModel, DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivejobcategory")]
        public async Task<IActionResult> GetAllActiveJobCategory()
        {
            try
            {
                var data = await _categoryService.GetAllActiveJobCategory();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate on {GetAllActiveJobCategory}", DateTime.Now);
                throw exception;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivejaobsubcategory/{jobCategoryId}")]
        public async Task<IActionResult> GetAllActiveJobSubCategory(int jobCategoryId)
        {
            try
            {
                var data = await _categoryService.GetAllActiveJobSubCategory(jobCategoryId);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@jobCategoryId} on {GetAllActiveJobSubCategory}", jobCategoryId, DateTime.Now);
                throw exception;
            }
        }


    }
}
