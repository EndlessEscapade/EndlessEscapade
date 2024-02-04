using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;

namespace EndlessEscapade.Common.WorldBuilding.Biomes;

public sealed class Sailboat : MicroBiome
{
    public override bool Place(Point origin, StructureMap structures) {
        return true;
    }
}
