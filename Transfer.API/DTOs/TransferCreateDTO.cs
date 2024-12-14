using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transfer.API.DTOs
{
    public class TransferCreateDTO 
    {
        public long SenderAccountId { get; set; }
        public long ReceiverAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }

    }
  
}
