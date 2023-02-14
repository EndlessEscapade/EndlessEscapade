﻿using EndlessEscapade.Content.Walls.Reefs;
using Terraria.ModLoader;

namespace EndlessEscapade.Content.Items.Reefs;

public class LightGemsandstoneWallItem : ModItem
{
    public override void SetDefaults() {
        Item.DefaultToPlacableWall((ushort)ModContent.WallType<LightGemsandstoneWall>());
    }
}