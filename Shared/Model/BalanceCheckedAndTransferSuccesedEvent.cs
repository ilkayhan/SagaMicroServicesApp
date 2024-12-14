using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class BalanceCheckedAndTransferSuccesedEvent
    {
        public long TransferId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
