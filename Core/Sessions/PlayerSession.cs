using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using MoonlapseServer.Core.Sessions.States;
using MoonlapseServer.Data.Models;
using System.Numerics;

namespace MoonlapseServer.Core.Sessions;
public class PlayerSession(Guid id) : ISession {
    public Guid Id { get; } = id;
    public ISessionState State { get; private set; } = new EntryState();
    public Player Player { get; set; } = null!; // todo: this
    public InstancedEntity Instance => Player.InstancedEntity;

    public void ChangeState<TState>() where TState : ISessionState, new() {
        State = new TState();
    }

    public void Translate(Vector2 offset) {
        Instance.X += offset.X;
        Instance.Y += offset.Y;
    }
}
