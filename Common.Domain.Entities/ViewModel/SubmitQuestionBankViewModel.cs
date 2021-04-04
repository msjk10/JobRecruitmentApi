using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class SubmitQuestionBankViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int Point { get; set; }
        public int TimeLimit { get; set; }
        public IEnumerable<SubmitQuestionDetailsViewModel> QuestionDetails { get; set; }
    }
}
