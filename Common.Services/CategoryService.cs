using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<JobCategory> AddJobCategory(JobCategory jobCategory)
        {
            try
            {
                return await _categoryRepository.AddJobCategory(jobCategory);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<JobSubCategory> AddJobSubCategory(JobSubCategory jobSubCategory)
        {
            try
            {
                return await _categoryRepository.AddJobSubCategory(jobSubCategory);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<SkillCategories> AddSkillCategories(SkillCategories skillCategories)
        {
            try
            {
                return await _categoryRepository.AddSkillCategories(skillCategories);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<SkillCategories>> GetAllActiveSkillCategories()
        {
            try
            {
                return await _categoryRepository.GetAllActiveSkillCategories();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<Skills> AddSkills(Skills skills)
        {
            try
            {
                return await _categoryRepository.AddSkills(skills);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<Skills>> GetAllActiveSkills(SkillCategoryViewModel skillCategoryViewModel)
        {
            try
            {
                return await _categoryRepository.GetAllActiveSkills(skillCategoryViewModel);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<JobCategory>> GetAllActiveJobCategory()
        {
            try
            {
                return await _categoryRepository.GetAllActiveJobCategory();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<JobSubCategory>> GetAllActiveJobSubCategory(int jobCategoryId)
        {
            try
            {
                return await _categoryRepository.GetAllActiveJobSubCategory(jobCategoryId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}
