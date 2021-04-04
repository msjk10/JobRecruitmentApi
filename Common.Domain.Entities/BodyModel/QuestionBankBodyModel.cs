using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.BodyModel
{
    public class QuestionBankBodyModel
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
        public IEnumerable<QuestionDetails> QuestionDetails { get; set; }
    }
}
