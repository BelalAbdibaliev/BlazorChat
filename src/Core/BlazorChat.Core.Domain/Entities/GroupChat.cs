using System.Collections;

namespace BlazorChat.Core.Domain.Entities;

public class GroupChat
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    
    public ICollection<GroupChatUser> Members { get; set; } = new List<GroupChatUser>();
    public ICollection<GroupChatAdmin> Admins { get; set; } = new List<GroupChatAdmin>();
}