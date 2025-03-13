using Microsoft.AspNetCore.Identity;

namespace BlazorChat.Core.Domain.Entities;

public class User: IdentityUser
{
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    
    public ICollection<GroupUser> Groups { get; set; } = new List<GroupUser>();
    public ICollection<GroupAdmin> AdminRoles { get; set; } = new List<GroupAdmin>();
}