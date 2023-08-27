﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.Audio;
using Terraria.ID;
using System.Diagnostics;
using ReLogic.Content;
using EEMod.Seamap.Core;
using EndlessEscapade.Common.Systems.Seamap;

namespace EndlessEscapade.Content.Seamap.Cannonballs
{
    public class FriendlyCannonball : Cannonball
    {
        public FriendlyCannonball(Vector2 pos, Vector2 vel, TeamID team) : base(pos, vel, team)
        {
            width = 12;
            height = 12;

            texture = ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Cannonballs/FriendlyCannonball", AssetRequestMode.ImmediateLoad).Value;
        }

        public int ticks;
        public override void Update()
        {
            ticks++;

            if (explodeFrame <= 0)
            {
                foreach (SeamapObject obj in SeamapObjects.SeamapEntities)
                {
                    if (obj == null) continue;

                    if (obj.collides && obj.CheckCollision(Hitbox))
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

                Texture2D explodeSheet = ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Cannonballs/CannonballExplode").Value;
                Texture2D explodeSheetGlow = ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Cannonballs/CannonballExplodeGlow").Value;

                Main.spriteBatch.Draw(explodeSheet, Center - Main.screenPosition + new Vector2(-32, -36), new Rectangle(0, explodeFrame * 60, 60, 60), Color.White.LightSeamap(), 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                Main.spriteBatch.Draw(explodeSheet, Center - Main.screenPosition + new Vector2(-32, -36), new Rectangle(0, explodeFrame * 60, 60, 60), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

                if (explodeFrame - 1 >= 6)
                {
                    Kill();
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool CustomDraw(SpriteBatch spriteBatch) => false;
    }
}
