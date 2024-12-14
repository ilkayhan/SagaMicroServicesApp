using Account.API.Consumers;
using Account.API.Model;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Model;
using Serilog;
using Serilog.Sinks.Network;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

builder.Services.AddMassTransit(x => {
    x.AddConsumer<TransferInitiatedEventConsumer>();
    x.AddConsumer<BalanceCheckSuccessEventConsumer>();
    x.AddConsumer<TransactionFailedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ"));
        cfg.ReceiveEndpoint(RabbitMQSettingConst.BalanceCheckEventQueueName_Step1, e =>
        {
            e.ConfigureConsumer<TransferInitiatedEventConsumer>(context);
        });

        cfg.ReceiveEndpoint(RabbitMQSettingConst.TransferSuccesedEventQueueName_Step3, e =>
        {
            e.ConfigureConsumer<BalanceCheckSuccessEventConsumer>(context);
        });

        cfg.ReceiveEndpoint(RabbitMQSettingConst.FailTransferBalanceFix_Step5, e =>
        {
            e.ConfigureConsumer<TransactionFailedEventConsumer>(context);
        });

    });
});


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.TCPSink("tcp://localhost", 5044) // Logstash IP:Port
    .CreateLogger();


builder.Host.UseSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
