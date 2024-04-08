using Moonlapse.Data.Models;
using System.Numerics;

namespace Moonlapse.Core.Services; 
public interface IMovementService {
    Task Translate(InstancedEntity instance, float dx, float dy);
}
