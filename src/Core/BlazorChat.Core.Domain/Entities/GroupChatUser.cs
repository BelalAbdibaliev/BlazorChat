using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorChat.Core.Domain.Entities;

public class GroupChatUser
{
    public int GroupChatId { get; set; }
    public GroupChat GroupChat { get; set; }
    
    [ForeignKey(nameof(User))]
    public string UserId { get; set; }
    public User User { get; set; }
    
    public DateTime Joined { get; set; }
}