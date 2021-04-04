using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("Qualifications", Schema = "Job")]
    public class Qualifications
    {
        [Key]
        public int JobQualificationId { get; set; }
        public int JobId { get; set; }
        public int DegreeLevelId { get; set; }
        public int DegreeId { get; set; }
    }
}
