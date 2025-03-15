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
    private readonly IHubContext<GroupChatHub> _hubContext;

    public MessageService(IUnitOfWork unitOfWork, IHubContext<GroupChatHub> hubContext)
    {
        _unitOfWork = unitOfWork;
        _hubContext = hubContext;
    }

    public async Task SendGroupMessageAsync(SendGroupMessageDto groupMessageDto)
    {
        if (groupMessageDto.GroupChatId == null)
            throw new ArgumentException("Сообщение должно принадлежать либо чату, либо группе.");

        GroupMessage groupMessage = new GroupMessage
        {
            SenderId = groupMessageDto.SenderId,
            Content = groupMessageDto.Content,
            Date = DateTime.UtcNow,
            GroupChatId = groupMessageDto.GroupChatId,
        };

        await _unitOfWork.Messages.AddAsync(groupMessage);
        await _unitOfWork.SaveChangesAsync();

        await _hubContext.Clients.Group($"chat_{groupMessageDto.GroupChatId}").SendAsync("ReceiveMessage", groupMessageDto.SenderId, groupMessageDto.Content);
    }

}