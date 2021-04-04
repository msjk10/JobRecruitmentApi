using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.BodyModel
{
    public class CandidateContactBodyModel
    {
        public int CandidateId { get; set; }
        public string PresentAddress { get; set; }
        public string CandidateContactNo { get; set; }
        public string CandidateEmail { get; set; }
        public string GitLink { get; set; }
    }
}
