﻿using EndlessEscapade.Common.Systems.Audio;
using EndlessEscapade.Utilities.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessEscapade.Common.Players;

public class WaterImmersionPlayer : ModPlayer
{
    private float intensity;
    private bool wetFadeOut;

    public bool WetHead {
        get {
            var headPosition = Player.Center - new Vector2(0f, 16f);
            var wetHead = Collision.WetCollision(headPosition, 10, 10) || Player.HasItemEquip(ItemID.FishBowl);

            return wetHead;
        }
    }

    public float Intensity {
        get => intensity;
        set => intensity = MathHelper.Clamp(value, WetHead ? 0.9f : 0f, 1f);
    }

    public override void PreUpdate() {
        UpdateIntensity();
        UpdateAudio();
    }

    private void UpdateIntensity() {
        if (WetHead) {
            if (wetFadeOut) {
                Intensity -= 0.0025f;
                return;
            }

            Intensity += 0.05f;

            if (Intensity >= 1f) {
                wetFadeOut = true;
            }
        }
        else {
            Intensity -= 0.05f;

            wetFadeOut = false;
        }
    }

    private void UpdateAudio() {
        if (Intensity <= 0f) {
            return;
        }

        SoundSystem.SetParameters(new SoundModifiers { LowPass = Intensity });
    }
}
