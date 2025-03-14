using BlazorChat.Core.Application.Interfaces;
using BlazorChat.Core.Application.Interfaces.Repositories;
using BlazorChat.Core.Domain.Entities;
using BlazorChat.Core.Infrastructure.DataAccess;
using BlazorChat.Core.Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorChat.Core.Infrastructure.Extensions;

public static class ServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
        });

        services.AddIdentity<User, IdentityRole>(options =>
            { 
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
            
                options.User.RequireUniqueEmail = true;
            
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        
        return services;
    }
}