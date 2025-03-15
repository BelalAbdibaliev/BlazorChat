using BlazorChat.Core.Domain.Entities;

namespace BlazorChat.Core.Application.Interfaces.Repositories;

public interface IMessageRepository
{
    Task AddAsync(GroupMessage groupMessage);
}