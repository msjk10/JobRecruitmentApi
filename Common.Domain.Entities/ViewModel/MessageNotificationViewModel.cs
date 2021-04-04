using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class MessageNotificationViewModel
    {
        public int CandidateId { get; set; }
        public int CompanyId { get; set; }
        public bool IsReceivedCandidate { get; set; }
        public bool IsReceivedEmploye { get; set; }
    }
}
