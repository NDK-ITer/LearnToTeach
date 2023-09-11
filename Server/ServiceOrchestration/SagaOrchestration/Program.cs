using MassTransit;
using SagaOrchestration.Models;
using SagaStateMachine.Classrooms;
using SagaStateMachine.Classrooms.AddClassroomState;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SagaConnectionString");

builder.Services.AddDbContext<SagaDbContext>(opt => opt.UseSqlServer(connectionString));
// Register SagaContext
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddBus(provider => RabbitMQ_Lib.RabbitMQ.ConfigureBus(provider));
    cfg.AddSagaStateMachine<ClassroomStateMachine, ClassroomStateData>();
    cfg.AddSagaStateMachine<MemberStateMachine, MemberStateData>();
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
