using MoonlapseServer.Core.Exceptions;
using MoonlapseServer.Core.Sessions;
using MoonlapseServer.Core.Sessions.States;
using MoonlapseServer.Data;
using MoonlapseServer.Data.Models;

namespace MoonlapseServer.Core.Services;
public class LoginService(IPlayerSessionManager sessionManager, MoonlapseDbContext db) : ILoginService {
    readonly IPlayerSessionManager sessionManager = sessionManager;
    readonly MoonlapseDbContext db = db;

    public async Task LoginAsync(PlayerSession session, string username, string password) {
        // check if the username exists
        var user = db.Users.FirstOrDefault(u => u.Username == username) ?? throw new EntryException("Username or password is incorrect.");

        // check if the password is correct
        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
            throw new EntryException("Username or password is incorrect.");
        }

        session.Player = user.Player;
        session.ChangeState<PlayState>();
    }

    public async Task LogoutAsync(PlayerSession session) {
        session.ChangeState<EntryState>();
    }

    public async Task RegisterAsync(string username, string password) {
        // check if the username is already taken
        var user = db.Users.FirstOrDefault(u => u.Username == username);
        if (user != null) {
            throw new EntryException($"Username: {username} is already taken.");
        }

        // hash the password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        db.Users.Add(new User {
            Username = username,
            PasswordHash = hashedPassword,
            Player = CreatePlayer(username)
        });
        db.SaveChanges();
    }

    Player CreatePlayer(string username) {
        return new Player {
            InstancedEntity = new InstancedEntity {
                Entity = new Entity {
                    Name = username
                },
                X = 0,
                Y = 0
            }
        };
    }
}
