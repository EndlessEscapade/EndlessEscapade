using EEMod.ID;
using EEMod.Systems.Subworlds.EESubworlds;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EEMod.Items
{
    public class Conch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Conch");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 34;
            item.maxStack = 1;
            item.useAnimation = 12;
            item.useTime = 12;
            item.consumable = false;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Sounds/ConchBlown");
        }

        public override bool UseItem(Player player)
        {
            Main.LocalPlayer.GetModPlayer<EEPlayer>().Initialize();
            SubworldManager.EnterSubworld<CoralReefs>(); 
            return true;
        }
    }
}