using CQRSExample.Application.Models.Profile;
using MediatR;

namespace CQRSExample.Application.Requests.Profile;

public record GetProfileQuery(int Id) : IRequest<ProfileViewModel>;
