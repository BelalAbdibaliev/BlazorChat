using BlazorChat.Core.Domain.Entities;

namespace BlazorChat.Core.Application.Dtos;

public class SendGroupMessageDto
{
    public string Content { get; set; } = string.Empty;

    public string SenderId { get; set; }
    public User Sender { get; set; }

    public int GroupChatId { get; set; }
    public GroupChat Group { get; set; }
}