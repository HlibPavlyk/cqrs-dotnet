using CQRSExample.Application.Requests.Posts;
using CQRSExample.Domain;
using CQRSExample.Infrastructure.EventBus.EventRequests;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Application.Handlers.Posts;

// In this application, write operations are complex and occur frequently,
// but reads make up about 90% of all operations.
// Due to this uneven load distribution, CQRS is required
public class PostsCommandHandler(Store store, IMediator mediator) : IRequestHandler<AddPostCommand, int>
{
    public async Task<int> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var post = new PostEntity
        {
            Author = request.Author,
            Content = request.Content,
            ImageUrl = GetImageUrl(),
            CreatedAt = DateTime.UtcNow
        };
        
        store.Posts.Add(post);
        await store.SaveChangesAsync(cancellationToken);

        await mediator.Publish(new PostAddedEventRequest(post), cancellationToken);

        return post.Id;
    }
    
    // Logic to get the image URL after save image to storage
    private string GetImageUrl() => "https://example.com/image.jpg";
}