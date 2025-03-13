using BlazorChat.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Core.Infrastructure.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): IdentityDbContext<User>(options)
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<GroupUser> GroupUsers { get; set; }
    public DbSet<GroupAdmin> GroupAdmins { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GroupUser>()
            .HasKey(gu => new { gu.GroupId, gu.UserId });

        modelBuilder.Entity<GroupUser>()
            .HasOne(gu => gu.Group)
            .WithMany(g => g.Members)
            .HasForeignKey(gu => gu.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupUser>()
            .HasOne(gu => gu.User)
            .WithMany(u => u.Groups)
            .HasForeignKey(gu => gu.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupAdmin>()
            .HasKey(ga => new { ga.GroupId, ga.UserId });

        modelBuilder.Entity<GroupAdmin>()
            .HasOne(ga => ga.Group)
            .WithMany(g => g.Admins)
            .HasForeignKey(ga => ga.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupAdmin>()
            .HasOne(ga => ga.User)
            .WithMany()
            .HasForeignKey(ga => ga.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Group)
            .WithMany()
            .HasForeignKey(m => m.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany()
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}