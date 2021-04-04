using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.BodyModel
{
    public class CandidateWellcomeBodyModel
    {
        public int CandidateId { get; set; }
        public int JobCategoryId { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
