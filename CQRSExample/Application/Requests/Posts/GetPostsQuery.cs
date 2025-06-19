using CQRSExample.Application.Models.Posts;
using MediatR;

namespace CQRSExample.Application.Requests.Posts;

public record GetPostsQuery : IRequest<IEnumerable<PostViewModel>>;