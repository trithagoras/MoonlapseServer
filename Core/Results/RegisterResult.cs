namespace MoonlapseServer.Core.Results;
public class RegisterResult(bool success, string? message = null) : Result(success, message) {
}
