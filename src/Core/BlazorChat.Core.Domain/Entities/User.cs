using Microsoft.AspNetCore.Identity;

namespace BlazorChat.Core.Domain.Entities;

public class User: IdentityUser
{
    public int Id{get;set;}
    public string Username { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
}