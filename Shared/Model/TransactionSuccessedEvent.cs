using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class TransactionSuccessedEvent
    {
        public long TransferId { get; set; }
        public long SenderUserAccountId { get; set; }
        public long ReceiverUserAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
