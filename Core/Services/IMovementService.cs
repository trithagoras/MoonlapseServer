using Moonlapse.Data.Models;
using System.Numerics;

namespace Moonlapse.Core.Services; 
public interface IMovementService {
    public void Translate(InstancedEntity instance, float dx, float dy);
}
