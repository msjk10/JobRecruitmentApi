using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class CandidateDateViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrentJob { get; set; }
    }
}
