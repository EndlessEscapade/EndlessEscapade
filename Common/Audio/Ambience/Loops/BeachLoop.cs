﻿using EndlessEscapade.Content.Biomes;
using Terraria;
using Terraria.Audio;

namespace EndlessEscapade.Common.Audio.Ambience.Loops;

public sealed class BeachLoop : AmbienceLoop
{
    protected override void Initialize() {
        Style = new SoundStyle($"{nameof(EndlessEscapade)}/Assets/Sounds/Ambience/Beach/BeachWavesLoop", SoundType.Ambient) {
            IsLooped = true
        };
    }

    protected override bool Active(Player player) {
        return player.ZoneBeach || player.InModBiome<Shipyard>();
    }
}
