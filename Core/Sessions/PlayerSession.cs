using MmoNet.Core.Sessions;
using MmoNet.Core.States;
using Moonlapse.Core.Sessions.States;
using Moonlapse.Data.Models;

namespace Moonlapse.Core.Sessions;
public class PlayerSession(Guid id) : ISession {
    public Guid Id { get; } = id;
    public ISessionState State { get; private set; } = new EntryState();
    public Player? Player { get; set; } = null; // todo: this
    public InstancedEntity? Instance => Player?.InstancedEntity;

    public void ChangeState<TState>() where TState : ISessionState, new() {
        State = new TState();
    }
}
