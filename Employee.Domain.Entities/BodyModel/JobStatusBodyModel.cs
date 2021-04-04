using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.BodyModel
{
    public class JobStatusBodyModel
    {
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
    }
}
