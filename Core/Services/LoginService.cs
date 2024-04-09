using Microsoft.EntityFrameworkCore;
using Moonlapse.Core.Exceptions;
using Moonlapse.Core.Sessions;
using Moonlapse.Core.Sessions.States;
using Moonlapse.Data.DbContexts;
using Moonlapse.Data.Models;

namespace Moonlapse.Core.Services;
public class LoginService(IPlayerSessionManager sessionManager, MoonlapseDbContext db) : ILoginService {
    readonly IPlayerSessionManager sessionManager = sessionManager;
    readonly MoonlapseDbContext db = db;

    public async Task LoginAsync(PlayerSession session, string username, string password) {
        // check if the username exists
        var user = await db.Users.FirstOrDefaultAsync(u => u.Username == username) ?? throw new EntryException("Username or password is incorrect.");

        // check if user is already logged in TODO: this better
        if (sessionManager.GetSessionByUsername(username) != null) {
            throw new EntryException("User is already logged in.");
        }

        // check if the password is correct
        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
            throw new EntryException("Username or password is incorrect.");
        }

        session.Player = user.Player;
        user.LastLoggedInAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
        session.ChangeState<PlayState>();
    }

    public async Task LogoutAsync(PlayerSession session) {
        await db.SaveChangesAsync();
        session.ChangeState<EntryState>();
    }

    public async Task RegisterAsync(string username, string password) {
        // check if the username is already taken
        var user = await db.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user != null) {
            throw new EntryException($"Username: {username} is already taken.");
        }

        // hash the password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        db.Users.Add(new User {
            Username = username,
            PasswordHash = hashedPassword,
            Player = CreatePlayer(username),
            CreatedAt = DateTime.UtcNow
        });
        await db.SaveChangesAsync();
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
