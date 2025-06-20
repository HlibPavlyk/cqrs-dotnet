using CQRSExample.Domain;
using CQRSExample.Infrastructure.EventBus.EventRequests;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Infrastructure.Extensions;

public static class SeedDataExtensions
{
    public static async Task SeedInMemoryDataWithEventsAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<Store>();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        if (db.Profiles.Any()) return;

        var profiles = new[]
        {
            new ProfileEntity
            {
                Id = 1,
                DisplayName = "Daria Hnatiuk",
                Bio = "Frontend developer & UX enthusiast.",
                Location = "Kyiv, Ukraine",
                CreatedAt = DateTime.UtcNow.AddYears(-2),
                UpdatedAt = DateTime.UtcNow.AddMonths(-1)
            },
            new ProfileEntity
            {
                Id = 2,
                DisplayName = "Ivan Petrenko",
                Bio = "Backend engineer passionate about clean architecture.",
                Location = "Lviv, Ukraine",
                CreatedAt = DateTime.UtcNow.AddYears(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-20)
            },
            new ProfileEntity
            {
                Id = 3,
                DisplayName = "Sofiia Melnyk",
                Bio = "Product manager with a love for analytics.",
                Location = "Odesa, Ukraine",
                CreatedAt = DateTime.UtcNow.AddYears(-3),
                UpdatedAt = DateTime.UtcNow.AddMonths(-3)
            }
        };

        db.Profiles.AddRange(profiles);
        await db.SaveChangesAsync();

        foreach (var profile in profiles)
        {
            await mediator.Publish(new ProfileUpdatedEventRequest(profile));
        }
    }
}
