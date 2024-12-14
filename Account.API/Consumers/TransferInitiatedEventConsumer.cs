using Account.API.Model;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Model;
using static Shared.Model.Enums;

namespace Account.API.Consumers
{
    public class TransferInitiatedEventConsumer : IConsumer<TransferInitiatedEvent>
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<TransferInitiatedEventConsumer> _logger;

        public TransferInitiatedEventConsumer(AppDbContext context, IPublishEndpoint publishEndpoint, ILogger<TransferInitiatedEventConsumer> logger)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<TransferInitiatedEvent> context)
        {
            bool balanceChekResult = false;
            long senderAccountId = context.Message.SenderAccountId;
            decimal amount = context.Message.Amount;
            var senderAccount = await _context.Accounts.FirstOrDefaultAsync(d => d.Id == senderAccountId);

            if (senderAccount != null)
            {
                if (senderAccount.Balance >= amount)
                {
                    balanceChekResult = true;
                }

                if (balanceChekResult)
                {
                    _logger.LogInformation("{0} Göndericisinin bakiyesi transfer için uygun.", senderAccountId);

                    BalanceCheckSuccessEvent balanceCheckSuccessEvent = new BalanceCheckSuccessEvent()
                    {
                        SenderAccountId = context.Message.SenderAccountId,
                        ReceiverAccountId = context.Message.ReceiverAccountId,
                        TransferId = context.Message.TransferId,

                        Amount = amount,
                    };

                    await _publishEndpoint.Publish(balanceCheckSuccessEvent);
                }
                else
                {
               
                    _logger.LogInformation("Bakiye yetersiz");

                    await _publishEndpoint.Publish(new TransactionCompletedEvent()
                    {
                        TransferId = context.Message.TransferId,
                        Status = (int)TransactionStatus.NotEnoughSenderBalance
                    });

                }
            }
        }
    }
}
