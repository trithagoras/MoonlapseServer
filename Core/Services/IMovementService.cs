using MoonlapseServer.Data.Models;
using System.Numerics;

namespace MoonlapseServer.Core.Services; 
public interface IMovementService {
    public void Translate(InstancedEntity instance, float dx, float dy);
}
