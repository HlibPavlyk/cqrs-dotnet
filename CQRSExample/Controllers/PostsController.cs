using CQRSExample.Application.Models.Posts;
using CQRSExample.Application.Requests.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSExample.Controllers;

[ApiController]
[Route("api/posts")]
// In the context of this application, CQRS is necessary for that feature,
// since it's frequently read by many users and needs to be optimized separately from the write operations to ensure performance and scalability.
public class PostsController(IMediator mediator) : Controller
{
    [HttpGet]
    public Task<IEnumerable<PostViewModel>> GetPosts(CancellationToken cancellationToken = default)
    {
        return mediator.Send(new GetPostsQuery(), cancellationToken);
    }
    
    [HttpPost]
    public Task<int> GetPosts(AddPostCommand request, CancellationToken cancellationToken = default)
    {
        return mediator.Send(request, cancellationToken);
    }
}