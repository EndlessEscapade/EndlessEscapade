using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EEMod.Items.Placeables;

namespace EEMod.Tiles.Walls
{
    public class MagmastoneBrickWallTile : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(67, 47, 155));

            Main.wallHouse[Type] = true;
            dustType = 154;
            drop = ModContent.ItemType<MagmastoneBrickWall>();
            soundStyle = 1;
        }
    }
}