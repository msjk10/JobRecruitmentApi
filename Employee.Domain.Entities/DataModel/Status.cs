using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Domain.Entities.DataModel
{
    [Table("Status", Schema = "Setting")]
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
