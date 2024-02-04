using System;
using System.Collections.Generic;
using EndlessEscapade.Common.Seamap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace EndlessEscapade.Content.Seamap;

public class SeamapPlayerShip : SeamapObject
{
    public int abilityDelay = 120;

    public List<Vector2> activeCollisionVertices = new();

    //FoamTrail foamTrail;

    public float boatSpeed = 0.01f;

    public Vector2 boatTrailVector;
    public int cannonDelay = 60;
    public float forwardSpeed;

    public int invFrames = 20;

    public Vector2 movementVel;

    public Player myPlayer;

    public float rot;
    public float shipHelth = 5;
    public float ShipHelthMax = 5;
    public float topSpeed = 2.4f;


    public SeamapPlayerShip(Vector2 pos, Vector2 vel, Player player) : base(pos, vel) {
        position = pos;

        velocity = vel;

        myPlayer = player;

        width = 192;
        height = 160;

        rot = MathHelper.TwoPi * 2f / 4f;

        texture = ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/SeamapPlayerShip", AssetRequestMode.ImmediateLoad).Value;

        //PrimitiveSystem.primitives.CreateTrail(foamTrail = new FoamTrail(this, Color.Orange, 0.25f, 260));
    }

    public override void Update() {
        var prevForwardSpeed = movementVel.Length();

        CollisionChecks();

        if (invFrames > 0) {
            invFrames--;
        }

        if (invFrames <= 0) {
            if (myPlayer.controlUp && forwardSpeed < topSpeed) {
                forwardSpeed += boatSpeed;
                forwardSpeed = MathHelper.Clamp(forwardSpeed, -boatSpeed * 5, topSpeed);
            }

            if (myPlayer.controlDown && forwardSpeed > -boatSpeed * 5) {
                forwardSpeed -= boatSpeed * 0.5f;
                forwardSpeed = MathHelper.Clamp(forwardSpeed, -boatSpeed * 5, topSpeed);
            }

            if (myPlayer.controlRight) {
                rot += 0.03f - MathHelper.Clamp(0.015f * (forwardSpeed / 2f), 0f, 0.015f);
            }

            if (myPlayer.controlLeft) {
                rot -= 0.03f - MathHelper.Clamp(0.015f * (forwardSpeed / 2f), 0f, 0.015f);
            }

            if (myPlayer.controlUseItem && cannonDelay <= 0 && myPlayer == Main.LocalPlayer) {
                LeftClickAbility();

                cannonDelay = 60;
            }

            if (myPlayer.controlUseTile && abilityDelay <= 0) {
                RightClickAbility();

                abilityDelay = 120;
            }

            cannonDelay--;
            abilityDelay--;
        }

        if (shipHelth <= 0) {
            Die();
        }

        movementVel = Vector2.UnitX.RotatedBy(rot) * forwardSpeed;

        position += movementVel - Common.Seamap.Seamap.windVector * 0.2f;

        /*if (foamTrail != null && !foamTrail.disposing) {
            boatTrailVector.X += VectorAbs(movementVel - (Seamap.windVector * 0.2f)).Length() / 2f;
            boatTrailVector.X += VectorAbs(velocity).Length() / 2f;
        }

        int sign = forwardSpeed < 0 ? -1 : 1;

        forwardSpeed = movementVel.Length() * sign;

        if (forwardSpeed <= 0.6f && prevForwardSpeed > 0.6f) {
            foamTrail.disposing = true;

            foamTrail = null;
        }

        if (forwardSpeed > prevForwardSpeed && foamTrail == null) {
            PrimitiveSystem.primitives.CreateTrail(foamTrail = new FoamTrail(this, Color.Orange, 0.25f, 260));
        }*/

        base.Update();

        forwardSpeed *= 0.999f;
        velocity *= 0.96f;

        #region Position constraints

        if (position.X < 0) {
            position.X = 0;
        }

        if (position.X > Common.Seamap.Seamap.seamapWidth - width) {
            position.X = Common.Seamap.Seamap.seamapWidth - width;
        }

        if (position.Y < 0) {
            position.Y = 0;
        }

        if (position.Y > Common.Seamap.Seamap.seamapHeight - height - 200) {
            position.Y = Common.Seamap.Seamap.seamapHeight - height - 200;
        }

        #endregion
    }

