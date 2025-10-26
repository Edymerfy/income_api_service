using Services.Tax.Api;
using Services.Tax.Api.Middleware;
using Services.Tax.Domain.Configuration;
using Services.Tax.Infrastructure;
using Services.Tax.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SecurityOptions>(
    builder.Configuration.GetSection("Security"));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterWebApi(builder.Configuration);
builder.Services.RegisterInfrastructure();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();