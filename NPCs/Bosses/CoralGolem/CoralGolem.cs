using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EEMod.Compatibility;

namespace EEMod.NPCs.Bosses.CoralGolem
{
    public class CoralGolem : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Golem");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.lavaImmune = true;
            npc.friendly = false;
            npc.noGravity = true;
            npc.aiStyle = -1;
            npc.lifeMax = 50000;
            npc.defense = 40;
            npc.damage = 95;
            npc.value = Item.buyPrice(0, 8, 0, 0);
            npc.noTileCollide = true;
            npc.width = 250;
            npc.height = 230;
            drawOffsetY = 40;

            npc.npcSlots = 24f;
            npc.knockBackResist = 0f;

            musicPriority = MusicPriority.BossMedium;

            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }

            music = Compatibilities.EEMusic?.GetSoundSlot(SoundType.Music, "Sounds/Music/Precursors") ?? MusicID.Boss3;
        }
    }
}