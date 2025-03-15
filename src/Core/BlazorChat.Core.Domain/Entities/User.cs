using Microsoft.AspNetCore.Identity;

namespace BlazorChat.Core.Domain.Entities;

public class User: IdentityUser
{
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    
    public ICollection<GroupChatUser> Groups { get; set; } = new List<GroupChatUser>();
    public ICollection<GroupChatAdmin> AdminRoles { get; set; } = new List<GroupChatAdmin>();
}