namespace MoonlapseServer.Core.Results; 
public class LoginResult(bool success) : IResult {
    public bool Success => success;
    public string? Message => Success ? null : "Login failed";
}
