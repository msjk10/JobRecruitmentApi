using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("Gender", Schema = "Job")]
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        public int JobId { get; set; }
        public string GenderValue { get; set; }
    }
}
