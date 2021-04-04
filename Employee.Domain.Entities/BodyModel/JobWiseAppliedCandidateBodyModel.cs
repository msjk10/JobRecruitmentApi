using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.BodyModel
{
    public class JobWiseAppliedCandidateBodyModel
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public int StatusId { get; set; }
    }
}
