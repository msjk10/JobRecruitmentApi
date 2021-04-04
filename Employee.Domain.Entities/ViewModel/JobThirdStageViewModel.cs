using Common.Domain.Entities.BodyModel;
using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.ViewModel
{
    public class JobThirdStageViewModel
    {
        public int ScoreId { get; set; }
        public int TempJobId { get; set; }
        public int TotalScore { get; set; }
        public int PassingScore { get; set; }
        public bool IsAcceptPassingScore { get; set; }
        public IEnumerable<QuestionCategory> QuestionCategories { get; set; }
        public IEnumerable<QuestionBankBodyModel> QuestionBanks { get; set; }
    }
}
