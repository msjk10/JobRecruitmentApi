using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("Candidates", Schema = "Candidate")]
    public class Candidates
    {
        [Key]
        [Column("CandidateId")]
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string MaritalStatus { get; set; } = "";
        public string Nationality { get; set; } = "";
        public string Religion { get; set; } = "";
        public string Gender { get; set; } = "";
        public string NationalId { get; set; } = "";
        public string FathersName { get; set; } = "";
        public string MothersName { get; set; } = "";
        public string PresentAddress { get; set; } = "";
        public string PermanentAddress { get; set; } = "";
        public string CandidateContactNo { get; set; } = "";
        public string CandidateEmail { get; set; } = "";
        public string GitLink { get; set; } = "";
        public string LinkedinLink { get; set; } = "";
        public string CarrerObjective { get; set; } = "";
        public string Interest { get; set; } = "";
        public int JobCategoryId { get; set; } = 0;
        public int JobSubcategoryId { get; set; } = 0;
        public string CustomJobCategory { get; set; } = "";
        public int CountryId { get; set; } = 0;
        public int DistrictId { get; set; } = 0;
        public int ThanaId { get; set; } = 0;
        public string ZipCode { get; set; } = "";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public int UserId { get; set; }
        public string ProfileImagePath { get; set; }

    }
}
