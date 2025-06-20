using CQRSExample.Application.Requests.Profile;
using CQRSExample.Infrastructure.EventBus.EventRequests;
using CQRSExample.Infrastructure.Storages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Application.Handlers.Profile;

// In this application, the update operation has simple logic and isn't used frequently,
// so there's no need for the overhead of CQRS — a standard approach with a single database is sufficient
public class ProfileCommandHandler(Store store, IMediator mediator) : IRequestHandler<UpdateProfileCommand, int>
{
    public async Task<int> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await store.Profiles.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        if (profile == null)
            throw new KeyNotFoundException($"Profile with ID {request.Id} not found.");

        profile.DisplayName = request.Model.DisplayName;
        profile.Location = request.Model.Location;
        profile.Bio = request.Model.Bio;
        profile.UpdatedAt = DateTime.UtcNow;

        await store.SaveChangesAsync(cancellationToken);
        
        await mediator.Publish(new ProfileUpdatedEventRequest(profile), cancellationToken);

        return profile.Id;
        
    }
}