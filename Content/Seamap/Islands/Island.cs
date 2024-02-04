using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using System.Diagnostics;
using ReLogic.Content;
using EndlessEscapade.Common.Seamap;

namespace EndlessEscapade.Content.Seamap.Islands
{
    public class Island : SeamapObject
    {
        public virtual string name => "Island";
        public virtual int framecount => 1;
        public virtual int framespid => 0;
        public virtual bool cancollide => false;

        public virtual int interactDistance => (int)(width * 1.5f);

        public virtual Texture2D islandTex => ModContent.Request<Texture2D>("EEMod/Empty", AssetRequestMode.ImmediateLoad).Value;

        public Vector2 posToScreen => position - Main.screenPosition;
        public bool isCollidingWithPlayer => SeamapObjects.localship.rect.Intersects(rect);

        public int framecounter;
        public int frame;

        public Island(Vector2 pos) : base(pos, Vector2.Zero) {
            texture = islandTex;

            width = texture.Width;
            height = texture.Height / framecount;

            frame = (int)(pos.Y / (15f)) % 12;
        }

        public void AnimateIsland() {
            if (++framecounter > framespid) {
                framecounter = 0;
                if (++frame > framecount - 1) {
                    frame = 0;
                }
            }
        }

        public override void Update() {
            AnimateIsland();
        }

        public override bool PreDraw(SpriteBatch spriteBatch) {
            //Color drawColour = Helpers.GetLightingColor(position) * Main.LocalPlayer.GetModPlayer<EEPlayer>().seamapLightColor;
            //drawColour.A = 255;

            if (!IslandDraw(spriteBatch)) return false;

            spriteBatch.Draw(texture, position - Main.screenPosition, new Rectangle(0, (texture.Height / framecount) * frame, texture.Width, (height)), Color.White.LightSeamap());

            return false;
        }

        public virtual bool IslandDraw(SpriteBatch spriteBatch) {
            return true;
        }

        public virtual void Interact() {

        }

        public virtual bool CheckCollision(Rectangle hitbox) {
            if (hitbox.Intersects(Hitbox))
                return true;

            return false;
        }
    }
}