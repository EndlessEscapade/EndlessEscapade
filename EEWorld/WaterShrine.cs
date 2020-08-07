using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EEMod.Tiles;
using Terraria.ModLoader;
using System.Threading.Tasks;
using Terraria.ID;
namespace EEMod.EEWorld
{
public partial class EEWorld
{
public static int[,,] WaterShrine = new int[,,]
{
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Stone,0,20,1,0,0,0,0,126,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Stone,0,20,2,0,0,0,0,144,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Sandstone,0,8,0,0,0,0,0,126,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Stone,0,20,1,0,0,0,0,144,0},{TileID.Sandstone,0,8,0,0,0,0,0,36,54},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,54},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,0,36},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,54,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Stone,0,20,1,0,0,0,0,144,0},{TileID.Sandstone,0,8,0,0,0,0,0,36,54},{TileID.Sandstone,0,8,0,0,0,0,0,90,54},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,0,0},{TileID.Sandstone,0,8,0,0,0,0,0,54,0},{TileID.Sandstone,0,8,0,0,0,0,0,108,18},{TileID.Sandstone,0,8,0,0,0,0,0,54,54},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Stone,0,20,2,0,0,0,0,108,0},{TileID.Sandstone,0,8,2,0,0,0,0,0,54},{TileID.Sandstone,0,8,0,0,0,0,0,36,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{TileID.LunarBlockStardust,0,20,0,0,0,0,0,108,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,0},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,54,18},{TileID.Sandstone,0,8,0,0,0,0,0,36,18},{TileID.Sandstone,0,8,0,0,0,0,0,18,0},{ModContent.TileType<GemsandTile>(),0,0,1,0,0,0,0,18,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,0,36},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,18},{TileID.Sandstone,0,8,0,0,0,0,0,198,0},{TileID.Sandstone,0,8,0,0,0,0,0,108,72},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,36,18},{TileID.Sandstone,0,8,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,54,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,72,36},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Sandstone,0,8,0,0,0,0,0,0,36},{TileID.Sandstone,0,8,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,54,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,18},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,54,18},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,54,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,18},{TileID.Sandstone,0,8,0,0,0,0,0,72,18},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,54},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,18},{TileID.LunarBlockStardust,0,20,0,0,0,0,0,36,0},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,36,18},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,36,18},{TileID.Sandstone,0,8,0,0,0,0,0,54,36},{TileID.Sandstone,0,8,0,0,0,0,0,72,18},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Sandstone,0,8,0,0,0,0,0,36,72},{TileID.Sandstone,0,8,0,0,0,0,0,72,36},{TileID.BlueDungeonBrick,WallID.Grass,0,0,0,0,0,0,0,0},{TileID.Mudstone,0,8,0,0,0,0,0,36,18},{TileID.Mudstone,0,8,0,0,0,0,0,36,18},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,18,36},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,18,18},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,18,36},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,36,36},{TileID.Mudstone,0,20,3,0,0,0,0,54,72},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<GemsandTile>(),0,0,4,0,0,0,0,72,72},{TileID.Mudstone,0,8,0,0,0,0,0,36,36},{TileID.Mudstone,0,8,0,0,0,0,0,144,36},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,18,36},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,54,18},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,36,36},{TileID.Mudstone,0,20,0,0,0,0,0,54,18},{TileID.BlueDungeonBrick,WallID.Grass,20,0,0,0,0,0,90,54},{TileID.Sandstone,0,8,0,0,0,0,0,90,36},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Sandstone,0,8,0,0,0,0,0,126,54},{TileID.BlueDungeonBrick,0,0,0,0,0,0,0,0,36},{TileID.Mudstone,0,8,0,0,0,0,0,72,36},{ModContent.TileType<LightGemsandTile>(),WallID.SandstoneBrick,0,4,20,0,0,0,144,54},{TileID.Mudstone,0,8,2,0,0,0,0,36,54},{TileID.Mudstone,WallID.SandstoneBrick,8,3,20,0,0,0,18,72},{TileID.WaterDrip,0,0,0,0,0,0,0,0,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<GemsandTile>(),WallID.SandstoneBrick,0,0,20,0,0,0,144,54},{TileID.WaterDrip,0,0,0,0,0,0,0,0,0},{TileID.Mudstone,WallID.SandstoneBrick,8,4,20,0,0,0,36,72},{TileID.Mudstone,WallID.SandstoneBrick,8,1,20,0,0,0,90,54},{TileID.BlueDungeonBrick,WallID.SandstoneBrick,20,4,20,0,0,0,0,72},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,72,0},{TileID.Sandstone,0,8,0,0,0,0,0,126,54},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.BlueDungeonBrick,0,0,0,0,0,0,0,0,18},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,72,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{TileID.Mudstone,0,8,3,0,0,0,0,144,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Mudstone,0,8,0,0,0,0,0,90,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{TileID.Mudstone,0,8,0,0,0,0,0,90,18},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Mudstone,0,8,0,0,0,0,0,0,0},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,54,18},{TileID.BlueDungeonBrick,WallID.SandstoneBrick,20,0,20,0,0,0,90,54},{0,0,0,0,0,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{TileID.Mudstone,0,8,3,0,0,0,0,108,54},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{TileID.Mudstone,0,8,0,0,0,0,0,0,0},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,54,54},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Mudstone,0,8,4,0,0,0,0,72,72},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,18,36},{ModContent.TileType<GemsandTile>(),WallID.SandstoneBrick,0,0,20,0,0,0,54,72},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{TileID.Torches,WallID.SandstoneBrick,0,0,20,0,0,0,44,22},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,0,18},{TileID.BlueDungeonBrick,0,20,0,0,0,0,0,90,72},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.WaterDrip,WallID.BlueDungeonSlab,0,0,20,0,0,0,0,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.Mudstone,WallID.BlueDungeonSlab,8,0,0,0,0,0,126,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.BlueDungeonSlab,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.TinBrick,0,0,20,0,0,0,0,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{0,WallID.MudstoneBrick,0,0,8,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.MudstoneBrick,0,0,8,0,0,0,0,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Grass,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.MudstoneBrick,0,0,8,0,0,0,0,0},{TileID.DyePlants,WallID.BlueDungeonSlab,20,0,20,0,0,0,272,0},{TileID.Sand,WallID.BlueDungeonSlab,8,2,20,0,0,0,36,54},{TileID.Sand,WallID.BlueDungeonSlab,8,0,20,0,0,0,18,0},{TileID.Sand,WallID.BlueDungeonSlab,8,0,20,0,0,0,54,0},{TileID.Sand,WallID.BlueDungeonSlab,8,0,20,0,0,0,18,0},{TileID.LeafBlock,WallID.Grass,20,0,20,0,0,0,36,0},{TileID.LeafBlock,WallID.Grass,20,0,20,0,0,0,54,0},{TileID.LeafBlock,WallID.Grass,20,0,20,0,0,0,18,0},{TileID.LunarBlockStardust,WallID.Grass,20,0,0,0,0,0,36,0},{TileID.LunarBlockStardust,WallID.BlueDungeonSlab,20,0,20,0,0,0,18,54},{0,WallID.BlueDungeonSlab,0,0,20,0,0,0,0,0},{0,WallID.BlueDungeonSlab,0,0,20,0,0,0,0,0},{TileID.DyePlants,WallID.BlueDungeonSlab,20,0,20,0,0,0,136,0},{0,WallID.SandstoneBrick,0,0,20,0,0,0,0,0},{0,WallID.BlueDungeonSlab,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<GemsandTile>(),WallID.BlueDungeonSlab,0,2,20,0,0,0,36,54},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,0},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,18},{TileID.Sand,0,8,0,0,0,0,0,36,18},{TileID.Sand,0,8,0,0,0,0,0,18,18},{TileID.Sand,0,8,0,0,0,0,0,54,72},{TileID.LeafBlock,WallID.MudstoneBrick,0,0,0,0,0,0,0,36},{TileID.LeafBlock,0,20,0,0,0,0,0,54,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,54,18},{TileID.LunarBlockStardust,0,20,0,0,0,0,0,198,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,0},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,0},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,0},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,0},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,216,36},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<GemsandTile>(),WallID.Flower,0,0,20,0,0,0,0,36},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{TileID.Sand,0,8,0,0,0,0,0,36,18},{TileID.Sand,0,20,0,0,0,0,0,18,18},{TileID.Stone,0,20,0,0,0,0,0,72,18},{TileID.LeafBlock,WallID.MudstoneBrick,20,0,0,0,0,0,72,54},{TileID.LeafBlock,WallID.MudstoneBrick,20,0,0,0,0,0,54,18},{TileID.LeafBlock,0,20,0,0,0,0,0,54,18},{ModContent.TileType<GemsandTile>(),WallID.TungstenBrick,0,0,8,0,0,0,18,18},{TileID.LunarBlockStardust,WallID.MudstoneBrick,20,0,8,0,0,0,54,36},{TileID.LunarBlockStardust,0,20,0,0,0,0,0,72,0},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,72,72},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,18,36},{ModContent.TileType<LightGemsandTile>(),WallID.MudstoneBrick,0,0,8,0,0,0,108,36},{TileID.LunarBlockStardust,WallID.MudstoneBrick,20,0,8,0,0,0,54,72},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<LightGemsandTile>(),WallID.Flower,0,0,20,0,0,0,0,36},{TileID.Stone,0,20,0,0,0,0,0,36,18},{TileID.Stone,0,20,0,0,0,0,0,36,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,72,0},{0,WallID.MudstoneBrick,0,0,8,0,197,0,0,0},{TileID.Stone,WallID.MudstoneBrick,0,0,8,0,0,0,144,54},{0,0,0,0,0,0,84,0,0,0},{0,0,0,0,0,0,84,0,0,0},{TileID.Stone,0,0,3,0,0,0,0,144,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<LightGemsandTile>(),WallID.Flower,0,0,20,0,0,0,0,54},{ModContent.TileType<LightGemsandTile>(),WallID.Flower,0,0,0,0,0,0,54,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,18},{TileID.LunarBlockStardust,0,20,0,0,0,0,0,36,18},{ModContent.TileType<GemsandTile>(),WallID.Flower,0,0,0,0,0,0,18,18},{TileID.LeafBlock,WallID.Flower,20,0,0,0,0,0,54,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),WallID.Flower,0,0,0,0,0,0,18,18},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,72,18},{0,WallID.MudstoneBrick,0,0,8,0,255,0,0,0},{0,WallID.MudstoneBrick,0,0,8,0,255,0,0,0},{0,0,0,0,0,0,255,0,0,0},{0,0,0,0,0,0,255,0,0,0},{0,0,0,0,0,0,255,0,0,0},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,144,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{ModContent.TileType<GemsandTile>(),WallID.Flower,0,0,20,0,0,0,72,72},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,18,36},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,144,36},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,54,36},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,36},{TileID.LeafBlock,WallID.Flower,20,0,8,0,0,0,180,36},{TileID.LeafBlock,0,20,0,0,0,0,0,54,18},{TileID.LeafBlock,0,20,0,0,0,0,0,36,18},{TileID.LeafBlock,0,20,0,0,0,0,0,72,18},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,144,54},{TileID.Coral,WallID.MudstoneBrick,0,0,8,0,255,0,0,0},{0,WallID.MudstoneBrick,0,0,8,0,255,0,0,0},{TileID.Stone,WallID.MudstoneBrick,0,2,8,0,0,0,144,0},{0,0,0,0,0,0,255,0,0,0},{0,0,0,0,0,0,255,0,0,0},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,90,18},{0,WallID.MudstoneBrick,0,0,8,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,WallID.Waterfall,0,0,0,0,0,0,0,0},{ModContent.TileType<LightGemsandTile>(),0,0,0,0,0,0,0,144,54},{0,WallID.Waterfall,0,0,0,0,0,0,0,0},{0,WallID.Waterfall,0,0,8,0,0,0,0,0},{TileID.LeafBlock,0,20,0,0,0,0,0,0,18},{TileID.LeafBlock,0,20,0,0,0,0,0,36,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{ModContent.TileType<GemsandTile>(),0,0,0,0,0,0,0,36,18},{TileID.Stone,0,20,0,0,0,0,0,108,72},{TileID.Stone,WallID.MudstoneBrick,20,0,0,0,0,0,90,54},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,0,54},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,72,36},{TileID.Coral,0,0,0,0,0,255,0,78,0},{TileID.Coralstone,WallID.MudstoneBrick,8,2,8,0,0,0,36,54},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,108,18},{TileID.Coralstone,WallID.MudstoneBrick,8,3,8,0,0,0,216,18},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.LeafBlock,WallID.Waterfall,20,0,0,0,0,0,144,0},{0,WallID.Waterfall,0,0,0,0,255,0,0,0},{0,WallID.Waterfall,0,0,0,0,255,0,0,0},{TileID.LeafBlock,0,20,0,0,0,0,0,36,54},{TileID.LeafBlock,WallID.Flower,20,0,0,0,0,0,36,18},{ModContent.TileType<GemsandTile>(),WallID.Flower,0,0,20,0,0,0,54,36},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,18,36},{TileID.LeafBlock,0,20,0,0,0,0,0,36,18},{TileID.LeafBlock,WallID.Waterfall,20,0,0,0,0,0,90,54},{TileID.Stone,WallID.Waterfall,20,0,0,0,0,0,126,54},{TileID.Coralstone,WallID.Waterfall,8,0,0,0,0,0,72,72},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,18,36},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,126,72},{TileID.Coralstone,WallID.MudstoneBrick,8,0,8,0,0,0,36,36},{TileID.Coralstone,WallID.MudstoneBrick,8,0,0,0,0,0,90,72},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,0,18},{TileID.LeafBlock,0,20,1,0,0,0,0,18,54},{TileID.LeafBlock,WallID.Waterfall,20,0,0,0,0,0,36,54},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{TileID.LeafBlock,WallID.Flower,20,3,20,0,0,0,18,72},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,108,0},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,72,72},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,0},{TileID.LeafBlock,WallID.Waterfall,20,0,0,0,0,0,54,0},{TileID.LeafBlock,WallID.Waterfall,20,0,0,0,0,0,18,0},{TileID.LeafBlock,WallID.Waterfall,20,0,0,0,0,0,90,54},{TileID.LeafBlock,WallID.Waterfall,20,2,0,0,0,0,72,54},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,54,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.LeafBlock,WallID.Flower,20,4,20,0,0,0,0,72},{TileID.LeafBlock,0,20,0,0,0,0,0,54,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,18,72},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,162,0},{TileID.VineRope,0,20,0,0,0,0,0,72,18},{0,0,0,0,0,0,0,0,0,0},{TileID.LeafBlock,WallID.Flower,20,4,20,0,0,0,36,72},{TileID.LeafBlock,0,20,0,0,0,0,0,54,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{TileID.LeafBlock,0,20,0,0,0,0,0,18,18},{TileID.LeafBlock,0,20,0,0,0,0,0,36,18},{TileID.LeafBlock,WallID.Flower,20,3,20,0,0,0,90,72},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,144,0},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,72,72},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,54,36},{TileID.LeafBlock,0,0,0,0,0,0,0,216,18},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,90,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,144,0},{TileID.LeafBlock,WallID.Flower,20,4,20,0,0,0,36,72},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,36,36},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,18,36},{TileID.LeafBlock,0,20,0,0,0,0,0,36,18},{TileID.LeafBlock,WallID.Flower,20,0,20,0,0,0,72,18},{TileID.VineRope,0,20,0,0,0,0,0,144,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,0,18},{TileID.VineRope,0,20,0,0,0,0,0,144,72},{TileID.VineRope,0,20,0,0,0,0,0,108,72},{TileID.VineRope,0,20,0,0,0,0,0,72,36},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,0,0,0,0,0,0,90,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,90,18},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,0,54},{TileID.VineRope,0,20,0,0,0,0,0,216,0},{TileID.LeafBlock,WallID.Flower,20,4,20,0,0,0,72,72},{TileID.LeafBlock,WallID.Flower,20,3,20,0,0,0,54,72},{TileID.VineRope,0,20,0,0,0,0,0,90,18},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,90,36},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,90,18},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,0,0,0,0,0,0,108,54},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,126,54},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,144,54},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,0,54},{TileID.VineRope,0,20,0,0,0,0,0,126,72},{TileID.VineRope,0,20,0,0,0,0,0,72,36},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,90,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,126,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,90,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,126,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,144,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,90,18},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
{{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{TileID.VineRope,0,20,0,0,0,0,0,144,54},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}},
};
}
}