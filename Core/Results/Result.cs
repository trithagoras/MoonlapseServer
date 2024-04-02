namespace MoonlapseServer.Core.Results; 
public class Result(bool success, object? message = null) : IResult {
    public bool Success { get; } = success;
    public object? Message { get; } = message;
}
