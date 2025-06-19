using System.Collections.Concurrent;
using CQRSExample.Application.Models.Posts;
using CQRSExample.Application.Models.Profile;

namespace CQRSExample.Infrastructure.Storages;

public class ViewStore
{
    public ConcurrentDictionary<int, PostViewModel> Posts { get; set; } = new();
    public ConcurrentDictionary<int, ProfileViewModel> Profiles { get; set; } = new();
}
