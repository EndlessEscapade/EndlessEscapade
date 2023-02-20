﻿using EndlessEscapade.Content.Items.Reefs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessEscapade.Content.Tiles.Reefs;

public class GemsandstoneTile : ModTile
{
    public override void SetStaticDefaults() {
        Main.tileMergeDirt[Type] = false;
        Main.tileSolid[Type] = true;
        Main.tileLighted[Type] = true;
        Main.tileBlockLight[Type] = true;

        TileID.Sets.Conversion.Sandstone[Type] = true;

        AddMapEntry(new Color(103, 202, 204));

        MineResist = 1f;
        
        HitSound = SoundID.Dig;
        DustType = DustID.BlueMoss;

        ItemDrop = ModContent.ItemType<GemsandstoneItem>();
    }

    public override void NumDust(int i, int j, bool fail, ref int num) {
        num = fail ? 1 : 3;
    }
}