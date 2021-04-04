using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class CandidateSkillsViewModel
    {
        public int CandidateId { get; set; }
        public int SkillId { get; set; }
        public int SkillCategoryId { get; set; }
        public string SkillName { get; set; }
    }
}
