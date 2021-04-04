using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.BodyModel
{
    public class CandidateImageBodyModel
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string PermanentAddress { get; set; }
        public string ProfileImagePath { get; set; }
    }
}
