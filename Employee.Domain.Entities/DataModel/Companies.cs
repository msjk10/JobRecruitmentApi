using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Domain.Entities.DataModel
{
    [Table("Companies", Schema = "Job")]
    public class Companies
    {
        [Key]
        [Column("CompanyId")]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; } = "";
        public string ContactNo { get; set; } = "";
        public string CompanyEmail { get; set; } = "";
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public int CountryId { get; set; } = 0;
        public int DistrictId { get; set; } = 0;
        public int ThanaId { get; set; } = 0;
        public string ZipCode { get; set; } = "";
        public string IndustryType { get; set; } = "";
        public string BusinessCategory { get; set; } = "";
        public string BusinessType { get; set; } = "";
        public string BusinessDescription { get; set; } = "";
        public string TreadLicencanceNo { get; set; } = "";
        public string TreadLicencancePhotoUrl { get; set; } = "";
        public string CompanyLogoUrl { get; set; } = "";
        public string ContactPersonName { get; set; } = "";
        public string ContactPersonDesignation { get; set; } = "";
        public string OfficeContactNo { get; set; } = "";
        public string PersonalContactNo { get; set; } = "";
        public string ContactPersonEmailId { get; set; } = "";
        public string BillingAddress { get; set; } = "";
        public string BillingContactNo { get; set; } = "";
        public string BillingEmailId { get; set; } = "";
        public string NavigationUrl { get; set; } = "";
        public string WebSiteUrl { get; set; } = "";
        public bool IsVerifiedCompany { get; set; } = false;
        public int VerifiedBy { get; set; } = 0;
        public DateTime VerifiedDate { get; set; } = DateTime.Now;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsJobPermission { get; set; } = false;
        public int UserId { get; set; }
    }
}
