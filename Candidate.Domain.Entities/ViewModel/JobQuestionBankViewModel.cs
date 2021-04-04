using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class JobQuestionBankViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int Point { get; set; }
        public int TimeLimit { get; set; }
        public IEnumerable<QuestionDetails> QuestionDetails { get; set; }
    }
}
