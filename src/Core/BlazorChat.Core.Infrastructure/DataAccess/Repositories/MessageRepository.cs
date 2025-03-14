using BlazorChat.Core.Application.Interfaces.Repositories;
using BlazorChat.Core.Domain.Entities;

namespace BlazorChat.Core.Infrastructure.DataAccess.Repositories;

public class MessageRepository: IMessageRepository
{
    private readonly ApplicationDbContext _dbContext;

    public MessageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Message message)
    {
        await _dbContext.Messages.AddAsync(message);
    }
}