    public override bool PreDraw(SpriteBatch spriteBatch) {
        var playerShipTexture = ModContent.Request<Texture2D>("EndlessEscapade/Content/Seamap/SeamapPlayerShip").Value;

        var frame = 0;
        var spriteRot = 0f;
        var flipped = false;

        rot = TwoPiRestrict(rot);

        var rotForSprite = TwoPiRestrict(rot + MathHelper.PiOver2);
        var rotAbsed = Math.Abs(rotForSprite - MathHelper.Pi);

        var origY = 86;

        if (rotForSprite > MathHelper.Pi && rotAbsed > MathHelper.Pi / 9f && rotAbsed < 8f * MathHelper.Pi / 9f) {
            flipped = true;
        }

        if (rotAbsed < MathHelper.Pi / 9f) {
            frame = 8;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 4.5f) - MathHelper.Pi / 9f;

            origY = 70;
        }
        else if (rotAbsed < 2 * MathHelper.Pi / 9f) {
            frame = 7;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;

            origY = 76;
        }
        else if (rotAbsed < 3 * MathHelper.Pi / 9f) {
            frame = 6;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;

            origY = 80;
        }
        else if (rotAbsed < 4 * MathHelper.Pi / 9f) {
            frame = 5;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;

            origY = 82;
        }
        else if (rotAbsed < 5 * MathHelper.Pi / 9f) {
            frame = 4;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;

            origY = 86;
        }
        else if (rotAbsed < 6 * MathHelper.Pi / 9f) {
            frame = 3;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 7 * MathHelper.Pi / 9f) {
            frame = 2;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 8 * MathHelper.Pi / 9f) {
            frame = 1;
            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else {
            frame = 0;
            spriteRot = (DynamicClamp(rotAbsed, MathHelper.Pi / 4.5f) - MathHelper.Pi / 9f) * (rotForSprite > MathHelper.Pi ? 1f : -1f);
        }


        var yVal = 160 * frame;

        spriteRot += (float)Math.Sin(Main.GameUpdateCount / 6f) * (invFrames / 120f);

        //spriteRot += (float)Math.Sin(Main.GameUpdateCount / 60f) / 12f;

        spriteBatch.Draw(playerShipTexture,
            Center - Main.screenPosition,
            new Rectangle(0, yVal, 192, 160),
            Color.White.LightSeamap(),
            spriteRot,
            new Vector2(96, origY),
            1,
            flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
            0);

        return false;
    }

    public override void PostDraw(SpriteBatch spriteBatch) {
        if (!Main.hideUI) {
            for (var i = 1; i < activeCollisionVertices.Count; i++) {
                //Utils.DrawLine(spriteBatch, activeCollisionVertices[i - 1] + Hitbox.Center.ToVector2(), activeCollisionVertices[i] + Hitbox.Center.ToVector2(), Color.Yellow, Color.Red, 2f);
            }
        }
    }

    public void LeftClickAbility() {
        //myPlayer.GetModPlayer<ShipyardPlayer>().LeftClickAbility(this);
    }

    public void RightClickAbility() {
        //myPlayer.GetModPlayer<ShipyardPlayer>().RightClickAbility(this);
    }

    public void Die() {
        //SoundEngine.PlaySound(SoundLoad.GetLegacySoundSlot("EndlessEscapade/Assets/Sounds/ShipDeath"));

        myPlayer.GetModPlayer<SeamapPlayer>().ReturnHome();

        shipHelth = ShipHelthMax;
    }

