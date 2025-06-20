using CQRSExample.Application.Models.Posts;
using CQRSExample.Application.Requests.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSExample.Controllers;

[ApiController]
[Route("api/posts")]
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