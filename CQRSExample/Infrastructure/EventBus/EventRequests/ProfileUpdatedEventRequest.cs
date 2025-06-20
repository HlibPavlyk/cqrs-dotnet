using CQRSExample.Domain;
using MediatR;

namespace CQRSExample.Infrastructure.EventBus.EventRequests;

public record ProfileUpdatedEventRequest(ProfileEntity Profile) : INotification;
