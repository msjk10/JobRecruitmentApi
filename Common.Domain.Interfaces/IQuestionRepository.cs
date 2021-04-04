using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using Common.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<QuestionCategory> AddQuestionCategory(QuestionCategory questionCategory);
        Task<IEnumerable<QuestionCategory>> GetAllActiveQuestionCategories();
        Task<QuestionBankBodyModel> AddQuestion(QuestionBank questionBank, List<QuestionDetails> questionDetails);
        Task<IEnumerable<QuestionBankViewModel>> GetCategoryWiseQuestionDetails(QuestionCategoryBodyModel questionCategoryBodyModel);
    }
}
