﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EEMod.ID;
using ReLogic.Graphics;
using Terraria.Audio;
using Terraria.ID;
using EEMod.Seamap.Content;
using System.Diagnostics;
using EEMod.Extensions;
using ReLogic.Content;
using EEMod.Seamap.Core;

namespace EEMod.Seamap.Content.Cannonballs
{
    public class EnemyCannonball : SeamapObject
    {
        public EnemyCannonball(Vector2 pos, Vector2 vel) : base(pos, vel)
        {
            position = pos;
            velocity = vel;

            width = 12;
            height = 12;

            texture = ModContent.Request<Texture2D>("EEMod/Seamap/Content/Cannonballs/EnemyCannonball", AssetRequestMode.ImmediateLoad).Value;
        }

        public override bool collides => true;

        public int ticks;
        public override void Update()
        {
            ticks++;

            if (explodeFrame <= 0)
            {
                foreach (SeamapObject obj in SeamapObjects.SeamapEntities)
                {
                    if (obj == null) continue;

                    if (obj.collides && obj.Hitbox.Intersects(Hitbox))
                    {
                        SoundEngine.PlaySound(SoundID.Item14);
                        explodeFrame++;
                    }
                }

                if (ticks == 100)
                {
                    SoundEngine.PlaySound(SoundID.Item14);
                    explodeFrame++;
                }
            }

            if (explodeFrame >= 1 && ticks % 4 == 0) explodeFrame++;

            rotation = 0f;

            base.Update();
        }

        public float sinkLevel;

        public int explodeFrame;

        public override bool PreDraw(SpriteBatch spriteBatch)
        {
            if (explodeFrame >= 1)
            {
                velocity = Vector2.Zero;

                Texture2D explodeSheet = ModContent.Request<Texture2D>("EEMod/Seamap/Content/CannonballExplode").Value;
                Texture2D explodeSheetGlow = ModContent.Request<Texture2D>("EEMod/Seamap/Content/CannonballExplodeGlow").Value;

                Main.spriteBatch.Draw(explodeSheet, Center.ForDraw() + new Vector2(-32, -36), new Rectangle(0, explodeFrame * 60, 60, 60), Color.White.LightSeamap(), 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                Main.spriteBatch.Draw(explodeSheet, Center.ForDraw() + new Vector2(-32, -36), new Rectangle(0, explodeFrame * 60, 60, 60), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                if (explodeFrame - 1 >= 6)
                {
                    Kill();
                }

                return false;
            }
            else
            {
                if (ticks >= 108)
                {
                    sinkLevel += 1f;

                    velocity = Vector2.Zero;

                    Main.spriteBatch.Draw(texture, position.ForDraw() + new Vector2(0, sinkLevel), new Rectangle(0, 0, width, (int)(height - sinkLevel)), color * alpha, rotation, texture.Bounds.Size() / 2, scale, spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);

                    return false;
                }
                else
                {
                    color = Color.White.LightSeamap();

                    return true;
                }
            }
        }
    }
}
