using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("TempGender", Schema = "Temporary")]
    public class TempGender
    {
        [Key]
        public int TempGenderId { get; set; }
        public int TempJobId { get; set; }
        public string GenderValue { get; set; }
    }
}
