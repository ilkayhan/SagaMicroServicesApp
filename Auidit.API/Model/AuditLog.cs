namespace Auidit.API.Model
{
    public class AuditLog
    {
        public long Id { get; set; }
        public int Status { get; set; } // Event tipi (ör: BalanceDebited, TransferCompleted)
        public long? TransactionId { get; set; }
        public long? TransferId { get; set; }
        public string Message { get; set; }
        public DateTime LoggedAt { get; set; } // Log zamanı
    }
}
