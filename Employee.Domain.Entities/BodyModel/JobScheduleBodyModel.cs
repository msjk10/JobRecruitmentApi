using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Entities.BodyModel
{
    public class JobScheduleBodyModel
    {
        public int ApplicationId { get; set; }
        public DateTime ScheduleDate { get; set; }
    }
}
