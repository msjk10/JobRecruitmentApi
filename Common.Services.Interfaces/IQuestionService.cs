using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionCategory> AddQuestionCategory(QuestionCategory questionCategory);
        Task<IEnumerable<QuestionCategory>> GetAllActiveQuestionCategories();

        Task<QuestionBankBodyModel> AddQuestion(QuestionBankBodyModel questionBankBodyModel);
        Task<IEnumerable<QuestionBankBodyModel>> GetCategoryWiseQuestionDetails(QuestionCategoryBodyModel questionCategoryBodyModel);
    }
}
