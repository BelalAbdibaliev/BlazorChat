namespace BlazorChat.Core.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public List<User> Members { get; set; } = new List<User>();
    public List<Message> Messages { get; set; } = new List<Message>();
}