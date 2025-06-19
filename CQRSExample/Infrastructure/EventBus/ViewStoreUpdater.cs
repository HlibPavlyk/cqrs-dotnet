using CQRSExample.Application.Models.Posts;
using CQRSExample.Infrastructure.EventBus.EventRequests;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Infrastructure.EventBus;

public class ViewStoreUpdater(ViewStore viewStore) :
    INotificationHandler<PostAddedEventRequest>
{
    public Task Handle(PostAddedEventRequest notification, CancellationToken cancellationToken)
    {
        if(notification.Post == null) return Task.CompletedTask;
        
        viewStore.Posts[notification.Post.Id] = new PostViewModel
        {
            Author = notification.Post.Author,
            Text = notification.Post.Text
        };
        
        return Task.CompletedTask;
    }
}