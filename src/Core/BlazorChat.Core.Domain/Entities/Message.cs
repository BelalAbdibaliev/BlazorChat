namespace BlazorChat.Core.Domain.Entities;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}