    public float CannonRestrictRange() {
        var mouseRot = Vector2.Normalize(Main.MouseWorld - Center).ToRotation() + MathHelper.Pi;

        var angleOfFreedom = 0.4f;

        var realRot = rot;

        /*if (mouseRot - realRot > 0)
            return TwoPiRestrict(MathHelper.Clamp(mouseRot, realRot + 1.57f - angleOfFreedom, realRot + 1.57f + angleOfFreedom));
        else
            return TwoPiRestrict(MathHelper.Clamp(mouseRot, realRot - 1.57f - angleOfFreedom, realRot - 1.57f + angleOfFreedom));*/

        var toTheLeft = TwoPiRestrict(realRot - MathHelper.PiOver2);
        var toTheRight = TwoPiRestrict(realRot + MathHelper.PiOver2);

        if (Math.Acos(Vector2.Dot(Vector2.UnitX.RotatedBy(mouseRot), Vector2.UnitX.RotatedBy(toTheLeft))) <
            Math.Acos(Vector2.Dot(Vector2.UnitX.RotatedBy(mouseRot), Vector2.UnitX.RotatedBy(toTheRight)))) {
            if (Math.Acos(Vector2.Dot(Vector2.UnitX.RotatedBy(mouseRot), Vector2.UnitX.RotatedBy(toTheLeft))) > angleOfFreedom) {
                if (mouseRot - toTheLeft > MathHelper.Pi) {
                    return toTheLeft - angleOfFreedom;
                }

                if (mouseRot - toTheLeft < -MathHelper.Pi) {
                    return toTheLeft + angleOfFreedom;
                }

                return mouseRot - toTheLeft < 0 ? toTheLeft - angleOfFreedom : toTheLeft + angleOfFreedom;
            }

            return mouseRot;
        }

        if (Math.Acos(Vector2.Dot(Vector2.UnitX.RotatedBy(mouseRot), Vector2.UnitX.RotatedBy(toTheRight))) > angleOfFreedom) {
            if (mouseRot - toTheRight > MathHelper.Pi) {
                return toTheRight - angleOfFreedom;
            }

            if (mouseRot - toTheRight < -MathHelper.Pi) {
                return toTheRight + angleOfFreedom;
            }

            return mouseRot - toTheRight < 0 ? toTheRight - angleOfFreedom : toTheRight + angleOfFreedom;
        }

        return mouseRot;
    }

    public float TwoPiRestrict(float val) {
        while (val > MathHelper.TwoPi) {
            val -= MathHelper.TwoPi;
        }

        while (val < 0) {
            val += MathHelper.TwoPi;
        }

        return val;
    }

    public float DynamicClamp(float val, float clamper) {
        while (val > clamper) {
            val -= clamper;
        }

        while (val < 0) {
            val += clamper;
        }

        return val;
    }


    public Vector2 VectorAbs(Vector2 toAbs) {
        return new Vector2(Math.Abs(toAbs.X), Math.Abs(toAbs.Y));
    }

    #region Collision

    public bool IntersectsRectangle(Rectangle rect, float largestVertDist) {
        if (activeCollisionVertices.Count == 0) {
            return false;
        }

        //check distance first     a/2 squared + b/2 squared + largest vertice diagonal squared < distance squared

        //if ((rect.Width / 2f) * (rect.Width / 2f) + (rect.Height / 2f) * (rect.Height / 2f) + largestVertDist * largestVertDist > Vector2.DistanceSquared(Center, rect.Center.ToVector2())) return false;

        //if (Math.Pow(Math.Sqrt((rect.Width / 2f) * (rect.Width / 2f) + (rect.Height / 2f) * (rect.Height / 2f)) + largestVertDist, 2) < Vector2.DistanceSquared(Center, rect.Center.ToVector2())) return false;

        //if (400 * 400 < Vector2.DistanceSquared(Center, rect.Center.ToVector2())) return false;

        var vecArray = new Vector2[4] { rect.BottomLeft(), rect.BottomRight(), rect.TopRight(), rect.TopLeft() };

        for (var j = 0; j < 4; j++) {
            if (IntersectsVertex(vecArray[j], largestVertDist)) {
                return true;
            }
        }

        for (var i = 0; i < activeCollisionVertices.Count; i++) {
            if (rect.Contains(activeCollisionVertices[i].ToPoint() + Hitbox.Center)) {
                return true;
            }
        }

        return false;
    }

    public bool IntersectsVertex(Vector2 vec, float largestVertDist) {
        var ticker = 0;

        for (var i = 0; i < activeCollisionVertices.Count; i++) //testing collision with 
        {
            Vector2 line1;
            Vector2 line2;

            if (i == activeCollisionVertices.Count - 1) {
                line1 = activeCollisionVertices[i] + Hitbox.Center.ToVector2();
                line2 = activeCollisionVertices[0] + Hitbox.Center.ToVector2();
            }
            else {
                line1 = activeCollisionVertices[i] + Hitbox.Center.ToVector2();
                line2 = activeCollisionVertices[i + 1] + Hitbox.Center.ToVector2();
            }

            if (PointAboveLine(vec, line1, line2) == PointAboveLine(Hitbox.Center.ToVector2(), line1, line2)) {
                ticker++;
            }
            else {
                return false;
            }
        }

        if (ticker >= activeCollisionVertices.Count) {
            //this is the ONLY case in which collision is possible.

            return true;
        }

        return false;
    }

