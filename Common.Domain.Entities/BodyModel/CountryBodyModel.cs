using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.BodyModel
{
    public class CountryBodyModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
