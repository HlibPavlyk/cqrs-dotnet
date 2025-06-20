using CQRSExample.Application.Models.Profile;
using CQRSExample.Application.Requests.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSExample.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController(IMediator mediator) : Controller
{
   
    [HttpGet("{id:int}")]
    public Task<ProfileViewModel> GetProfile(int id, CancellationToken cancellationToken = default)
    {
        return mediator.Send(new GetProfileQuery(id), cancellationToken);
    }
    
    [HttpPut("{id:int}")]
    public Task<int> GetPosts(int id, UpdateProfileModel model, CancellationToken cancellationToken = default)
    {
        return mediator.Send(new UpdateProfileCommand(id, model), cancellationToken);
    } 
}
