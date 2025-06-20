using CQRSExample.Application.Models.Posts;
using CQRSExample.Application.Models.Profile;
using CQRSExample.Infrastructure.EventBus.EventRequests;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Infrastructure.EventBus;

public class ViewStoreUpdater(ViewStore viewStore) :
    INotificationHandler<PostAddedEventRequest>,
    INotificationHandler<ProfileUpdatedEventRequest>
{
    public Task Handle(PostAddedEventRequest notification, CancellationToken cancellationToken)
    {
        if(notification.Post is not {} post) return Task.CompletedTask;
        
        viewStore.Posts[post.Id] = new PostViewModel
        {
            Author = post.Author,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
        };
        
        return Task.CompletedTask;
    }

    public Task Handle(ProfileUpdatedEventRequest notification, CancellationToken cancellationToken)
    {
        if(notification.Profile is not {} profile) return Task.CompletedTask;

        viewStore.Profiles[profile.Id] = new ProfileViewModel
        {
            DisplayName = profile.DisplayName,
            Bio = profile.Bio,
            Location = profile.Location
        };

        return Task.CompletedTask;
    }
}