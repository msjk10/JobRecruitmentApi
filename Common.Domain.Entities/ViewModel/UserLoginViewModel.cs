using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class UserLoginViewModel
    {
        public int UserId { get; set; }
        public int UserInfoId { get; set; }
        public int JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string CompanyExecutiveName { get; set; }
        public string UserPassword { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int YearOfExperiance { get; set; }
        public IEnumerable<Skills> Skills { get; set; }

    }
}
