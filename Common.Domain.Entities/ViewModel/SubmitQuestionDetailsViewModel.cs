using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class SubmitQuestionDetailsViewModel
    {
        public int QuestionDetailsId { get; set; }
        public int QuestionId { get; set; }
        public string OptionValue { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public bool IsSelectedOption { get; set; }
        public bool IsSubmittedAnswer { get; set; }

    }
}
