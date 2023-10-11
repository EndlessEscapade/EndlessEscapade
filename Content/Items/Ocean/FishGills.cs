﻿using System.Collections.Generic;
using EndlessEscapade.Common.Systems.Generation.Loot;
using Terraria;
using Terraria.ModLoader;

namespace EndlessEscapade.Content.Items.Ocean;

public class FishGills : ModItem, IChestLoot
{
    public IReadOnlyList<ChestFrame> Frames { get; } = new[] { ChestFrame.Water };

    public int Chance { get; } = 5;
    
    public override void SetDefaults() {
        Item.DefaultToAccessory();
    }

    public override void UpdateAccessory(Player player, bool hideVisual) { }
}
