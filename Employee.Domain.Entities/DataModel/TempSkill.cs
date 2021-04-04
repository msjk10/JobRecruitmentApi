using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("TempSkill", Schema = "Temporary")]
    public class TempSkill
    {
        [Key]
        public int TempSkillId { get; set; }
        public int TempJobId { get; set; }
        public int SkillCategoryId { get; set; }
        public int SkillId { get; set; }
    }
}
