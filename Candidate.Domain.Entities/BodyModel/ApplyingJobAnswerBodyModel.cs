using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.BodyModel
{
    public class ApplyingJobAnswerBodyModel
    {
        public int QuestionId { get; set; }
        public int Point { get; set; }
        public int QuestionDetailsId { get; set; }
        public string OptionValue { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public bool IsSubmittedAnswer { get; set; }

    }
}
