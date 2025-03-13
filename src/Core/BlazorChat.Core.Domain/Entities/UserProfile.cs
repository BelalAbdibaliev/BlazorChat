namespace BlazorChat.Core.Domain.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "Unknown";
    public string LastName { get; set; } = "Unknown";
    public string ProfileIcon { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}