using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("Skills", Schema = "Job")]
    public class JobSkills
    {
        [Key]
        public int JobSkillId { get; set; }
        public int JobId { get; set; }
        public int SkillCategoryId { get; set; }
        public int SkillId { get; set; }
    }
}
