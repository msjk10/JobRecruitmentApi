using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using Common.Domain.Interfaces;
using Job.Context.EfConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Data
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public QuestionRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<QuestionCategory> AddQuestionCategory(QuestionCategory questionCategory)
        {
            try
            {
                var entity = await _sqlServerContext.QuestionCategory.FirstOrDefaultAsync(item => item.QuestionCategoryName == questionCategory.QuestionCategoryName);
                if (entity == null)
                {

                    await _sqlServerContext.QuestionCategory.AddAsync(questionCategory);
                    await _sqlServerContext.SaveChangesAsync();
                }
                else
                {

                    questionCategory.QuestionCategoryId = 0;
                    questionCategory.QuestionCategoryName = "";
                    questionCategory.IsActive = false;
                    questionCategory.CreatedDate = DateTime.Now;
                    questionCategory.CreatedBy = 0;
                    questionCategory.UpdatedBy = 0;
                    questionCategory.UpdatedDate = DateTime.Now;
                }
                return questionCategory;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<QuestionCategory>> GetAllActiveQuestionCategories()
        {
            try
            {
                IQueryable<QuestionCategory> response = (from s in _sqlServerContext.QuestionCategory
                                                         where s.IsActive == true
                                                        select new QuestionCategory
                                                        {
                                                            QuestionCategoryId = s.QuestionCategoryId,
                                                            QuestionCategoryName = s.QuestionCategoryName,
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

        public async Task<QuestionBankBodyModel> AddQuestion(QuestionBank questionBank, List<QuestionDetails> questionDetails)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var questionBankBodyModel = new QuestionBankBodyModel();

                    await _sqlServerContext.QuestionBank.AddAsync(questionBank);
                    await _sqlServerContext.SaveChangesAsync();

                    questionBankBodyModel.QuestionId = questionBank.QuestionId;
                    questionBankBodyModel.Question = questionBank.Question;
                    questionBankBodyModel.QuestionCategoryId = questionBank.QuestionCategoryId;
                    questionBankBodyModel.Point = questionBank.Point;
                    questionBankBodyModel.TimeLimit = questionBank.TimeLimit;
                    questionBankBodyModel.CreatedDate = questionBank.CreatedDate;
                    questionBankBodyModel.CreatedBy = questionBank.CreatedBy;
                    questionBankBodyModel.UpdatedDate = questionBank.UpdatedDate;
                    questionBankBodyModel.UpdatedBy = questionBank.UpdatedBy;
                    questionBankBodyModel.IsActive = questionBank.IsActive;

                    if (questionBank.QuestionId>0)
                    {
                        foreach(var i in questionDetails)
                        {
                            i.QuestionId = questionBank.QuestionId;
                        }

                        await _sqlServerContext.QuestionDetails.AddRangeAsync(questionDetails);
                        await _sqlServerContext.SaveChangesAsync();
                        questionBankBodyModel.QuestionDetails = questionDetails;
                    }

                    transaction.Commit();

                    return questionBankBodyModel;


                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
                
        }

        public async Task<IEnumerable<QuestionBankViewModel>> GetCategoryWiseQuestionDetails(QuestionCategoryBodyModel questionCategoryBodyModel)
        {
            try
            {
                var selectedQuestionCategoryId = questionCategoryBodyModel.QuestionCategoryId.Split(',').ToList();
                IQueryable<QuestionBankViewModel> data = (from qb in _sqlServerContext.QuestionBank
                                                          join qd in _sqlServerContext.QuestionDetails
                                                          on qb.QuestionId equals qd.QuestionId
                                                          where qb.IsActive == true && selectedQuestionCategoryId.Contains(qb.QuestionCategoryId.ToString())
                                                          select new QuestionBankViewModel
                                                          {
                                                              QuestionId=qb.QuestionId,
                                                              Question=qb.Question,
                                                              QuestionCategoryId=qb.QuestionCategoryId,
                                                              Point=qb.Point,
                                                              TimeLimit=qb.TimeLimit,
                                                              IsActive = qb.IsActive,
                                                              CreatedDate = qb.CreatedDate,
                                                              CreatedBy = qb.CreatedBy,
                                                              UpdatedDate = qb.UpdatedDate,
                                                              UpdatedBy = qb.UpdatedBy,
                                                              QuestionBankId = qd.QuestionId,
                                                              QuestionDetailsId=qd.QuestionDetailsId,
                                                              OptionValue=qd.OptionValue,
                                                              IsCorrectAnswer=qd.IsCorrectAnswer
                                                          });
                return await data.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
