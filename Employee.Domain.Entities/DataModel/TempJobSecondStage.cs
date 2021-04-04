using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("JobSecondStage", Schema = "Temporary")]
    public class TempJobSecondStage
    {
        [Key]
        public int JobSecondStageId { get; set; }
        public int TempJobId { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public string PreferredLanguage { get; set; }
        public string PreferredInstitution { get; set; }
        public string ProfessionalCertification { get; set; }
    }
}
