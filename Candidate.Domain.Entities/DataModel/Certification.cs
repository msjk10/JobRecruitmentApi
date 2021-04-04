using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("Certification", Schema = "Candidate")]
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        public int CandidateId { get; set; }
        public string CertificationName { get; set; }
        public string IssuingOrganization { get; set; }
        public DateTime CertificationDate { get; set; }
    }
}
