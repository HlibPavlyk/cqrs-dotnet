using MediatR;

namespace CQRSExample.Application.Requests.Posts;

public record AddPostCommand(string Author, string Text) : IRequest<int>;