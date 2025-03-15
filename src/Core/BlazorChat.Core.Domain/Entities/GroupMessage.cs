using System.Text.RegularExpressions;

namespace BlazorChat.Core.Domain.Entities;

public class GroupMessage
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    
    public string SenderId { get; set; }
    public User Sender { get; set; }
    
    public int GroupChatId { get; set; }
    public GroupChat GroupChat { get; set; }
    
}