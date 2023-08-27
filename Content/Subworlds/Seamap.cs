using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using SubworldLibrary;

namespace EndlessEscapade.Content.Subworlds
{
    public class Seamap : EESubworld
    {
        public override int Width => 600;
        public override int Height => 600;

        public override string Name => "Sea";

        public override List<GenPass> Tasks => new List<GenPass>()
        {
            new SubworldGenerationPass(progress =>
            {
                progress.Message = "Spawning Seamap"; //Sets the text above the worldgen progress bar

	    		Main.worldSurface = Main.maxTilesY - 42; //Hides the underground layer just out of bounds
	    		Main.rockLayer = Main.maxTilesY; //Hides the cavern layer way out of bounds
            })
        };

        public void ReturnHome(Player player)
        {
            SubworldSystem.Exit();
        }
    }

    public class SeaSystem : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(ModContent.GetInstance<EndlessEscapade>(), "Assets/Music/Seamap");
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;

        public override bool IsSceneEffectActive(Player player)
        {
            return SubworldSystem.IsActive<Seamap>();
        }
    }
}