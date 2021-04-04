using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.BodyModel
{
    public class OrderByJobsBodyModel
    {
        public int CompanyId { get; set; }
        public string OrderByStatus { get; set; }
        public int IsActive { get; set; }
    }
}
