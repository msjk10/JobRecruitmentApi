using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.BodyModel
{
    public class JobStatusChangeBodyModel
    {
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public int ApplicationId { get; set; }
        public int StatusId { get; set; }
    }
}
