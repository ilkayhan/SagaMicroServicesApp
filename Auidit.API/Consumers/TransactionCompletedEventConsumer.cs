using Auidit.API.Model;
using MassTransit;
using Shared.Model;

namespace Auidit.API.Consumers
{
    public class TransactionCompletedEventConsumer : IConsumer<TransactionCompletedEvent>
    {
        private readonly ILogger<TransactionCompletedEventConsumer> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly AppDbContext _context;

        public TransactionCompletedEventConsumer(ILogger<TransactionCompletedEventConsumer> logger, IPublishEndpoint publishEndpoint, AppDbContext context)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _context = context;
        }

        public  async Task Consume(ConsumeContext<TransactionCompletedEvent> context)
        {
            AuditLog newAuidit = new AuditLog()
            {
                LoggedAt = DateTime.UtcNow,
                Message = "",
                TransactionId = context.Message.TransactionId,
                TransferId = context.Message.TransferId,
                Status = context.Message.Status,
            };

            await _context.AuditLog.AddAsync(newAuidit);
            await _context.SaveChangesAsync();
        }
    }
}
