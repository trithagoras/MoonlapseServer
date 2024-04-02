using MoonlapseServer.Core.Sessions;

namespace MoonlapseServer.Core.Results; 
public class LoginResult(bool success, string? message = null) : Result(success, message) {
}
