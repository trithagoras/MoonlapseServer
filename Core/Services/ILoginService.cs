using MmoNet.Core.Sessions;
using MoonlapseServer.Core.Results;
using MoonlapseServer.Core.Sessions;

namespace MoonlapseServer.Core.Services; 
public interface ILoginService {
    Task<LoginResult> LoginAsync(string username, string password);
    //Task<RegisterResult> RegisterAsync(string username, string password);
    Task<LogoutResult> LogoutAsync(PlayerSession sessionId);
}
