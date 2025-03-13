using System.Collections;

namespace BlazorChat.Core.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }
    
    public ICollection<GroupUser> Members { get; set; } = new List<GroupUser>();
    public ICollection<GroupAdmin> Admins { get; set; } = new List<GroupAdmin>();
}