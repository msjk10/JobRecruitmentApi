using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("DegreeMapping", Schema = "Common")]
    public class DegreeMapping
    {
        [Key]
        [Column("DegreeMappingId")]
        public int DegreeMappingId { get; set; }
        public int DegreeLevelId { get; set; }
        public int DegreeId { get; set; }
        public bool IsActive { get; set; }
        
    }
}
