using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.BodyModel
{
    public class UserEmployerRegistrationBodyModel
    {
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string UserPassword { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public int CountryId { get; set; } = 0;
        public string TreadLicencanceNo { get; set; }
        public string WebSiteUrl { get; set; }
        public string BusinessDescription { get; set; }
        public string IndustryType { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonEmailId { get; set; }
        public string PersonalContactNo { get; set; }
        
    }
}
