﻿using EndlessEscapade.Content.Biomes;
using Terraria;
using Terraria.Audio;

namespace EndlessEscapade.Common.Systems.Ambience.Loops;

public sealed class BeachLoop : AmbienceLoop
{
    protected override void Initialize() {
        Style = new SoundStyle($"{nameof(EndlessEscapade)}/Assets/Sounds/Ambience/Beach/Waves") {
            IsLooped = true
        };
    }

    protected override bool Active(Player player) {
        return !player.wet && (player.ZoneBeach || player.InModBiome<ShipyardBiome>());
    }
}