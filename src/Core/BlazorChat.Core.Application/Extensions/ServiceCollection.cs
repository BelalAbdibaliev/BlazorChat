using BlazorChat.Core.Application.Interfaces.Services;
using BlazorChat.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorChat.Core.Application.Extensions;

public static class ServiceCollection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSignalR();
        
        services.AddScoped<IMessageService, MessageService>();
        
        return services;
    }
}