using BlazorChat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Core.Infrastructure.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): IdentityDbContext<User>(options)
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
}