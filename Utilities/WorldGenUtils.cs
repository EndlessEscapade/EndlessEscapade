﻿using Terraria;

namespace EndlessEscapade.Utilities;

// TODO: Ideally this file wouldnt need to exist, except for vars. Move all methods to be GenAction (s).
public class WorldGenUtils
{
    public static void ClearArea(int x, int y, int width, int height, bool keepLiquids = false) {
        for (var i = 0; i < width; i++) {
            for (var j = 0; j < height; j++) {
                if (!WorldGen.InWorld(x + i, y + j)) {
                    continue;
                }

                var tile = Framing.GetTileSafely(x + i, y + j);

                var oldType = tile.LiquidType;
                var oldAmount = tile.LiquidAmount;

                tile.ClearEverything();

                if (keepLiquids) {
                    tile.LiquidType = oldType;
                    tile.LiquidAmount = oldAmount;
                }
            }
        }
    }
}