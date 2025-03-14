using BlazorChat.Core.Domain.Entities;

namespace BlazorChat.Core.Application.Dtos;

public class MessageDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    

    public string SenderId { get; set; }
    public User Sender { get; set; }

    public int? GroupId { get; set; }
    public Group? Group { get; set; }

    public int? ChatId { get; set; }
    public Chat? Chat { get; set; }
}