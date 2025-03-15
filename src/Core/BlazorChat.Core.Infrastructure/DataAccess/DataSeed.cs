using BlazorChat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorChat.Core.Infrastructure.DataAccess;

public static class DataSeed
{
    public static async Task SeedUsers(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if(dbContext.Users.Any())
            return;

        User user1 = new User
        {
            Email = "sunday@admin.com",
            UserName = "sunday",
            UserProfile = new UserProfile
            {
                FirstName = "Sunday",
                LastName = "Dev",
            }
        };
        User user2 = new User
        {
            Email = "flacko@admin.com",
            UserName = "flacko",
            UserProfile = new UserProfile
            {
                FirstName = "Flacko",
                LastName = "Dev",
            }
        };
        
        await dbContext.Users.AddAsync(user1);
        await dbContext.Users.AddAsync(user2);
        await dbContext.SaveChangesAsync();
    }

    public static async Task SeedGroups(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        if(dbContext.GroupChats.Any())
            return;
        
        var user1 = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == "sunday@admin.com");
        var user2 = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == "flacko@admin.com");

        await dbContext.GroupChats.AddAsync(new GroupChat
        {
            Name = "Group1",
        });
        await dbContext.SaveChangesAsync();
        var group = dbContext.GroupChats.FirstOrDefault();
        
        await dbContext.GroupUsers.AddAsync(new GroupChatUser
        {
            GroupChatId = group.Id,
            UserId = user1.Id,
            Joined = DateTime.UtcNow,
        });
        await dbContext.GroupUsers.AddAsync(new GroupChatUser
        {
            GroupChatId = group.Id,
            UserId = user2.Id,
            Joined = DateTime.UtcNow,
        });
        
        await dbContext.SaveChangesAsync();
    }
}