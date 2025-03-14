using BlazorChat.Core.Application.Dtos;
using BlazorChat.Core.Application.Hubs;
using BlazorChat.Core.Application.Interfaces;
using BlazorChat.Core.Application.Interfaces.Services;
using BlazorChat.Core.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Core.Application.Services;

public class MessageService: IMessageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHubContext<ChatHub> _hubContext;

    public MessageService(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext)
    {
        _unitOfWork = unitOfWork;
        _hubContext = hubContext;
    }

    public async Task<MessageDto> SendMessageAsync(SendMessageDto messageDto)
    {
        Message message = new Message();
        
        if (messageDto.ChatId == null && messageDto.GroupId == null)
            throw new ArgumentException("Сообщение должно принадлежать либо чату, либо группе.");

        if (messageDto.ChatId != null && messageDto.GroupId != null)
            throw new ArgumentException("Сообщение не может принадлежать одновременно и чату, и группе.");

        if (messageDto.ChatId != null && messageDto.GroupId == null)
        {
            message = new Message
            {
                SenderId = messageDto.SenderId,
                Content = messageDto.Content,
                Date = DateTime.UtcNow,
                ChatId = messageDto.ChatId,
            };
        }

        if (messageDto.ChatId is null && messageDto.GroupId is not null)
        {
            message = new Message
            {
                SenderId = messageDto.SenderId,
                Content = messageDto.Content,
                Date = DateTime.UtcNow,
                GroupId = messageDto.GroupId,
            };
        }

        await _unitOfWork.Messages.Add(message);
        await _unitOfWork.SaveChangesAsync();

        string groupName = messageDto.ChatId != null ? $"chat_{messageDto.ChatId}" : $"group_{messageDto.GroupId}";
        await _hubContext.Clients.Group(groupName).SendAsync("ReceiveMessage", messageDto.SenderId, messageDto.Content);

        return new MessageDto
        {
            Id = message.Id,
            SenderId = message.SenderId,
            Content = message.Content,
            Date = message.Date,
            ChatId = message.ChatId,
            GroupId = message.GroupId
        };
    }
}