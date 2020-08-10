using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace EEMod.Projectiles
{
    public abstract class Blade : ModProjectile
    {
        public virtual float rotationalCoverage => (float)Math.PI;
        public virtual float RotationalOffset => (float)Math.PI / 2f;
        protected float progression => (projOwner.itemAnimation / (float)projOwner.itemAnimationMax);
        public virtual float dirtSmashIntensity => 12;
        public virtual int shakeLength => 20;
        public virtual int shakeIntensity => 3;
        public virtual int AoE => 1000;
        public virtual bool canCrash => false;
        protected Player projOwner => Main.player[projectile.owner];
        public virtual float damageIncreaseOverTime => 0.01f;
        public virtual float weight => 1;

        public float damageMultiplier = 1;

        public virtual List<int> exclude => new List<int> { };
        public float xDis;
        int width = 128;
        int height = 128;
        int frames = 5;
        int SlashType;
        int Direction = Main.rand.Next(0, 2);
        float rotation;
        Vector2 offsetHoldout;
        public override void AI()
        {
            
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = projOwner.Center.X - projectile.width / 2;
            projectile.position.Y = projOwner.Center.Y - projectile.height / 2;
            if (projOwner.itemAnimation == projOwner.itemAnimationMax - 1)
            {
                SlashType = Main.rand.Next(1, 5);
                rotation = new Vector2(Main.MouseWorld.X - projOwner.Center.X, Main.MouseWorld.Y - projOwner.Center.Y).ToRotation();
                offsetHoldout = Vector2.Normalize(Main.MouseWorld - projOwner.Center) * 50;
            }
            if (projOwner.itemAnimation <= 1)
                {
                    projectile.Kill();
            }
            Vector2 Norm = Vector2.Normalize(Main.MouseWorld - projOwner.Center);
            if (Main.rand.NextBool(3))
            {
                int index = Dust.NewDust(projectile.Center + Norm * 100, 10, 10, 139, 0, 0, 0, default, 1f);
                Main.dust[index].velocity *= 1.1f;
                Main.dust[index].noGravity = true;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            int currentFrame = (int)(progression * frames);
            Vector2 Norm = Vector2.Normalize(Main.MouseWorld - projOwner.Center);
            if(Direction == 0)
            Main.spriteBatch.Draw(mod.GetTexture($"Projectiles/Slash{SlashType}"), projectile.Center - Main.screenPosition + offsetHoldout, new Rectangle(0, height * currentFrame, width, height), Color.White, rotation, new Rectangle(0, 0, width, height).Size() / 2, 1, SpriteEffects.None, 0);
            if (Direction == 1)
                Main.spriteBatch.Draw(mod.GetTexture($"Projectiles/Slash{SlashType}"), projectile.Center - Main.screenPosition + offsetHoldout, new Rectangle(0, height * (frames - currentFrame), width, height), Color.White, rotation, new Rectangle(0, 0, width, height).Size() / 2, 1, SpriteEffects.None, 0);
            return false;
        }
    }
}