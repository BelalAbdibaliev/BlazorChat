using BlazorChat.Core.Application.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Core.Application.Hubs;

public class GroupChatHub: Hub
{
    public async Task SendMessage(SendGroupMessageDto groupMessage)
    {
        if (groupMessage.GroupChatId is 0)
            throw new ArgumentException("Group ID can't be zero");

        string groupName = $"group_{groupMessage.GroupChatId}";
        await Clients.Group(groupName).SendAsync("ReceiveMessage", groupMessage.SenderId, groupMessage.Content);
    }

    public async Task JoinGroup(int groupId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"group_{groupId}");
    }
}