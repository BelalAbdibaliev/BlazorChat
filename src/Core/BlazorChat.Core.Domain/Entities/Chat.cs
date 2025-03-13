namespace BlazorChat.Core.Domain.Entities;

public class Chat
{
    public int Id { get; set; }
    
    public string FirstUserId { get; set; }
    public User FirstUser { get; set; } = null!;
    
    public string SecondUserId { get; set; }
    public User SecondUser { get; set; }
}