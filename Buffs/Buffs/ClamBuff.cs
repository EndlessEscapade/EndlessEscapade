using Terraria;
using Terraria.ModLoader;
using EEMod.Projectiles;

namespace EEMod.Buffs.Buffs
{
    public class ClamBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Clam");
            Description.SetDefault("The small clam fights for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}