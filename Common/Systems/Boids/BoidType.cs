using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace EndlessEscapade.Common.Systems.Boids;

public readonly struct BoidType
{
    public readonly float MaxForce = 0.001f;
    public readonly float MaxVision = 512f;
    public readonly float MaxVelocity = 1f;
    
    public readonly string Name;
    
    public BoidType(string name) {
        Name = name;
    }
}
