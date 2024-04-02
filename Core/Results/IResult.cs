namespace MoonlapseServer.Core.Results; 
public interface IResult {
    public bool Success { get; }
    public object? Message { get; }
}
