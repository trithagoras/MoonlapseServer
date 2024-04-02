using MmoNet.Core.Sessions;

namespace MoonlapseServer.Core.Sessions;
public class PlayerSession(Guid id) : ISession {
    public Guid Id { get; } = id;
    public bool LoggedIn { get; private set; }

    public void Logout() {
        LoggedIn = false;
    }

    public void Login() {
        LoggedIn = true;
    }
}
