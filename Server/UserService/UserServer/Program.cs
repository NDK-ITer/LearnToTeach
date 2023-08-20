using Application.Services;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using SendMail.ClassDefine;
using SendMail.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthConnectString");
// Add services to the container.

builder.Services.AddControllers();
// add Entity framework
builder.Services.AddDbContext<AuthenticationDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_UserService, UnitOfWork_UserService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
