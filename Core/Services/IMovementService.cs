using Moonlapse.Data.Models;
using System.Numerics;

namespace Moonlapse.Core.Services; 
public interface IMovementService {
    void BeginTranslate(int instanceId, float dx, float dy);
}
