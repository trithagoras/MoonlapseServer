using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MoonlapseServer.Core.Sessions.States;

namespace MoonlapseServer.Core.Sessions;
public class PlayerSession(Guid id) : ISession {
    public Guid Id { get; } = id;
    public ISessionState State { get; private set; } = new EntryState();
    public bool LoggedIn { get; private set; }

    public void ChangeState<TState>() where TState : ISessionState, new() {
        State = new TState();
    }
}
