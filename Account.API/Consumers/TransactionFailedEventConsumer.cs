using Account.API.Model;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Account.API.Consumers
{
    public class TransactionFailedEventConsumer : IConsumer<TransactionFailedEvent>
    {
        private readonly AppDbContext _context;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<TransferInitiatedEventConsumer> _logger;

        public TransactionFailedEventConsumer(AppDbContext context, ISendEndpointProvider sendEndpointProvider, IPublishEndpoint publishEndpoint, ILogger<TransferInitiatedEventConsumer> logger)
        {
            _context = context;
            _sendEndpointProvider = sendEndpointProvider;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<TransactionFailedEvent> context)
        {
            var sendeAccount = await _context.Accounts.FirstOrDefaultAsync(d => d.Id == context.Message.SenderUserAccountId);

            if (sendeAccount != null)
            {
                sendeAccount.Balance = sendeAccount.Balance + context.Message.Amount;
                await _context.SaveChangesAsync();
            }
            var receiver = await _context.Accounts.FirstOrDefaultAsync(d => d.Id == context.Message.ReceiverUserAccountId);

            if (receiver != null)
            {
                receiver.Balance = receiver.Balance - context.Message.Amount;
                await _context.SaveChangesAsync();
            }
        }
    }
}
