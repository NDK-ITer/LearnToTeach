using MassTransit;
using SagaOrchestration.Models;
using Microsoft.EntityFrameworkCore;
using RabbitMQ_Lib;
using SagaStateMachine.ClassroomService.Classroom;
using SagaStateMachine.ClassroomService.Member;
using SagaStateMachine.UserService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SagaConnectionString");
var queue = builder.Configuration.GetSection("Endpoints");

builder.Services.Configure<RabbitMQQueues>(queue);
builder.Services.AddDbContext<SagaDbContext>(opt => opt.UseSqlServer(connectionString));
// Register SagaContext
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddBus(provider => RabbitMQ_Lib.RabbitMQ.ConfigureBus(provider));
    cfg.AddSagaStateMachine<ClassroomStateMachine, ClassroomStateData>()
        .EntityFrameworkRepository(r =>
        {
            r.ConcurrencyMode = ConcurrencyMode.Pessimistic;
            r.ExistingDbContext<SagaDbContext>();
        });

    cfg.AddSagaStateMachine<MemberStateMachine, MemberStateData>()
        .EntityFrameworkRepository(r =>
        {
            r.ConcurrencyMode = ConcurrencyMode.Pessimistic;
            r.ExistingDbContext<SagaDbContext>();
        }); ;
    cfg.AddSagaStateMachine<UserStateMachine, UserStateData>()
        .EntityFrameworkRepository(r =>
        {
            r.ConcurrencyMode = ConcurrencyMode.Pessimistic;
            r.ExistingDbContext<SagaDbContext>();
        }); ;
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
