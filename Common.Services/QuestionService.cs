using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Interfaces;
using Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class QuestionService: IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<QuestionCategory> AddQuestionCategory(QuestionCategory questionCategory)
        {
            try
            {
                return await _questionRepository.AddQuestionCategory(questionCategory);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<QuestionCategory>> GetAllActiveQuestionCategories()
        {
            try
            {
                return await _questionRepository.GetAllActiveQuestionCategories();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<QuestionBankBodyModel> AddQuestion(QuestionBankBodyModel questionBankBodyModel)
        {
            try
            {
                var questionBank = new QuestionBank();
                var questionDetails = new List<QuestionDetails>();

                questionBank.QuestionId = questionBankBodyModel.QuestionId;
                questionBank.Question = questionBankBodyModel.Question;
                questionBank.QuestionCategoryId = questionBankBodyModel.QuestionCategoryId;
                questionBank.Point = questionBankBodyModel.Point;
                questionBank.TimeLimit = questionBankBodyModel.TimeLimit;
                questionBank.CreatedDate = questionBankBodyModel.CreatedDate;
                questionBank.CreatedBy = questionBankBodyModel.CreatedBy;
                questionBank.UpdatedDate = questionBankBodyModel.UpdatedDate;
                questionBank.UpdatedBy = questionBankBodyModel.UpdatedBy;
                questionBank.IsActive = questionBankBodyModel.IsActive;

                if(questionBankBodyModel.QuestionDetails !=null)
                {
                    foreach (var i in questionBankBodyModel.QuestionDetails)
                    {
                        questionDetails.Add(i);
                    }
                }

                var response = await _questionRepository.AddQuestion(questionBank, questionDetails);
                return response;

            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<QuestionBankBodyModel>> GetCategoryWiseQuestionDetails(QuestionCategoryBodyModel questionCategoryBodyModel)
        {
            try
            {
                var data =await _questionRepository.GetCategoryWiseQuestionDetails(questionCategoryBodyModel);

                var query = (from d in data
                             group d by d.QuestionId into questionBank
                             select new QuestionBankBodyModel
                             {
                                 QuestionId = questionBank.Key,
                                 QuestionCategoryId = (from o in questionBank select o.QuestionCategoryId).FirstOrDefault(),
                                 Question = (from o in questionBank select o.Question).FirstOrDefault(),
                                 Point = (from o in questionBank select o.Point).FirstOrDefault(),
                                 TimeLimit = (from o in questionBank select o.TimeLimit).FirstOrDefault(),
                                 CreatedDate = (from o in questionBank select o.CreatedDate).FirstOrDefault(),
                                 CreatedBy = (from o in questionBank select o.CreatedBy).FirstOrDefault(),
                                 UpdatedDate = (from o in questionBank select o.UpdatedDate).FirstOrDefault(),
                                 UpdatedBy = (from o in questionBank select o.UpdatedBy).FirstOrDefault(),
                                 IsActive = (from o in questionBank select o.IsActive).FirstOrDefault(),
                                 QuestionDetails = (from q in questionBank
                                                    group q by q.QuestionDetailsId into answerBank
                                                    select new QuestionDetails
                                                    {
                                                        QuestionDetailsId = answerBank.Key,
                                                        QuestionId = (from a in answerBank select a.QuestionId).FirstOrDefault(),
                                                        OptionValue = (from a in answerBank select a.OptionValue).FirstOrDefault(),
                                                        IsCorrectAnswer = (from a in answerBank select a.IsCorrectAnswer).FirstOrDefault(),
                                                    })
                             }).ToList();


                return query;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
