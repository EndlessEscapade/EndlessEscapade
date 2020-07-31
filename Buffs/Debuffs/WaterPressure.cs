using Terraria;
using Terraria.ModLoader;
using EEMod.Projectiles;

namespace EEMod.Buffs.Debuffs
{
    public class WaterPressure : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Water Pressure");
            Description.SetDefault("The water pressure is crushing in");
            Main.buffNoSave[Type] = true;
        }
    }
}