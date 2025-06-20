using CQRSExample.Application.Models.Profile;
using CQRSExample.Application.Requests.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSExample.Controllers;

[ApiController]
[Route("api/profile")]
// In the context of this application, CQRS isn't necessary for the profile feature,
// since it's not heavily used and contains only simple logic — a standard CRUD approach with a single database is enough.
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
