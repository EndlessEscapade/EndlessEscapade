using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using EndlessEscapade.Content.Subworlds;
using EndlessEscapade.Common.Systems.Seamap;
using EndlessEscapade.Content.Seamap.Islands;

namespace EndlessEscapade.Common.Players
{
    public enum WorldKeyID {
        MainWorld = 0,
        Seamap = 1,
        Reefs = 2,
        TropicalIsland = 3
    }

    public class SeamapPlayer : ModPlayer
    {
        public bool importantCutscene;

        public int timerForCutscene;
        public bool arrowFlag = false;
        public static bool isSaving;
        public float titleText;
        public float titleText2;
        public float subTextAlpha;
        public bool noU;
        public int coralReefTrans;
        public int seamapUpdateCount;

        public bool IncreaseStarFall;

        public WorldKeyID prevKey = WorldKeyID.MainWorld;

        public bool hasLoadedIntoWorld;

        public Vector2 myLastBoatPos;

        public bool lastKeySeamap;

        public float quickOpeningFloat = 60;

        public WorldKeyID exitingSeamapKey;

        public void ReturnHome() {
            SubworldLibrary.SubworldSystem.Exit();

            hasLoadedIntoWorld = false;

            lastKeySeamap = true;

            prevKey = WorldKeyID.Seamap;

            if (Main.netMode == NetmodeID.Server) {
                Netplay.Connection.State = 1;
            }
        }

        public override void OnEnterWorld() {
            if (prevKey == WorldKeyID.Seamap && !hasLoadedIntoWorld) {
                hasLoadedIntoWorld = true;
                if (lastKeySeamap) position = new Vector2((int)shipCoords.X - 2 + 7 + 12, (int)shipCoords.Y - 18 - 2 + 25) * 16;

                lastKeySeamap = false;

                Main.screenPosition = Center - new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f);
            }

            Main.time = time;
            Main.dayTime = dayTime;
        }

        public double time;
        public bool dayTime;

        public bool exitingSeamap = false;

        public void EnterSeamap() {
            time = Main.time;
            dayTime = Main.dayTime;

            seamapUpdateCount = 0;

            SubworldLibrary.SubworldSystem.Enter<Content.Subworlds.Seamap>();

            quickOpeningFloat = 60;

            exitingSeamap = false;
        }

        public override void PreUpdate() {
            if (!SubworldLibrary.SubworldSystem.IsActive<Content.Subworlds.Seamap>()) return;

            Player.position = Player.oldPosition;

            Player.position.X = Main.maxTilesX * 16 * (2f / 3f) + 300;
            Player.position.Y = Main.maxTilesY * 16 * (2f / 3f) + 300;

            Player.fallStart = (int)(Player.position.Y / 16f);

            #region Opening cutscene for seamap

            if (exitingSeamap) {
                quickOpeningFloat++;

                if (quickOpeningFloat > 60) OnExitSeamap();
            }
            else if (quickOpeningFloat > 0) {
                quickOpeningFloat--;
            }

            #endregion

            seamapUpdateCount++;

            if (seamapUpdateCount == 1)
                Systems.Seamap.Seamap.InitializeSeamap();

            Systems.Seamap.Seamap.UpdateSeamap();

            #region Island Interact methods
            foreach (var obj in SeamapObjects.SeamapEntities) {
                if (obj is Island) {
                    var island = obj as Island;

                    prevKey = WorldKeyID.Seamap;

                    Player.ClearBuff(BuffID.Cursed);
                    Player.ClearBuff(BuffID.Invisibility);

                    if (Vector2.DistanceSquared(SeamapObjects.localship.Hitbox.Center.ToVector2(), obj.Center) < obj.width * 2f * (obj.width * 2f) &&
                        Main.LocalPlayer.controlJump) {
                        island.Interact();
                    }
                }
            }
            #endregion
        }

        public override void SaveData(TagCompound tag) {
            tag["lastPos"] = myLastBoatPos;
        }

        public override void LoadData(TagCompound tag) {
            tag.TryGetRef("lastPos", ref myLastBoatPos);
        }

        public void OnExitSeamap() {
            quickOpeningFloat = 0;

            switch (exitingSeamapKey) {
                //case WorldKeyID.Reefs:
                //    SubworldLibrary.SubworldSystem.Enter<CoralReefs>();
                //    break;
                case WorldKeyID.MainWorld:
                    ReturnHome();
                    break;
                default:
                    break;
            }
        }
    }
}