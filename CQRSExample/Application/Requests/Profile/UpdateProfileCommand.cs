using CQRSExample.Application.Models.Profile;
using MediatR;

namespace CQRSExample.Application.Requests.Profile;

public record UpdateProfileCommand(int Id, UpdateProfileModel Model) : IRequest<int>;