    public bool PointAboveLine(Vector2 vec, Vector2 p1, Vector2 p2) {
        return vec.Y <= p1.Y + (vec.X - p1.X) * (p2.Y - p1.Y) / (p2.X - p1.X);
    }

    public void CollisionChecks() {
        rot = TwoPiRestrict(rot);

        var rotForSprite = TwoPiRestrict(rot + MathHelper.PiOver2);
        var rotAbsed = Math.Abs(rotForSprite - MathHelper.Pi);

        var spriteRot = 0f;

        var flipped = false;

        if (rotForSprite > MathHelper.Pi && rotAbsed > MathHelper.Pi / 9f && rotAbsed < 8f * MathHelper.Pi / 9f) {
            flipped = true;
        }

        var vertices = new List<Vector2>();

        if (rotAbsed < MathHelper.Pi / 9f) {
            //frame = 8;
            vertices = new List<Vector2> { new(-7, 20), new(7, 20), new(15, -40), new(-15, -40) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 4.5f) - MathHelper.Pi / 9f;
        }
        else if (rotAbsed < 2 * MathHelper.Pi / 9f) {
            //frame = 7;
            vertices = new List<Vector2> { new(11, 26), new(9, -16), new(-35, -56), new(-31, -0) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 3 * MathHelper.Pi / 9f) {
            //frame = 6;
            vertices = new List<Vector2> { new(5, 28), new(25, 28), new(11, -12), new(-41, -52), new(-39, -8) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 4 * MathHelper.Pi / 9f) {
            //frame = 5;
            vertices = new List<Vector2> { new(5, 24), new(23, 24), new(41, 16), new(3, -20), new(-47, -40), new(-31, 6) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 5 * MathHelper.Pi / 9f) {
            //frame = 4;
            vertices = new List<Vector2> { new(21, 18), new(41, -4), new(-55, -4), new(-35, 18) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 6 * MathHelper.Pi / 9f) {
            //frame = 3;
            vertices = new List<Vector2> { new(-23, 26), new(27, 8), new(33, -18), new(-61, 2) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 7 * MathHelper.Pi / 9f) {
            //frame = 2;
            vertices = new List<Vector2> { new(-13, 36), new(37, -8), new(38, -36), new(-51, 22) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else if (rotAbsed < 8 * MathHelper.Pi / 9f) {
            //frame = 1;
            vertices = new List<Vector2> { new(-25, 36), new(5, 28), new(23, -40), new(1, -28), new(-25, 16) };

            spriteRot = DynamicClamp(rotForSprite, MathHelper.Pi / 9f) - MathHelper.Pi / 18f;
        }
        else {
            //frame = 0;
            vertices = new List<Vector2> { new(9, 31), new(15, 21), new(13, -26), new(-13, -26), new(-15, 21), new(-9, 31) };

            spriteRot = (DynamicClamp(rotAbsed, MathHelper.Pi / 4.5f) - MathHelper.Pi / 9f) * (rotForSprite > MathHelper.Pi ? 1f : -1f);
        }

        if (rotForSprite > MathHelper.Pi && rotAbsed > MathHelper.Pi / 9f && rotAbsed < 8f * MathHelper.Pi / 9f) {
            flipped = true;
        }

        for (var i = 0; i < vertices.Count; i++) {
            vertices[i] = vertices[i].RotatedBy(spriteRot * (flipped ? -1 : 1));
        }

        if (flipped) {
            for (var i = 0; i < vertices.Count; i++) {
                vertices[i] = new Vector2(-vertices[i].X, vertices[i].Y);
            }
        }

        activeCollisionVertices = vertices;

        float distSquared = 100000000;
        foreach (var vec in activeCollisionVertices) {
            if (Vector2.DistanceSquared(Hitbox.Center.ToVector2(), vec) < distSquared) {
                distSquared = Vector2.DistanceSquared(Hitbox.Center.ToVector2(), vec);
            }
        }

        foreach (var obj in SeamapObjects.SeamapEntities) {
            if (obj == null || obj == this || !obj.active) {
                continue;
            }

            if (obj.collides && invFrames <= 0) //This means a collision is possible
            {
                if (IntersectsRectangle(obj.Hitbox, distSquared)) //Check for collision here
                {
                    //if (obj is Cannonball)
                    //    if ((int)(obj as Cannonball).team == myPlayer.team) continue;

                    //Collision response

                    //shipHelth--;
                    invFrames = 20;

                    //SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot("EndlessEscapade/Assets/Sounds/ShipHurt"));

                    velocity += Vector2.Normalize(obj.Center - Center) * boatSpeed * -120;
                    forwardSpeed = 0;
                }
            }
        }
    }

    #endregion
}
/*
class FoamTrail : Primitive
{
    public FoamTrail(Entity projectile, Color _color, float width = 40, int cap = 10) : base(projectile) {
        BindableEntity = projectile;
        _width = width;
        color = _color;
        _cap = cap;

        velocities = new List<float>();

        PrimitiveSystem.primitives.CreateTrail(trailLeft = new WakeTrail(this, BindableEntity, new Color(74, 189, 255), 2, _width, 1000, true));
        PrimitiveSystem.primitives.CreateTrail(trailRight = new WakeTrail(this, BindableEntity, new Color(74, 189, 255), 2, _width, 1000, false));
    }

    private Color color;

    public WakeTrail trailLeft;
    public WakeTrail trailRight;

    public List<float> velocities;

    public bool disposing = false;

    public override void SetDefaults() {
        Alpha = 0.8f;

        behindTiles = false;
        pixelated = true;
        manualDraw = true;
    }

    public float lastDisposalSpeed;

    public override void PrimStructure(SpriteBatch spriteBatch) {
        if (_noOfPoints <= 1 || _points.Count() <= 1) return;
        float widthVar;

        for (int i = 0; i < 5; i++) {
            velocities.Insert(velocities.Count - 1, (BindableEntity as SeamapPlayerShip).movementVel.Length());

            _points.Insert(_points.Count - 1, BindableEntity.Center + new Vector2(0, 14) + new Vector2(21f * (float)Math.Cos((BindableEntity as SeamapPlayerShip).rot), 24f * (float)Math.Sin((BindableEntity as SeamapPlayerShip).rot)));
        }

        float colorSin = (float)Math.Sin(_counter / 3f);
        {
            widthVar = 0;

            Vector2 normalAhead = CurveNormal(_points, 1);
            Vector2 secondUp = _points[1] - normalAhead * widthVar;
            Vector2 secondDown = _points[1] + normalAhead * widthVar;

            normalAhead.X *= 5f / 3f;

            AddVertex(_points[0], Color.Lerp(Color.Black, Color.White, 1 / (float)(_points.Count() - 1)), new Vector2(0, 1));
            AddVertex(secondUp, Color.Lerp(Color.Black, Color.White, 1 / (float)(_points.Count() - 1)), new Vector2(0, 0));
            AddVertex(secondDown, Color.Lerp(Color.Black, Color.White, 1 / (float)(_points.Count() - 1)), new Vector2(0, 1));
        }

        for (int i = 1; i < _points.Count() - 1; i++) {
            widthVar = (_points.Count() - 1 - i) * _width * (velocities[i] / (BindableEntity as SeamapPlayerShip).topSpeed)
                + ((float)Math.Sin(_points[i].X / 5f - _points[i].Y / 5f) - (float)Math.Cos(_points[i].Y / 5f - _points[i].X / 5f));

            widthVar = MathHelper.Clamp(widthVar, 0, 25);

            Vector2 normal = CurveNormal(_points, i);
            Vector2 normalAhead = CurveNormal(_points, i + 1);

            normal.X *= 4f / 3f;
            normalAhead.X *= 4f / 3f;

            Vector2 firstUp = _points[i] - normal * (widthVar + 1f * (float)Math.Sin((i / 1f) + (_counter / 10f)));
            Vector2 firstDown = _points[i] + normal * (widthVar + 1f * (float)Math.Sin((i / 1f) + (_counter / 10f)));
            Vector2 secondUp = _points[i + 1] - normalAhead * (widthVar + 1f * (float)Math.Sin((i / 1f) + (_counter / 10f)));
            Vector2 secondDown = _points[i + 1] + normalAhead * (widthVar + 1f * (float)Math.Sin((i / 1f) + (_counter / 10f)));

            AddVertex(firstDown, Color.Lerp(Color.Lerp(Color.Black, Color.White, i / (float)(_points.Count() - 1)), Color.Black, 1 - disposingFloat), new Vector2((i / (float)(_points.Count())) % 1, 1));
            AddVertex(firstUp, Color.Lerp(Color.Lerp(Color.Black, Color.White, i / (float)(_points.Count() - 1)), Color.Black, 1 - disposingFloat), new Vector2((i / (float)(_points.Count())) % 1, 0));
            AddVertex(secondDown, Color.Lerp(Color.Lerp(Color.Black, Color.White, i / (float)(_points.Count() - 1)), Color.Black, 1 - disposingFloat), new Vector2(((i + 1) / (float)(_points.Count())) % 1, 1));

            AddVertex(secondUp, Color.Lerp(Color.Lerp(Color.Black, Color.White, i / (float)(_points.Count() - 1)), Color.Black, 1 - disposingFloat), new Vector2(((i + 1) / (float)(_points.Count())) % 1, 0));
            AddVertex(secondDown, Color.Lerp(Color.Lerp(Color.Black, Color.White, i / (float)(_points.Count() - 1)), Color.Black, 1 - disposingFloat), new Vector2(((i + 1) / (float)(_points.Count())) % 1, 1));
            AddVertex(firstUp, Color.Lerp(Color.Lerp(Color.Black, Color.White, i / (float)(_points.Count() - 1)), Color.Black, 1 - disposingFloat), new Vector2((i / (float)(_points.Count())) % 1, 0));
        }

        for (int i = 0; i < 5; i++) {
            velocities.RemoveAt(velocities.Count - 1);

            _points.RemoveAt(_points.Count - 1);
        }

        if (disposing) {
            disposingFloat -= (1f / 65f);

            disposingFloat = MathHelper.Clamp(disposingFloat, 0f, 1f);

            if (disposingFloat == 0) {
                _points.Clear();

                velocities.Clear();
            }
        }
        else {
            disposingFloat = 1f;
        }
    }

    public float disposingFloat = 1f;

    public override void SetShaders() {
        Matrix view = Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitZ, Vector3.Up) * Matrix.CreateTranslation(_device.Viewport.Width / 2, _device.Viewport.Height / -2, 0) * Matrix.CreateRotationZ(MathHelper.Pi);

        Matrix projection = Matrix.CreateOrthographic(_device.Viewport.Width, _device.Viewport.Height, 0, 1000);

        Main.spriteBatch.End(); Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, default, default, EndlessEscapade.SeafoamShader);

        EndlessEscapade.SeafoamShader.Parameters["foamTexture"].SetValue(ModContent.GetInstance<EndlessEscapade>().Assets.Request<Texture2D>("Textures/Noise/FoamTrail3").Value);
        EndlessEscapade.SeafoamShader.Parameters["rippleTexture"].SetValue(ModContent.GetInstance<EndlessEscapade>().Assets.Request<Texture2D>("Textures/Noise/FoamTrail3").Value);

        EndlessEscapade.SeafoamShader.Parameters["offset"].SetValue(new Vector2((BindableEntity as SeamapPlayerShip).boatTrailVector.X + (BindableEntity as SeamapPlayerShip).boatTrailVector.Y, 0) / 400f);

        EndlessEscapade.SeafoamShader.Parameters["noColor"].SetValue(new Color(58, 110, 172).LightSeamap().ToVector4() * 0f * disposingFloat);
        EndlessEscapade.SeafoamShader.Parameters["color1"].SetValue(new Color(98, 153, 217).LightSeamap().ToVector4() * 0.15f * disposingFloat);
        EndlessEscapade.SeafoamShader.Parameters["color2"].SetValue(new Color(72, 159, 199).LightSeamap().ToVector4() * 0.29f * disposingFloat);
        EndlessEscapade.SeafoamShader.Parameters["color3"].SetValue(new Color(65, 198, 224).LightSeamap().ToVector4() * 0.35f * disposingFloat);
        EndlessEscapade.SeafoamShader.Parameters["color4"].SetValue(new Color(108, 211, 235).LightSeamap().ToVector4() * 0.55f * disposingFloat);
        EndlessEscapade.SeafoamShader.Parameters["color5"].SetValue(new Color(250, 255, 224).LightSeamap().ToVector4() * 0.85f * disposingFloat);

        EndlessEscapade.SeafoamShader.Parameters["WorldViewProjection"].SetValue(view * projection);

        if (vertices.Length == 0) return;

        DynamicVertexBuffer buffer = VertexBufferPool.Shared.RentDynamicVertexBuffer(VertexPositionColorTexture.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
        buffer.SetData(vertices);

        Main.graphics.GraphicsDevice.SetVertexBuffer(buffer);

        foreach (EffectPass pass in EndlessEscapade.SeafoamShader.CurrentTechnique.Passes) {
            pass.Apply();
        }

        if (_noOfPoints >= 1) {
            _device.DrawPrimitives(PrimitiveType.TriangleList, 0, _noOfPoints / 3);
        }

        VertexBufferPool.Shared.Return(buffer);
    }

    public override void OnUpdate() {
        _counter++;
        _noOfPoints = _points.Count() * 6;
        if (_cap < _noOfPoints / 6) {
            _points.RemoveAt(0);

            velocities.RemoveAt(0);
        }
        if ((!BindableEntity.active && BindableEntity != null) || _destroyed) {
            Dispose();
        }
        else {
            if ((BindableEntity as SeamapPlayerShip).forwardSpeed > 0) {
                _points.Add(BindableEntity.Center + new Vector2(0, 14) + new Vector2(21f * (float)Math.Cos((BindableEntity as SeamapPlayerShip).rot), 24f * (float)Math.Sin((BindableEntity as SeamapPlayerShip).rot)));

                velocities.Add((BindableEntity as SeamapPlayerShip).movementVel.Length());
            }
            else {
                if (!disposing) {
                    if (_points != null && _points.Count() > 0) _points.RemoveAt(0);

                    if (velocities != null && velocities.Count() > 0) velocities.RemoveAt(0);
                }
            }
        }
    }

    public override void OnDestroy() {
        _destroyed = true;
        _width *= 0.9f;
        if (_width < 0.05f) {
            Dispose();
        }
    }

    public override void PostDraw() {
        Main.spriteBatch.End(); Main.spriteBatch.Begin();
    }
}

class WakeTrail : Primitive
{
    public WakeTrail(FoamTrail trail, Entity projectile, Color _color, int width = 40, float myWidth = 10, int cap = 10, bool _left = false) : base(projectile) {
        myTrail = trail;
        _width = width;
        _myWidth = myWidth;
        color = _color;
        _cap = cap;
        left = _left;
    }

    private Color color;

    public FoamTrail myTrail;

    public float _myWidth;

    public bool left;

    public float counter;

    public override void SetDefaults() {
        Alpha = 0.8f;

        behindTiles = false;
        pixelated = true;
        manualDraw = true;
    }

    public override void PrimStructure(SpriteBatch spriteBatch) {
        if (myTrail._points.Count() <= 1) return;

        _myWidth = myTrail._width + 0.1f;

        _points.Clear();

        if (left) {
            for (int i = 1; i < myTrail._points.Count() - 1; i++) {
                Vector2 normal = CurveNormal(myTrail._points, i);

                normal.X *= 4f / 3f;

                _points.Add(myTrail._points[i] - normal * ((myTrail._points.Count() - 1 - i) * _myWidth * (myTrail.velocities[i] / (BindableEntity as SeamapPlayerShip).topSpeed) + (1f * (float)Math.Sin((i) + (counter / 10f)))));
            }
        }
        else {
            for (int i = 1; i < myTrail._points.Count() - 1; i++) {
                Vector2 normal = CurveNormal(myTrail._points, i);

                normal.X *= 4f / 3f;

                _points.Add(myTrail._points[i] + normal * ((myTrail._points.Count() - 1 - i) * _myWidth * (myTrail.velocities[i] / (BindableEntity as SeamapPlayerShip).topSpeed) + (1f * (float)Math.Sin((i) + (counter / 10f)))));
            }
        }

        if (_points.Count() <= 1) return;

        float widthVar;

        {
            widthVar = 0;

            Vector2 normalAhead = CurveNormal(_points, 1);
            Vector2 secondUp = _points[1] - normalAhead * widthVar;
            Vector2 secondDown = _points[1] + normalAhead * widthVar;
            Vector2 v = new Vector2((float)Math.Sin((_counter) / 20f));

            AddVertex(_points[0], color.LightSeamap() * Alpha, v);
            AddVertex(secondUp, color.LightSeamap() * Alpha, v);
            AddVertex(secondDown, color.LightSeamap() * Alpha, v);
        }

        for (int i = 1; i < _points.Count - 1; i++) {
            Alpha = (i / (float)(_points.Count - 1)) * 0.5f;
            widthVar = ((i) / (float)_points.Count) * _width * MathHelper.Clamp(myTrail.velocities[i], 0f, 1f);

            Vector2 normal = CurveNormal(_points, i);
            Vector2 normalAhead = CurveNormal(_points, i + 1);

            float j = (_cap - ((float)(Math.Sin((_counter + i) / 3f)) * 1) - i * 0.1f) / _cap;
            widthVar *= j;

            Vector2 firstUp = _points[i] - normal * widthVar;
            Vector2 firstDown = _points[i] + normal * widthVar;
            Vector2 secondUp = _points[i + 1] - normalAhead * widthVar;
            Vector2 secondDown = _points[i + 1] + normalAhead * widthVar;

            AddVertex(firstDown, color.LightSeamap() * Alpha * myTrail.disposingFloat, new Vector2(((i + (_counter / BindableEntity.velocity.Length())) / (float)_cap) % 1, 1));
            AddVertex(firstUp, color.LightSeamap() * Alpha * myTrail.disposingFloat, new Vector2(((i + (_counter / BindableEntity.velocity.Length())) / (float)_cap) % 1, 0));
            AddVertex(secondDown, color.LightSeamap() * Alpha * myTrail.disposingFloat, new Vector2((((i + (_counter / BindableEntity.velocity.Length())) + 1) / (float)_cap) % 1, 1));

            AddVertex(secondUp, color.LightSeamap() * Alpha * myTrail.disposingFloat, new Vector2((((i + (_counter / BindableEntity.velocity.Length())) + 1) / (float)_cap) % 1, 0));
            AddVertex(secondDown, color.LightSeamap() * Alpha * myTrail.disposingFloat, new Vector2((((i + (_counter / BindableEntity.velocity.Length())) + 1) / (float)_cap) % 1, 1));
            AddVertex(firstUp, color.LightSeamap() * Alpha * myTrail.disposingFloat, new Vector2((((i + (_counter / BindableEntity.velocity.Length())) / (float)_cap)) % 1, 0));
        }
    }

    public override void SetShaders() {
        Matrix view = Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitZ, Vector3.Up) * Matrix.CreateTranslation(_device.Viewport.Width / 2, _device.Viewport.Height / -2, 0) * Matrix.CreateRotationZ(MathHelper.Pi);

        Matrix projection = Matrix.CreateOrthographic(_device.Viewport.Width, _device.Viewport.Height, 0, 1000);

        Main.spriteBatch.End(); Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, default, default, EndlessEscapade.BasicEffect);

        EndlessEscapade.BasicEffect.Projection = view * projection;

        if (vertices.Length == 0) return;

        DynamicVertexBuffer buffer = VertexBufferPool.Shared.RentDynamicVertexBuffer(VertexPositionColorTexture.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
        buffer.SetData(vertices);

        Main.graphics.GraphicsDevice.SetVertexBuffer(buffer);

        foreach (EffectPass pass in EndlessEscapade.BasicEffect.CurrentTechnique.Passes) {
            pass.Apply();
        }

        if (_noOfPoints >= 1) {
            _device.DrawPrimitives(PrimitiveType.TriangleList, 0, _noOfPoints / 3);
        }

        VertexBufferPool.Shared.Return(buffer);
    }

    public override void OnUpdate() {
        counter += BindableEntity.velocity.Length();
        _counter++;
        _noOfPoints = _points.Count() * 6;
        if (_cap < _noOfPoints / 6) {
            _points.RemoveAt(0);
        }
        if ((!BindableEntity.active && BindableEntity != null) || _destroyed) {
            Dispose();
        }
    }

    public override void OnDestroy() {
        _destroyed = true;
        _width *= 0.9f;
        if (_width < 0.05f) {
            Dispose();
        }
    }

    public override void PostDraw() {
        Main.spriteBatch.End(); Main.spriteBatch.Begin();
    }
}

*/
