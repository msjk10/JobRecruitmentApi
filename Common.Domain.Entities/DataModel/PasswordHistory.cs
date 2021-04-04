using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Domain.Entities.DataModel
{
    [Table("PasswordHistory", Schema = "Security")]
    public class PasswordHistory
    {
        [Key]
        [Column("HistoryId")]
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
