﻿using Terraria.ModLoader;

namespace EndlessEscapade.Common.Systems.Ambience;

[Autoload(Side = ModSide.Client)]
public sealed class AmbienceSystem : ModSystem
{
    public override void PostUpdateEverything() {
        foreach (var track in ModContent.GetContent<AmbienceTrack>()) {
            track.Update();
        }
    }
}