using EEMod.Tiles.Furniture;
using Terraria.ID;
using Terraria.ModLoader;

namespace EEMod.Items.Placeables.Furniture
{
    public class AirHockeyTable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Air Hockey Table");
            Tooltip.SetDefault("Fun for the whole family!");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 1;
            item.consumable = true;
            item.width = 12;
            item.height = 12;
            item.rare = ItemRarityID.White;

            item.createTile = ModContent.TileType<AirHockeyTableTile>();
        }
    }
}