using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public CategoryRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<JobCategory> AddJobCategory(JobCategory jobCategory)
        {
            try
            {
                var entity = await _sqlServerContext.JobCategory.FirstOrDefaultAsync(item => item.JobCategoryName == jobCategory.JobCategoryName);
                if (entity == null)
                {

                    await _sqlServerContext.JobCategory.AddAsync(jobCategory);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    jobCategory.JobCategoryId = 0;
                    jobCategory.JobCategoryName = "";
                    jobCategory.IsActive = false;
                    jobCategory.CreatedDate = DateTime.Now;
                    jobCategory.CreatedBy = 0;
                    jobCategory.UpdatedBy = 0;
                    jobCategory.UpdatedDate = DateTime.Now;
                }
                return jobCategory;
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
                var entity = await _sqlServerContext.JobSubCategory.FirstOrDefaultAsync(item => item.JobSubCategoryName == jobSubCategory.JobSubCategoryName);
                if (entity == null)
                {

                    await _sqlServerContext.JobSubCategory.AddAsync(jobSubCategory);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {

                    jobSubCategory.JobSubCategoryId = 0;
                    jobSubCategory.JobCategoryId = 0;
                    jobSubCategory.JobSubCategoryName = "";
                    jobSubCategory.IsActive = false;
                    jobSubCategory.CreatedDate = DateTime.Now;
                    jobSubCategory.CreatedBy = 0;
                    jobSubCategory.UpdatedBy = 0;
                    jobSubCategory.UpdatedDate = DateTime.Now;
                }
                return jobSubCategory;
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
                var entity = await _sqlServerContext.SkillCategories.FirstOrDefaultAsync(item => item.SkillCategoryName == skillCategories.SkillCategoryName);
                if (entity == null)
                {

                    await _sqlServerContext.SkillCategories.AddAsync(skillCategories);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {

                    skillCategories.SkillCategoryId = 0;
                    skillCategories.SkillCategoryName = "";
                    skillCategories.IsActive = false;
                    skillCategories.CreatedDate = DateTime.Now;
                    skillCategories.CreatedBy = 0;
                    skillCategories.UpdatedBy = 0;
                    skillCategories.UpdatedDate = DateTime.Now;
                }
                return skillCategories;
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
                IQueryable<SkillCategories> response = (from s in _sqlServerContext.SkillCategories
                                                        where s.IsActive == true
                                                        select new SkillCategories
                                                        {
                                                            SkillCategoryId = s.SkillCategoryId,
                                                            SkillCategoryName = s.SkillCategoryName,
                                                            IsActive = s.IsActive,
                                                            CreatedDate = s.CreatedDate,
                                                            CreatedBy = s.CreatedBy,
                                                            UpdatedBy = s.UpdatedBy,
                                                            UpdatedDate = s.UpdatedDate
                                                        });

                return await response.ToListAsync();
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
                var entity = await _sqlServerContext.Skills.FirstOrDefaultAsync(item => item.SkillName == skills.SkillName && item.SkillCategoryId == skills.SkillCategoryId);
                if (entity == null)
                {

                    await _sqlServerContext.Skills.AddAsync(skills);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {
                    skills.SkillId = 0;
                    skills.SkillCategoryId = 0;
                    skills.SkillName = "";
                    skills.IsActive = false;
                    skills.CreatedDate = DateTime.Now;
                    skills.CreatedBy = 0;
                    skills.UpdatedBy = 0;
                    skills.UpdatedDate = DateTime.Now;
                }
                return skills;
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
                var selectedSkillCategoryId = skillCategoryViewModel.SelectedSkillCategoryId.Split(',').ToList();
                IQueryable<Skills> response = (from s in _sqlServerContext.Skills
                                               where s.IsActive == true && selectedSkillCategoryId.Contains(s.SkillCategoryId.ToString())
                                               select new Skills
                                               {
                                                   SkillId = s.SkillId,
                                                   SkillName = s.SkillName,
                                                   SkillCategoryId = s.SkillCategoryId,
                                                   IsActive = s.IsActive,
                                                   CreatedDate = s.CreatedDate,
                                                   CreatedBy = s.CreatedBy,
                                                   UpdatedBy = s.UpdatedBy,
                                                   UpdatedDate = s.UpdatedDate
                                               });
                return await response.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<JobCategory>> GetAllActiveJobCategory()
        {
            IQueryable<JobCategory> response = (from j in _sqlServerContext.JobCategory
                                                where j.IsActive == true
                                                select new JobCategory
                                                {
                                                    JobCategoryId = j.JobCategoryId,
                                                    JobCategoryName = j.JobCategoryName,
                                                    IsActive = j.IsActive,
                                                    CreatedDate = j.CreatedDate,
                                                    CreatedBy = j.CreatedBy,
                                                    UpdatedBy = j.UpdatedBy,
                                                    UpdatedDate = j.UpdatedDate
                                                });
            return await response.ToListAsync();
        }

        public async Task<IEnumerable<JobSubCategory>>GetAllActiveJobSubCategory(int jobCategoryId)
        {
            try
            {
                IQueryable<JobSubCategory> response = (from s in _sqlServerContext.JobSubCategory
                                               where s.IsActive == true && s.JobCategoryId == jobCategoryId
                                                       select new JobSubCategory
                                               {
                                                   JobSubCategoryId = s.JobSubCategoryId,
                                                   JobSubCategoryName = s.JobSubCategoryName,
                                                   JobCategoryId = s.JobCategoryId,
                                                   IsActive = s.IsActive,
                                                   CreatedDate = s.CreatedDate,
                                                   CreatedBy = s.CreatedBy,
                                                   UpdatedBy = s.UpdatedBy,
                                                   UpdatedDate = s.UpdatedDate
                                               });
                return await response.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
