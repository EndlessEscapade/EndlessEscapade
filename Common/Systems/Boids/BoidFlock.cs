using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace EndlessEscapade.Common.Systems.Boids;

public sealed class BoidFlock
{
    public readonly BoidType Type;
    
    public readonly List<Boid> Boids = new();

    public BoidFlock(BoidType type) {
        Type = type;
    }

    public void Populate(Vector2 position, int amount, float spread) {
        for (int i = 0; i < amount; i++) {
            var offset = new Vector2(Main.rand.NextFloat(-spread, spread), Main.rand.NextFloat(-spread, spread));

            Boids.Add(new Boid() {
                Position = position + offset,
                Type = Type,
                Flock = this
            });            
        }
    }

    internal void Update() {
        foreach (var boid in Boids) {
            boid.Update();
        }
    }

    internal void Draw() {
        foreach (var boid in Boids) {
            var texture = ModContent.Request<Texture2D>("EndlessEscapade/Assets/Textures/Boids/" + boid.Type.Name).Value;
            var position = boid.Position - Main.screenPosition;
            var rotation = boid.Velocity.ToRotation();
            var color = Lighting.GetColor(boid.Position.ToTileCoordinates());
            
            Main.EntitySpriteDraw(texture, position, null, color, rotation, texture.Size() / 2f, 1f, SpriteEffects.None);
        }
    }
}
