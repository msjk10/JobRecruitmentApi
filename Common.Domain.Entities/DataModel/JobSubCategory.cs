using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("JobSubCategory", Schema = "Common")]
    public class JobSubCategory
    {
        [Key]
        [Column("JobSubCategoryId")]
        public int JobSubCategoryId { get; set; }
        public string JobSubCategoryName { get; set; }
        public int JobCategoryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
