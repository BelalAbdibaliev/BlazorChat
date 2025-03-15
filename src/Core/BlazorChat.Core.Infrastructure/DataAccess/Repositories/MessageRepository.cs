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

    public async Task AddAsync<T>(T message, CancellationToken cancellationToken = default)
        where T : class
    {
        await _dbContext.AddAsync(message);
    }
}