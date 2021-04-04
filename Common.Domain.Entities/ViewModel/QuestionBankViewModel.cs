using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class QuestionBankViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int QuestionCategoryId { get; set; }
        public int Point { get; set; }
        public int TimeLimit { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }

        public int QuestionBankId { get; set; }
        public int QuestionDetailsId { get; set; }
        public string OptionValue { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
