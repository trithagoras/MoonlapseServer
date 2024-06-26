﻿using MmoNet.Core.Sessions;

namespace Moonlapse.Core.Sessions;
public class PlayerSessionManager : IPlayerSessionManager {
    readonly Dictionary<Guid, ISession> sessions = [];

    public ISession this[Guid id] {
        get {
            if (sessions.TryGetValue(id, out ISession? value)) {
                return value;
            }
            throw new KeyNotFoundException($"Session with id {id} not found.");
        }
        set {
            sessions[id] = value;
        }
    }

    public IEnumerable<ISession> Sessions => sessions.Values;

    public ISession CreateSession() {
        var guid = Guid.NewGuid();
        var session = new PlayerSession(guid);
        sessions.Add(guid, session);
        return session;
    }

    public void RemoveSession(Guid id) {
        sessions.Remove(id);
    }

    public PlayerSession? GetSessionByUsername(string username) {
        foreach (var session in sessions.Values) {
            if (session is PlayerSession playerSession && playerSession.Instance?.Entity.Name == username) {
                return playerSession;
            }
        }
        return null;
    }
}
