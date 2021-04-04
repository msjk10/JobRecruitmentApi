using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("DegreeLevel", Schema = "Common")]
    public class DegreeLevel
    {
        [Key]
        [Column("DegreeLevelId")]
        public int DegreeLevelId { get; set; }
        public string DegreeLevelName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
