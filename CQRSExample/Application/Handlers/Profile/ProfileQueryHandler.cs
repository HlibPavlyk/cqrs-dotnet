using CQRSExample.Application.Models.Profile;
using CQRSExample.Application.Requests.Profile;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Application.Handlers.Profile;

public class ProfileQueryHandler(ViewStore viewStore) : IRequestHandler<GetProfileQuery, ProfileViewModel>
{
    public Task<ProfileViewModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(viewStore.Profiles.GetValueOrDefault(request.Id));
    }
}