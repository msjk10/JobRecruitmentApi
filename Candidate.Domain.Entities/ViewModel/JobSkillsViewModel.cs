using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class JobSkillsViewModel
    {
        public int JobSkillId { get; set; }
        public int JobId { get; set; }
        public int SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
    }
}
