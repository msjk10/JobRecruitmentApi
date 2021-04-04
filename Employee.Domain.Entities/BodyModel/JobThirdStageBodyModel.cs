using Employee.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.BodyModel
{
    public class JobThirdStageBodyModel
    {
        public int ScoreId { get; set; }
        public int TempJobId { get; set; }
        public int TotalScore { get; set; }
        public int PassingScore { get; set; }
        public bool IsAcceptPassingScore { get; set; }
        public IEnumerable<TempQuestion> tempQuestions { get; set; }
    }
}
