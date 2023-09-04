using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using EndlessEscapade.Common.Players;
using EndlessEscapade.Common.Systems.Seamap;

namespace EndlessEscapade.Content.Seamap.Islands
{
    public class CoralReefsIsland : Island
    {
        public override string name => "Coral Reefs";
        public override int framecount => 16;
        public override int framespid => 10;
        public override bool cancollide => true;

        public override Texture2D islandTex => ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/Islands/CoralReefsIsland", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;

        public CoralReefsIsland(Vector2 pos): base(pos)
        {
            
        }

        public override void Interact()
        {
            Main.LocalPlayer.GetModPlayer<SeamapPlayer>().prevKey = KeyID.Sea;

            Main.LocalPlayer.GetModPlayer<SeamapPlayer>().myLastBoatPos = SeamapObjects.localship.position;

            Main.LocalPlayer.GetModPlayer<SeamapPlayer>().exitingSeamap = true;

            Main.LocalPlayer.GetModPlayer<SeamapPlayer>().exitingSeamapKey = KeyID.CoralReefs;

            base.Interact();
        }

        public void ExitSeamap()
        {

        }
    }
}
