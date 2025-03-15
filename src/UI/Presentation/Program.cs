using BlazorChat.Core.Application.Extensions;
using BlazorChat.Core.Application.Hubs;
using BlazorChat.Core.Domain.Entities;
using BlazorChat.Core.Infrastructure.DataAccess;
using BlazorChat.Core.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Presentation.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await app.Services.SeedUsers();
await app.Services.SeedGroups();

await app.Services.SeedGroups();
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<GroupChatHub>("/chathub");

app.Run();
