using CQRSExample.Application.Models.Posts;
using CQRSExample.Application.Requests.Posts;
using CQRSExample.Infrastructure.Storages;
using MediatR;

namespace CQRSExample.Application.Handlers.Posts;

public class PostsQueryHandler(ViewStore viewStore) : IRequestHandler<GetPostsQuery, IEnumerable<PostViewModel>>
{
    public Task<IEnumerable<PostViewModel>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult<IEnumerable<PostViewModel>>(viewStore.Posts.Values);
    }
}