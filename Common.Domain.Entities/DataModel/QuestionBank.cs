using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("QuestionBank", Schema = "Common")]
    public class QuestionBank
    {
        [Key]
        [Column("QuestionId")]
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int QuestionCategoryId { get; set; }
        public int Point { get; set; }
        public int TimeLimit { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
