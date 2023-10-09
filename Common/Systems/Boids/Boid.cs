using System.Collections.Generic;
using EndlessEscapade.Utilities.Extensions;
using Microsoft.Xna.Framework;
using Terraria;

namespace EndlessEscapade.Common.Systems.Boids;

public sealed class Boid
{
    public Vector2 Position;
    public Vector2 Velocity;
    public Vector2 Acceleration;
    
    public BoidType Type;
    public BoidFlock Flock;

    internal void Update() {
        Velocity += Acceleration;
        Position += Velocity;

        ApplyAllignment();
        ApplySeparation();
        ApplyCohesion();
    }

    private void ApplyAllignment() {
        var count = 0;
        var force = Vector2.Zero;

        foreach (var boid in GetCloseBoids()) {
            force += boid.Velocity;
            count++;
        }

        if (count > 0) {
            force /= count;
        }

        if (force != Vector2.Zero) {
            force = force.SafeNormalize(Vector2.Zero) * Type.MaxVelocity;
            Acceleration += (force - Velocity).Limit(Type.MaxForce);
        }
    }

    private void ApplySeparation() {
        var count = 0;
        var force = Vector2.Zero;

        foreach (var boid in GetCloseBoids()) {
            var distance = Vector2.DistanceSquared(Position, boid.Position);
            var diff = Position - boid.Position;
            var weight = diff.SafeNormalize(Vector2.Zero) / distance;

            force += weight;
            count++;
        }

        if (count > 0) {
            force /= count;
        }

        if (force != Vector2.Zero) {
            force = force.SafeNormalize(Vector2.Zero) * Type.MaxVelocity;
            Acceleration += (force - Velocity).Limit(Type.MaxForce);
        }
    }

    private void ApplyCohesion() {
        var count = 0;
        var force = Vector2.Zero;

        foreach (var boid in GetCloseBoids()) {
            force += boid.Position;
            count++;
        }

        if (count > 0) {
            force /= count;
            force -= Position;
            force = force.SafeNormalize(Vector2.Zero) * Type.MaxVelocity;
        }

        if (force != Vector2.Zero) {
            force = force.SafeNormalize(Vector2.Zero) * Type.MaxVelocity;
            Acceleration += (force - Velocity).Limit(Type.MaxForce);
        }
    }

    private void ApplyAvoidance() {
        var force = Vector2.Zero;
        var dist = Vector2.DistanceSquared(Position, Main.LocalPlayer.Center);

        if (dist < Type.MaxVision * Type.MaxVision && dist > 0) {
            var diff = Position - Main.LocalPlayer.Center;
            var norm = diff.SafeNormalize(Vector2.Zero);
            force += norm;
        }

        if (force != Vector2.Zero) {
            force = Vector2.Normalize(force) * Type.MaxVelocity;
            Acceleration += (force - Velocity).Limit(Type.MaxForce);
        }
    }

    private IEnumerable<Boid> GetCloseBoids() {
        foreach (var boid in Flock.Boids) {
            var distance = Vector2.DistanceSquared(Position, boid.Position);
            var inRange = distance < Type.MaxVision * Type.MaxVision && distance > 0f;

            if (inRange) {
                yield return boid;
            }
        }
    }
}
