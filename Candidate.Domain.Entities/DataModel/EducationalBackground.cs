using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("EducationalBackground", Schema = "Candidate")]
    public class EducationalBackground
    {
        [Key]
        public int EducationBkId { get; set; }
        public int CandidateId { get; set; }
        public string Institute { get; set; }
        public int DegreeLevelId { get; set; }
        public int DegreeId { get; set; }
        public decimal ScoreRange { get; set; }
        public decimal PassingScore { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
