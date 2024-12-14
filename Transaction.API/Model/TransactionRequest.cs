
using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction.API.Model
{
    public class TransactionRequest
    {
        public long Id { get; set; } // İşlem ID'si
        public long TransferId { get; set; }
        public DateTime CreatedAt { get; set; } // İşlem tarihi
        public TransactionStatus Status { get; set; } // İşlem durumu (Pending, Completed, Failed)
    }
    public enum TransactionStatus
    {
        Pending = 1,
        Completed = 3,
        Failed = 3,
        NotEnoughSenderBalance = 4
    }
}
