using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("Districts", Schema = "Common")]
    public class District
    {
        [Key]
        [Column("DistrictId")]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictZipCode { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
