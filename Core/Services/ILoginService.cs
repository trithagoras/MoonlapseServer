using Moonlapse.Core.Sessions;

namespace Moonlapse.Core.Services; 
public interface ILoginService {
    Task LoginAsync(PlayerSession session, string username, string password);
    Task RegisterAsync(string username, string password);
    Task LogoutAsync(PlayerSession sessionId);
}
