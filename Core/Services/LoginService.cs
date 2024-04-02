using MoonlapseServer.Core.Results;
using MoonlapseServer.Core.Sessions;
using MoonlapseServer.Data.Areas.Entry;
using MoonlapseServer.Data.Areas.Entry.Models;

namespace MoonlapseServer.Core.Services;
public class LoginService(IPlayerSessionManager sessionManager, EntryContext db) : ILoginService {
    readonly IPlayerSessionManager sessionManager = sessionManager;
    readonly EntryContext db = db;

    public async Task<LoginResult> LoginAsync(PlayerSession session, string username, string password) {
        // Check if the username exists
        var user = db.Users.FirstOrDefault(u => u.Username == username);
        if (user == null) {
            return new LoginResult(false, "Username or password is incorrect.");
        }

        // Check if the password is correct
        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
            return new LoginResult(false, "Username or password is incorrect.");
        }

        // Create a new session TODO: pass user info into session
        session.Login();
        return new LoginResult(true);
    }

    public async Task<LogoutResult> LogoutAsync(PlayerSession session) {
        session.Logout();
        return new LogoutResult(true);
    }

    public async Task<RegisterResult> RegisterAsync(string username, string password) {
        // Check if the username is already taken
        var user = db.Users.FirstOrDefault(u => u.Username == username);
        if (user != null) {
            return new RegisterResult(false, "Username is already taken");
        }

        // Hash the password
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        db.Users.Add(new User {
            Username = username,
            PasswordHash = hashedPassword
        });
        db.SaveChanges();
        return new RegisterResult(true);
    }
}
