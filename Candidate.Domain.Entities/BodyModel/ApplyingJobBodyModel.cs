using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.BodyModel
{
    public class ApplyingJobBodyModel
    {
        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public int CompanyId { get; set; }
        public int TotalScore { get; set; }
        public bool IsProfileMatch { get; set; }
        public IEnumerable<ApplyingJobAnswerBodyModel> Answers { get; set; }
    }
}
