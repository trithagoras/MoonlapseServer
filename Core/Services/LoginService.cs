using MoonlapseServer.Core.Exceptions;
using MoonlapseServer.Core.Sessions;
using MoonlapseServer.Data.Areas.Entry;
using MoonlapseServer.Data.Areas.Entry.Models;

namespace MoonlapseServer.Core.Services;
public class LoginService(IPlayerSessionManager sessionManager, EntryContext db) : ILoginService {
    readonly IPlayerSessionManager sessionManager = sessionManager;
    readonly EntryContext db = db;

    public async Task LoginAsync(PlayerSession session, string username, string password) {
        // check if already logged in
        if (session.LoggedIn) {
            throw new EntryException("Already logged in.");
        }
        // Check if the username exists
        var user = db.Users.FirstOrDefault(u => u.Username == username) ?? throw new EntryException("Username or password is incorrect.");

        // Check if the password is correct
        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
            //return new LoginResult(false, "Username or password is incorrect.");
            throw new EntryException("Username or password is incorrect.");
        }

        // Create a new session TODO: pass user info into session
        session.Login();
    }

    public async Task LogoutAsync(PlayerSession session) {
        // Check if already logged out
        if (!session.LoggedIn) {
            throw new EntryException("Not logged in.");
        }
        session.Logout();
    }

    public async Task RegisterAsync(string username, string password) {
        // Check if the username is already taken
        var user = db.Users.FirstOrDefault(u => u.Username == username);
        if (user != null) {
            throw new EntryException($"Username: {username} is already taken.");
        }

        // Hash the password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        db.Users.Add(new User {
            Username = username,
            PasswordHash = hashedPassword
        });
        db.SaveChanges();
    }
}
