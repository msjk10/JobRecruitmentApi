using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("Thana", Schema = "Common")]
    public class Thana
    {
        [Key]
        [Column("ThanaId")]
        public int ThanaId { get; set; }
        public string ThanaName { get; set; }
        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
