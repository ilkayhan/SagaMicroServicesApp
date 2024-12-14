using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class TransactionCompletedEvent
    {
        public long TransferId { get; set; }
        public long TransactionId { get; set; }
        public int Status { get; set; }
        public string Message  { get; set; }
    }
}
