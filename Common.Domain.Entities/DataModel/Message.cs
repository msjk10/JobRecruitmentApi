using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.Entities.DataModel
{
    [Table("Message", Schema = "Common")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public int CandidateId { get; set; }
        public int CompanyId { get; set; }
        public int JobId { get; set; }
        public string SenderType { get; set; }
        public string MessageBody { get; set; }
        public bool IsReceivedEmploye { get; set; }
        public bool IsReceivedCandidate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
