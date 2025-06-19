using CQRSExample.Application.Requests.Posts;
using CQRSExample.Domain;
using CQRSExample.Infrastructure.EventBus.EventRequests;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Application.Handlers.Posts;

public class PostsCommandHandler(Store store, IMediator mediator) : IRequestHandler<AddPostCommand, int>
{
    public async Task<int> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var post = new PostEntity { Author = request.Author, Text = request.Text };
        store.Posts.Add(post);
        await store.SaveChangesAsync(cancellationToken);

        await mediator.Publish(new PostAddedEventRequest(post), cancellationToken);

        return post.Id;
    }
}