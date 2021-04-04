using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.BodyModel
{
   public class CandidateAssessmentBodyModel
    {
        public int CandidateId { get; set; }
        public int CompanyId { get; set; }
        public int JobId { get; set; }
        public int ApplicationId { get; set; }
    }
}
