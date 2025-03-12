namespace BlazorChat.Core.Domain.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "Unknown";
    public string LastName { get; set; } = "Unknown";
    public string ProfilePicUrl { get; set; } = string.Empty;
}