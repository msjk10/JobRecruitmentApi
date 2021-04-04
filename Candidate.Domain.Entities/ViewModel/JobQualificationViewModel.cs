using System;
using System.Collections.Generic;
using System.Text;

namespace Candidate.Domain.Entities.ViewModel
{
    public class JobQualificationViewModel
    {
        public int JobQualificationId { get; set; }
        public int JobId { get; set; }
        public int DegreeLevelId { get; set; }
        public string DegreeLevelName { get; set; }
        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
    }
}
