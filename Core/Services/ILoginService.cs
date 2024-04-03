using MoonlapseServer.Core.Sessions;

namespace MoonlapseServer.Core.Services; 
public interface ILoginService {
    Task LoginAsync(PlayerSession session, string username, string password);
    Task RegisterAsync(string username, string password);
    Task LogoutAsync(PlayerSession sessionId);
}
