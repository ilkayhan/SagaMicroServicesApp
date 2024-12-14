using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using Shared.Model;
using Transaction.API.Model;

namespace Transaction.API.Consumers
{
    public class TransactionSuccessedEventConsumer : IConsumer<TransactionSuccessedEvent>
    {
        private readonly ILogger<TransactionSuccessedEventConsumer> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly AppDbContext _context;

        public TransactionSuccessedEventConsumer(ILogger<TransactionSuccessedEventConsumer> logger, IPublishEndpoint publishEndpoint, AppDbContext context)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _context = context;
        }

        public async Task Consume(ConsumeContext<TransactionSuccessedEvent> context)
        {
            if (context.Message.ReceiverUserAccountId == 5)
            {
                // yukarıdaki condition hatalı senaryo için oluşturuldu
                // Log
                await _publishEndpoint.Publish(new TransactionCompletedEvent()
                {
                    TransferId = context.Message.TransferId,
                    Status = (int)TransactionStatus.Failed,
                    Message = "Deneme hatalı case"
                });


                // bakiyeyi düzelt
                await _publishEndpoint.Publish(new TransactionFailedEvent()
                {
                    SenderUserAccountId = context.Message.SenderUserAccountId,
                    ReceiverUserAccountId = context.Message.ReceiverUserAccountId,
                    Amount = context.Message.Amount
                });
            }
            else
            {
                TransactionRequest newTransaction = new TransactionRequest()
                {
                    CreatedAt = DateTime.Now,
                    Status = TransactionStatus.Completed,
                    TransferId = context.Message.TransferId
                };

                await _context.AddAsync(newTransaction);
                await _context.SaveChangesAsync();

                await _publishEndpoint.Publish(new TransactionCompletedEvent()
                {
                    TransferId = context.Message.TransferId,
                    TransactionId = newTransaction.Id,
                    Status = (int)TransactionStatus.Completed,
                });
            }
          
        }
    }
}
