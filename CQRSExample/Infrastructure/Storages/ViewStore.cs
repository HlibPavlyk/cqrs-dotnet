using System.Collections.Concurrent;
using CQRSExample.Application.Models.Posts;
using CQRSExample.Application.Models.Profile;

namespace CQRSExample.Infrastructure.Storages;

// Read view store uses ConcurrentDictionary here but can be replaced with other storages like Redis
public class ViewStore
{
    public ConcurrentDictionary<int, PostViewModel> Posts { get; } = new();
    public ConcurrentDictionary<int, ProfileViewModel> Profiles { get; } = new();
}
