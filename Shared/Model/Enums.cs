using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Enums
    {
        public enum TransactionStatus
        {
            Pending = 1,
            Completed = 3,
            Failed = 3,
            NotEnoughSenderBalance = 4
        }
    }
}
