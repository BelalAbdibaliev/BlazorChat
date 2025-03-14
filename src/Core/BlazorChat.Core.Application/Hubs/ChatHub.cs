using BlazorChat.Core.Application.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Core.Application.Hubs;

public class ChatHub: Hub
{
    public async Task SendMessage(SendMessageDto message)
    {
        if (message.ChatId == null && message.GroupId == null)
            throw new ArgumentException("Сообщение должно принадлежать либо чату, либо группе.");

        string groupName = message.ChatId != null ? $"chat_{message.ChatId}" : $"group_{message.GroupId}";

        await Clients.Group(groupName).SendAsync("ReceiveMessage", message.SenderId, message.Content);
    }

    public async Task JoinChat(int chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"chat_{chatId}");
    }

    public async Task JoinGroup(int groupId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"group_{groupId}");
    }
}