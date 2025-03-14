using BlazorChat.Core.Domain.Entities;

namespace BlazorChat.Core.Application.Dtos;

public class SendMessageDto
{
    public string Content { get; set; } = string.Empty;
    
    public string SenderId { get; set; }
    public User Sender { get; set; }

    public int? GroupId { get; set; }
    public Group? Group { get; set; }

    public int? ChatId { get; set; }
    public Chat? Chat { get; set; }
}