using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("EmploymentHistory", Schema = "Candidate")]
    public class EmploymentHistory
    {
        [Key]
        public int EmploymentId { get; set; }
        public int CandidateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public bool IsCurrentJob { get; set; }
        public string EmploymentType { get; set; }
        public string JobLocation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string JobDescription { get; set; }
    }
}
