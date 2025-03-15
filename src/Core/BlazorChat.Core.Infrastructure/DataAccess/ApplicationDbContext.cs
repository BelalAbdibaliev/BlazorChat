using BlazorChat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Core.Infrastructure.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): IdentityDbContext<User>(options)
{
    public DbSet<PrivateChat> PrivateChats { get; set; }
    public DbSet<PrivateMessage> PrivateMessages { get; set; }
    public DbSet<GroupChat> GroupChats { get; set; }
    public DbSet<GroupMessage> GroupMessages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<GroupChatUser> GroupUsers { get; set; }
    public DbSet<GroupChatAdmin> GroupAdmins { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GroupChatUser>()
            .HasKey(gu => new { gu.GroupChatId, gu.UserId });

        modelBuilder.Entity<GroupChatUser>()
            .HasOne(gu => gu.GroupChat)
            .WithMany(g => g.Members)
            .HasForeignKey(gu => gu.GroupChatId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupChatUser>()
            .HasOne(gu => gu.User)
            .WithMany(u => u.Groups)
            .HasForeignKey(gu => gu.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupChatAdmin>()
            .HasKey(ga => new { GroupId = ga.GroupChatId, ga.UserId });

        modelBuilder.Entity<GroupChatAdmin>()
            .HasOne(ga => ga.GroupChat)
            .WithMany(g => g.Admins)
            .HasForeignKey(ga => ga.GroupChatId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupChatAdmin>()
            .HasOne(ga => ga.User)
            .WithMany()
            .HasForeignKey(ga => ga.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PrivateMessage>()
            .HasOne(m => m.PrivateChat)
            .WithMany()
            .HasForeignKey(m => m.PrivateChatId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<GroupMessage>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<GroupMessage>()
            .HasOne(m => m.GroupChat)
            .WithMany()
            .HasForeignKey(m => m.GroupChatId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}