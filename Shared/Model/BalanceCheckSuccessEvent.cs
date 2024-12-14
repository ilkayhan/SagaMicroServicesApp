using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class BalanceCheckSuccessEvent
    {
        public long TransferId { get; set; }
        public long SenderAccountId { get; set; }
        public long ReceiverAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
