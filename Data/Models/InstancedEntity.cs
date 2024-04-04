namespace MoonlapseServer.Data.Models;
public class InstancedEntity {
    public int Id { get; set; }
    public virtual required Entity Entity { get; set; }
    public required float X { get; set; }
    public required float Y { get; set; }
}
