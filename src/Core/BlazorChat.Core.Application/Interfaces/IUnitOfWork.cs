using BlazorChat.Core.Application.Interfaces.Repositories;

namespace BlazorChat.Core.Application.Interfaces;

public interface IUnitOfWork
{
    public IMessageRepository Messages { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}