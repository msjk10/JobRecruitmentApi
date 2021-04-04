using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("CandidateSkills", Schema = "Candidate")]
    public class CandidateSkills
    {
        [Key]
        public int CandidateSkillId { get; set; }
        public int CandidateId { get; set; }
        public int SkillCategoryId { get; set; }
        public int SkillId { get; set; }
    }
}
