using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace EndlessEscapade.Common.Systems.Boids;

public sealed class BoidSystem : ModSystem
{
    public static readonly Dictionary<string, BoidType> TypesByName = new();
    
    public static readonly List<Boid> Boids = new();
    public static readonly List<BoidFlock> Flocks = new();

    public override void OnModLoad() {
        RegisterType("Barracuda");
        RegisterType("Beta");
    }

    public override void PreUpdateWorld() {
        foreach (var type in TypesByName.Values) {
            if (Main.rand.NextBool(100)) {
                var flock = new BoidFlock(type);
                flock.Populate(Main.LocalPlayer.Center, 10, 100f);
                Flocks.Add(flock);
                break;
            }
        }
    }

    public override void PostUpdateWorld() {
        foreach (var flock in Flocks) {
            flock.Update();
        }
    }

    public override void PostDrawTiles() {
        Main.spriteBatch.Begin();
        foreach (var flock in Flocks) {
            flock.Draw();
        }
        Main.spriteBatch.End();
    }

    public static void RegisterType(string name) {
        TypesByName[name] = new BoidType(name);
    }
}
