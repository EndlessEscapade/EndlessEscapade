﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework.Input;
using EEMod.ID;
using EEMod.Tiles;
using EEMod.VerletIntegration;
using static EEMod.EEWorld.EEWorld;
using EEMod.Tiles.Foliage.Coral.HangingCoral;
using EEMod.Tiles.Foliage.Coral.WallCoral;
using EEMod.Tiles.Foliage.Coral;
using EEMod.Tiles.Foliage;
using System;
using EEMod.Systems.Noise;
using System.Collections.Generic;
using EEMod.Autoloading;
using Terraria.WorldBuilding;
using System.Diagnostics;
using EEMod.NPCs.Goblins.Shaman;
using EEMod.NPCs.Goblins.Berserker;
using EEMod.NPCs.Goblins.Watchman;
using EEMod.Subworlds;
using EEMod.Systems;
using EEMod.Tiles.Furniture.GoblinFort;
using EEMod.NPCs.Goblins.Scrapwizard;
using SubworldLibrary;
using Terraria.IO;
using Terraria.DataStructures;

namespace EEMod.Subworlds
{
    public abstract class EESubworld : Subworld
    {
        public override int Height => 0;
        public override int Width => 0;

        public override List<GenPass> Tasks => new List<GenPass>();
        public virtual string subworldKey => KeyID.Island;

        public override void OnExit()
        {
            Main.LocalPlayer.GetModPlayer<SeamapPlayer>().prevKey = subworldKey;

            base.OnExit();
        }

        public override void DrawMenu(GameTime gameTime)
        {
            ModContent.GetInstance<EEMod>().DrawLoadingScreen();

            return;
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