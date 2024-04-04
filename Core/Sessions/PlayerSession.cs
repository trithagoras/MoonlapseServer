using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MoonlapseServer.Core.Sessions.States;
using System.Numerics;

namespace MoonlapseServer.Core.Sessions;
public class PlayerSession(Guid id) : ISession {
    public Guid Id { get; } = id;
    public ISessionState State { get; private set; } = new EntryState();
    public Vector2 Position { get; set; } = Vector2.Zero;

    public void ChangeState<TState>() where TState : ISessionState, new() {
        State = new TState();
    }

    public void Translate(Vector2 offset) {
        Position += offset;
    }
}
