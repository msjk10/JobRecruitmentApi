using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class UserRegistrationViewModel
    {
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
    }
}
