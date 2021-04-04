using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("Project", Schema = "Candidate")]
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public int CandidateId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectCompany { get; set; }
        public string ProjectLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsRunning { get; set; }
    }
}
