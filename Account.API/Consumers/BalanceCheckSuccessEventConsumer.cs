using Account.API.Model;
using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using Shared.Model;
using static Shared.Model.Enums;

namespace Account.API.Consumers
{
    public class BalanceCheckSuccessEventConsumer : IConsumer<BalanceCheckSuccessEvent>
    {
        private readonly AppDbContext _context;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<TransferInitiatedEventConsumer> _logger;

        public BalanceCheckSuccessEventConsumer(AppDbContext context, ISendEndpointProvider sendEndpointProvider, IPublishEndpoint publishEndpoint, ILogger<TransferInitiatedEventConsumer> logger)
        {
            _context = context;
            _sendEndpointProvider = sendEndpointProvider;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BalanceCheckSuccessEvent> context)
        {
            try
            {
                var senderAccount = await _context.Accounts.FirstOrDefaultAsync(d => d.Id == context.Message.SenderAccountId);
                var receiverAccount = await _context.Accounts.FirstOrDefaultAsync(d => d.Id == context.Message.ReceiverAccountId);


                if (senderAccount != null && receiverAccount != null)
                {
                    senderAccount.Balance = senderAccount.Balance - context.Message.Amount;

                    receiverAccount.Balance = receiverAccount.Balance + context.Message.Amount;

                    await _context.SaveChangesAsync();

                    _logger.LogInformation("{0} Göndericisinin bakiyesinden {1} {2} düşürüldü.", context.Message.SenderAccountId, context.Message.Amount, context.Message.Currency);
                    _logger.LogInformation("{0} Alıcının bakiyesine {1} {2} para girişi oldu.", context.Message.ReceiverAccountId, context.Message.Amount, context.Message.Currency);

                    var sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingConst.TransferSuccesedEventQueueName_Step3}"));

                    TransactionSuccessedEvent transactionSuccessedEvent = new TransactionSuccessedEvent()
                    {
                        TransferId = context.Message.TransferId,
                        ReceiverUserAccountId = context.Message.ReceiverAccountId,
                        SenderUserAccountId = context.Message.SenderAccountId,
                        Amount = context.Message.Amount,
                    };
                    await sendEndPoint.Send(transactionSuccessedEvent);
                }
            }
            catch (Exception ex)
            {
                await _publishEndpoint.Publish(new TransactionCompletedEvent()
                {
                    TransferId = context.Message.TransferId,
                    Status = (int)TransactionStatus.Failed,
                    Message = ex.Message.ToString()
                });
            }
        }
    }
}
