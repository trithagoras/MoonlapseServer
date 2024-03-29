namespace MoonlapseServer.Core.Results; 
public class LogoutResult(bool success, string? message = null) : IResult {
    public bool Success => success;
    public string? Message => message;
}
