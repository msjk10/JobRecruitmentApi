using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Candidate.Domain.Entities.DataModel
{
    [Table("BookmarkJob", Schema = "Candidate")]
    public class BookmarkJob
    {
        [Key]
        [Column("BookmarkId")]
        public int BookmarkId { get; set; }
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public bool IsBookmark { get; set; }
    }
}
