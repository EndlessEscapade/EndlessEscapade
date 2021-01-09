using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EEMod.Prim;
using EEMod.Tiles;

namespace EEMod.Projectiles.Enemy
{
    public class SpireLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquamarine Laser");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.timeLeft = 30000;
            projectile.ignoreWater = true;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.penetrate = -1;
            projectile.extraUpdates = 12;
            projectile.hide = false;
            projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Bounce(projectile.modProjectile, oldVelocity);
            return false;
        }

        //private static Vector2 SavedVel;

        public void Bounce(ModProjectile modProj, Vector2 oldVelocity, float bouncyness = 1.5f)
        {
            Projectile projectile = modProj.projectile;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X * bouncyness;
            }

            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y * bouncyness;
            }
        }
        public override void AI()
        {
            Tile currentTile = Main.tile[(int)(projectile.Center.X / 16), (int)(projectile.Center.Y / 16)];
            if (currentTile != null && currentTile.active() && currentTile.type == ModContent.TileType<EmptyTile>() && projectile.ai[0] == 0)
            {
                projectile.velocity *= -2;
                projectile.timeLeft = 250;
                projectile.ai[0] = 1;
                Main.NewText("CRUMPETS!");
            }
        }
    }
}