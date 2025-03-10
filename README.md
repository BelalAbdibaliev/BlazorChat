Running tips:
  1. git clone https://github.com/BelalAbdibaliev/BlazorChat
  2. docker compose -f docker/docker-compose.yml up -d
  3. cd src/Core/BlazorChat.Core.Infrastructure
  4. dotnet ef database update --startup-project ../../UI/Presentation/Presentation.csproj
