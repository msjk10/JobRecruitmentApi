using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class AppliedJobAssissmentViewModel
    {
        public int ApplicationId { get; set; }
        public int CandidateId { get; set; }
        public int CompanyId { get; set; }
        public int JobId { get; set; }
        public int TotalExamMarks { get; set; }
        public int ObtainMarks { get; set; }
        public IEnumerable<SubmitQuestionBankViewModel> QuestionBank { get; set; }
    }
}
