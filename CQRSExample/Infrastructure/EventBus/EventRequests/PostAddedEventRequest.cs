using CQRSExample.Domain;
using MediatR;

namespace CQRSExample.Infrastructure.EventBus.EventRequests;

public record PostAddedEventRequest(PostEntity Post) : INotification;