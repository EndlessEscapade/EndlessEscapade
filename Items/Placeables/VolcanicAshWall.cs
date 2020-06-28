using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EEMod.Tiles.Walls;

namespace EEMod.Items.Placeables
{
    public class VolcanicAshWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Volcanic Ash Wall");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 7;
            item.consumable = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.maxStack = 999;
            item.createWall = ModContent.WallType<VolcanicAshWallTile>();
        }
    }
}