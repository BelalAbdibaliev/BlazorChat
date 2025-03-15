using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorChat.Core.Domain.Entities;

public class GroupChatAdmin
{
    public int GroupChatId { get; set; }
    public GroupChat GroupChat { get; set; }
    
    [ForeignKey(nameof(User))]
    public string UserId { get; set; }
    public User User { get; set; }
    
    public string Role { get; set; } = "Admin";
    //Privilege will be displayed bellow
}