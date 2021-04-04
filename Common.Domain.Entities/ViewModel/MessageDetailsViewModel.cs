using Common.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Entities.ViewModel
{
    public class MessageDetailsViewModel
    {
        public DateTime SendingDate { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
