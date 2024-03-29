using MmoNet.Core.Sessions;
using MoonlapseServer.Core.Results;
using MoonlapseServer.Core.Sessions;

namespace MoonlapseServer.Core.Services;
public class LoginService(ISessionManager sessionManager) : ILoginService {
    readonly ISessionManager sessionManager = sessionManager;

    public async Task<LoginResult> LoginAsync(string username, string password) {
        return new LoginResult(false);
    }

    public async Task<LogoutResult> LogoutAsync(PlayerSession session) {
        sessionManager.RemoveSession(session.Id);
        return new LogoutResult(true);
    }
}
