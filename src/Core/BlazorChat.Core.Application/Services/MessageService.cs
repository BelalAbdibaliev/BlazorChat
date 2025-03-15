using BlazorChat.Core.Application.Dtos;
using BlazorChat.Core.Application.Hubs;
using BlazorChat.Core.Application.Interfaces;
using BlazorChat.Core.Application.Interfaces.Services;
using BlazorChat.Core.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BlazorChat.Core.Application.Services;

public class MessageService: IMessageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHubContext<GroupChatHub> _hubContext;
    private readonly ILogger<MessageService> _logger;

    public MessageService(IUnitOfWork unitOfWork, IHubContext<GroupChatHub> hubContext, ILogger<MessageService> logger)
    {
        _unitOfWork = unitOfWork;
        _hubContext = hubContext;
        _logger = logger;
    }

    public async Task SendGroupMessageAsync(SendGroupMessageDto groupMessageDto)
    {
        if (groupMessageDto.GroupChatId == 0)
            throw new ArgumentException("GroupChatId is required");

        GroupMessage groupMessage = new GroupMessage
        {
            SenderId = groupMessageDto.SenderId,
            Content = groupMessageDto.Content,
            Date = DateTime.UtcNow,
            GroupChatId = groupMessageDto.GroupChatId,
        };

        await _unitOfWork.Messages.AddAsync(groupMessage);
        await _unitOfWork.SaveChangesAsync();
        
        string groupName = $"group_{groupMessage.GroupChatId}";
        await _hubContext.Clients.Group(groupName).SendAsync("ReceiveMessage", groupMessage.SenderId, groupMessage.Content);
    }

}