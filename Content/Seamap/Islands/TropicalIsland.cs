﻿using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using EEMod.Seamap.Core;
using EEMod.ID;
using Microsoft.Xna.Framework.Graphics;

namespace EndlessEscapade.Content.Seamap.Islands
{
    public class TropicalIsland1 : Island
    {
        public override string name => "Tropical Island";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool cancollide => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/TropicalIsland", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public TropicalIsland1(Vector2 pos): base(pos)
        {
            
        }
    }

    public class TropicalIsland2 : Island
    {
        public override string name => "Tropical Island";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool cancollide => true;
        
        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/TropicalIsland").Value;

        public TropicalIsland2(Vector2 pos) : base(pos)
        {

        }
    }
}
