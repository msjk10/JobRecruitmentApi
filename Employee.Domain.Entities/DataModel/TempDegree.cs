using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("TempDegree", Schema = "Temporary")]
    public class TempDegree
    {
        [Key]
        public int TempDegreeId { get; set; }
        public int TempJobId { get; set; }
        public int DegreeLevelId { get; set; }
        public int DegreeId { get; set; }
    }
}
