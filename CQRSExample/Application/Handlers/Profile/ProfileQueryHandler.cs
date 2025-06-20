using CQRSExample.Application.Models.Profile;
using CQRSExample.Application.Requests.Profile;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Application.Handlers.Profile;

// In this application, the get operation has simple logic and isn't used frequently,
// so there's no need for the overhead of CQRS — a standard approach with a single database is sufficient.
public class ProfileQueryHandler(ViewStore viewStore) : IRequestHandler<GetProfileQuery, ProfileViewModel>
{
    public Task<ProfileViewModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(viewStore.Profiles.GetValueOrDefault(request.Id));
    }
}