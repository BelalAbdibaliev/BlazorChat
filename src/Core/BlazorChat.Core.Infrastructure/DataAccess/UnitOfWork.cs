using BlazorChat.Core.Application.Interfaces;
using BlazorChat.Core.Application.Interfaces.Repositories;
using BlazorChat.Core.Application.Interfaces.Services;

namespace BlazorChat.Core.Infrastructure.DataAccess;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IMessageRepository Messages { get; }

    public UnitOfWork(ApplicationDbContext dbContext, IMessageRepository messages)
    {
        _dbContext = dbContext;
        Messages = messages;
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}