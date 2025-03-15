using BlazorChat.Core.Application.Dtos;
using BlazorChat.Core.Domain.Entities;

namespace BlazorChat.Core.Application.Interfaces.Services;

public interface IMessageService
{
    Task SendGroupMessageAsync(SendGroupMessageDto groupMessageDto);
    
}