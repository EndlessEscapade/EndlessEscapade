using EEMod.Extensions;
using EEMod.VerletIntegration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using EEMod.ID;
using EEMod.Config;

namespace EEMod
{
    public class DrawLensFlares : Mechanic
    {
        internal readonly Vector2 _sunPos;
        internal readonly float _globalAlpha;
        internal readonly float _intensityFunction;

        internal static DrawLensFlares Instance;

        public void UpdateLensFlares()
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);

            if (EEModConfigClient.Instance.BetterLighting && Main.worldName != KeyID.CoralReefs)
            {
                Main.spriteBatch.Draw(ModContent.GetInstance<EEMod>().GetTexture("ShaderAssets/LensFlare2"), _sunPos - Main.screenPosition + new Vector2(-400, 400), new Rectangle(0, 0, 174, 174), Color.White * .7f * _globalAlpha * (_intensityFunction * 0.36f), 0f, new Vector2(87), 1f, SpriteEffects.None, 0);
                Main.spriteBatch.Draw(ModContent.GetInstance<EEMod>().GetTexture("ShaderAssets/LensFlare2"), _sunPos - Main.screenPosition + new Vector2(-800, 800), new Rectangle(0, 0, 174, 174), Color.White * .8f * _globalAlpha * (_intensityFunction * 0.36f), 0f, new Vector2(87), .5f, SpriteEffects.None, 0);
            }

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.GameViewMatrix.TransformationMatrix);
        }

        public override void OnDraw()
        {
            UpdateLensFlares();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLoad()
        {
            Instance = this;
        }

        protected override Layer DrawLayering => Layer.BehindTiles;
    }
}