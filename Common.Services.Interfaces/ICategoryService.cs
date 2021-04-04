using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<JobCategory> AddJobCategory(JobCategory jobCategory);
        Task<JobSubCategory> AddJobSubCategory(JobSubCategory jobSubCategory);
        Task<SkillCategories> AddSkillCategories(SkillCategories skillCategories);
        Task<IEnumerable<SkillCategories>> GetAllActiveSkillCategories();
        Task<Skills> AddSkills(Skills skills);
        Task<IEnumerable<Skills>> GetAllActiveSkills(SkillCategoryViewModel skillCategoryViewModel);
        Task<IEnumerable<JobCategory>> GetAllActiveJobCategory();
        Task<IEnumerable<JobSubCategory>> GetAllActiveJobSubCategory(int jobCategoryId);
    }
}
