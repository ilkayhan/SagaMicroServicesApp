using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using Transfer.API.DTOs;
using Transfer.API.Model;

namespace Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public TransferController(AppDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }


        [HttpPost]
        public async Task<IActionResult> Create(TransferCreateDTO transfer)
        {
            #region [ DB ADD ]
            var newTransfer = new Model.TransferRequest
            {
                Amount = transfer.Amount,
                Currency = transfer.Currency,
                Description = transfer.Description,
                ReceiverAccountId = transfer.ReceiverAccountId,
                SenderAccountId = transfer.SenderAccountId,
                RequestedAt = DateTime.Now,
            };
            await _context.AddAsync(newTransfer);
            await _context.SaveChangesAsync();
            #endregion


            #region [ EVENT PUBLISH ]

            var transferCreateEvent = new TransferInitiatedEvent()
            {
                ReceiverAccountId = transfer.ReceiverAccountId,
                SenderAccountId = transfer.SenderAccountId,
                Amount = transfer.Amount,
                Currency = transfer.Currency,
                Description= transfer.Description,
                Timestamp = newTransfer.RequestedAt,
                TransferId = newTransfer.Id
            };

              //RabbitMQ ya gönderilir.
             await  _publishEndpoint.Publish(transferCreateEvent);

            #endregion
            return Ok();
        }
    }
}
