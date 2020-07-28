using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EEMod.Tiles.Furniture;

namespace EEMod.Items.Placeables.Furniture
{
    public class Net : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Net");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
            item.width = 12;
            item.height = 12;
            item.rare = ItemRarityID.White;

            item.createTile = ModContent.TileType<NetTile>();
        }
    }
}