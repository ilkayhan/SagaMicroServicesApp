using Shared.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transfer.API.Model
{
    public class TransferRequest
    {
        public long Id { get; set; } // Benzersiz transfer ID'si
        public long SenderAccountId { get; set; }
        public long ReceiverAccountId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } // Transfer miktarı
        public string Currency { get; set; } // Para birimi
        public string Description { get; set; }
        public DateTime RequestedAt { get; set; } // Talep zamanı
    }
}
