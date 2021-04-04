using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Domain.Entities.DataModel
{
    [Table("Users", Schema = "Security")]
    public class Users
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string UserPassword { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public string SignupDeviceInfo { get; set; }
        public int PackageId { get; set; }
    }
}
