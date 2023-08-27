using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using EndlessEscapade.Common.Players;

namespace EndlessEscapade.Content.Seamap.Islands
{
    public class MainIsland : Island
    {
        public override string name => "Main Island";
        public override int framecount => 1;
        public override int framespid => 0;
        public override bool cancollide => true;
        public override bool collides => true;

        public override int interactDistance => 300;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/MainIsland", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public MainIsland(Vector2 pos): base(pos)
        {
            width = 480;
            height = 176;
        }

        public override void Interact()
        {
            Main.LocalPlayer.GetModPlayer<SeamapPlayer>().exitingSeamapKey = "Main";
            Main.LocalPlayer.GetModPlayer<SeamapPlayer>().exitingSeamap = true;

            base.Interact();
        }
    }
}
