using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.BodyModel
{
    public class UserLoginBodyModel
    {
        public string LoginId { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
    }
}
