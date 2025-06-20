using CQRSExample.Infrastructure.Extensions;
using CQRSExample.Infrastructure.Storages;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Store>(c => c.UseInMemoryDatabase("db"));
builder.Services.AddSingleton<ViewStore>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.Services.SeedInMemoryDataWithEventsAsync();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();