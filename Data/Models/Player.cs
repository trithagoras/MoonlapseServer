namespace MoonlapseServer.Data.Models;
public class Player {
    public int Id { get; set; }
    public virtual required InstancedEntity InstancedEntity { get; set; }
}
