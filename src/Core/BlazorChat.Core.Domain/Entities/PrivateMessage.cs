namespace BlazorChat.Core.Domain.Entities;
public class PrivateMessage
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    
    public int PrivateChatId { get; set; }
    public PrivateChat PrivateChat { get; set; }
}
