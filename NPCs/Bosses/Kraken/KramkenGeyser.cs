using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;

namespace EEMod.NPCs.Bosses.Kraken
{
    public class KramkenGeyser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geyser");
        }

        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.damage = 20;
            projectile.aiStyle = -1;
            projectile.timeLeft = 180;
            projectile.tileCollide = false;

        }

        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] < 100)
            {
                for (int i = 0; i < 1; i++)
                {
                    int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Dirt, 0, 0, 6, default, projectile.scale * 1.3f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].velocity *= 1.5f;
                    Main.dust[num].noLight = false;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 113, 0, Main.rand.NextFloat(-2, -5), 6, Color.Blue, projectile.scale * 1.5f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].velocity *= 7f;
                    Main.dust[num].velocity.X = Main.rand.NextFloat(-2, 2);
                    Main.dust[num].noLight = false;
                }
                projectile.netUpdate = true;
            }
        }

    }
}