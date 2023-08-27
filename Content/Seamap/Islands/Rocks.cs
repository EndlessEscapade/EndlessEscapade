﻿using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using EEMod.Seamap.Core;
using EEMod.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace EndlessEscapade.Content.Seamap.Islands
{
    public class Rock1 : Island
    {
        public override string name => "Rock";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool collides => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/Rock1", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public Rock1(Vector2 pos): base(pos)
        {
            width = 48;
            height = 56;
        }
    }

    public class Rock2 : Island
    {
        public override string name => "Rock";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool collides => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/Rock2", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public Rock2(Vector2 pos) : base(pos)
        {
            width = 88;
            height = 52;
        }
    }

    public class Rock3 : Island
    {
        public override string name => "Rock";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool collides => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/Rock3", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public Rock3(Vector2 pos) : base(pos)
        {
            width = 44;
            height = 36;
        }
    }

    public class Rock4 : Island
    {
        public override string name => "Rock";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool collides => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/Rock4", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public Rock4(Vector2 pos) : base(pos)
        {
            width = 62;
            height = 44;
        }
    }

    public class Rock5 : Island
    {
        public override string name => "Rock";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool collides => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/Rock5", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public Rock5(Vector2 pos) : base(pos)
        {
            width = 62;
            height = 56;
        }

        public override void PostDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/Rock5Front").Value, position - Main.screenPosition, new Rectangle(0, (texture.Height / framecount) * frame, texture.Width, height), Color.White.LightSeamap());

            base.PostDraw(spriteBatch);
        }

        public override bool CheckCollision(Rectangle hitbox)
        {
            return (hitbox.Intersects(new Rectangle((int)position.X + 10, (int)position.Y + 36, 12, 12))
                || hitbox.Intersects(new Rectangle((int)position.X + 40, (int)position.Y + 20, 14, 16)));
        }
    }

    public class Rock6 : Island
    {
        public override string name => "Rock";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool collides => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/Rock6", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public Rock6(Vector2 pos) : base(pos)
        {
            width = 46;
            height = 42;
        }
    }
}
