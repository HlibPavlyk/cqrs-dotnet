using CQRSExample.Application.Models.Posts;
using CQRSExample.Application.Requests.Posts;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Application.Handlers.Posts;

// Reading posts is a critical, high-load operation accessed by many users concurrently,
// and would otherwise require complex joins and transformations,
// so CQRS is applied to separate and optimize the read side for better performance
public class PostsQueryHandler(ViewStore viewStore) : IRequestHandler<GetPostsQuery, IEnumerable<PostViewModel>>
{
    public Task<IEnumerable<PostViewModel>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult<IEnumerable<PostViewModel>>(viewStore.Posts.Values);
    }
}