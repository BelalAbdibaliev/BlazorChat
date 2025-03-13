using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorChat.Core.Domain.Entities;

public class GroupUser
{
    public int GroupId { get; set; }
    public Group Group { get; set; }
    
    [ForeignKey(nameof(User))]
    public string UserId { get; set; }
    public User User { get; set; }
    
    public DateTime Joined { get; set; }
}