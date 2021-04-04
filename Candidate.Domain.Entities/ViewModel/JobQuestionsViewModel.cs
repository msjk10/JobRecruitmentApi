using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class JobQuestionsViewModel
    {
        public int JobId { get; set; }
        public int TotalScore { get; set; }
        public IEnumerable<JobQuestionBankViewModel> JobQuestionBank { get; set; }
    }
}
