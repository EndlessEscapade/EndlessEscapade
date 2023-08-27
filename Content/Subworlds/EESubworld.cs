using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using SubworldLibrary;
using Terraria.IO;

namespace EndlessEscapade.Content.Subworlds
{
    public abstract class EESubworld : Subworld
    {
        public override int Height => 0;
        public override int Width => 0;

        public override List<GenPass> Tasks => new List<GenPass>();

        public static string progressMessage = "";

        public override void DrawMenu(GameTime gameTime)
        {
            DrawLoadingScreen();

            return;
        }

        public void DrawLoadingScreen()
        {

        }
    }

    public class SubworldGenerationPass : GenPass
    {
        private Action<GenerationProgress> method;

        public SubworldGenerationPass(Action<GenerationProgress> method) : base("", 1)
        {
            this.method = method;
        }

        public SubworldGenerationPass(float weight, Action<GenerationProgress> method) : base("", weight)
        {
            this.method = method;
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            method(progress);
        }
    }
}