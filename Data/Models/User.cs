namespace MoonlapseServer.Data.Models;
public class User {
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public virtual required Player Player { get; set; }
}
