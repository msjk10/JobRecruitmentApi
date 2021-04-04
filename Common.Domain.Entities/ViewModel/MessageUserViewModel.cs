using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class MessageUserViewModel
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int ApplicationId { get; set; }
        public int StatusId { get; set; }
        public bool IsReceivedCandidate { get; set; }
        public bool IsReceivedEmploye { get; set; }
        
        public DateTime LastSendingTime { get; set; }
        public string LastSendingMessage { get; set; }

    }
}
