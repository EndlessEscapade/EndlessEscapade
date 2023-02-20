﻿using EndlessEscapade.Content.Items.Reefs.Surface;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessEscapade.Content.Tiles.Reefs.Surface;

public class CoralsandstoneTile : ModTile
{
    public override void SetStaticDefaults() {
        Main.tileMergeDirt[Type] = false;
        Main.tileSolid[Type] = true;
        Main.tileLighted[Type] = true;
        Main.tileBlockLight[Type] = true;

        TileID.Sets.Conversion.Sandstone[Type] = true;

        AddMapEntry(new Color(86, 105, 98));

        MineResist = 1f;

        HitSound = SoundID.Dig;
        DustType = DustID.GreenMoss;

        ItemDrop = ModContent.ItemType<CoralsandstoneItem>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num) {
        num = fail ? 1 : 3;
    }
}