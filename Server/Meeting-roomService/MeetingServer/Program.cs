using MeetingServer.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyMethod()
               .AllowAnyHeader()
               .AllowAnyOrigin()
               .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<TrackingHub>("/tracking");
});

app.Run();
