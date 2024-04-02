namespace MoonlapseServer.Core.Results; 
public class LogoutResult(bool success, string? message = null) : Result(success, message) {
}
