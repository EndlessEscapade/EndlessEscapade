using EEMod.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;

namespace EEMod
{
    public class Particle : Entity
    {
        internal float timeLeft;
        List<IParticleModule> Modules = new List<IParticleModule>();
        Texture2D texture;
        int RENDERDISTANCE => 2000;
        public float varScale;
        public float scale { get; set; }
        public float alpha;
        public Color colour;
        public float rotation;
        int TrailLength;
        public Vector2[] PositionCache;
        private int a;
        public void UpdatePositionCache()
        {
            a++;
            PositionCache[5 - (a % TrailLength)] = position;
        }
        public virtual void OnUpdate()
        {

        }

        public virtual void OnDraw()
        {

        }
        public Particle(Vector2 position, int timeLeft,Texture2D texture, Vector2? velocity = null,int scale = 1,Color? colour = null, params IParticleModule[] StartingModule)
        {
            this.timeLeft = timeLeft;
            this.position = position;
            this.velocity = velocity ?? Vector2.Zero;
            this.texture = texture;
            active = true;
            this.scale = scale;
            alpha = 1;
            this.colour = colour ?? Color.White;
            TrailLength = 6;
            PositionCache = new Vector2[TrailLength];
            SetModules(StartingModule.ToArray() ?? new IParticleModule[0]); 
        }

        public void AddModule(IParticleModule Module) => Modules.Add(Module);
        public void SetModules(params IParticleModule[] Module) => Modules = Module.ToList();

        public void Update()
        {
            position += velocity;
            OnUpdate();
            //UpdatePositionCache();
            if (timeLeft > 1)
            timeLeft--;
            if (timeLeft == 1)
            {
                varScale *= 0.98f;
                if (varScale < 0.001f)
                {
                    timeLeft--;
                }
            }
            else if (Math.Abs(scale - varScale) > 0.01f)
            {
                varScale += (scale - varScale) / 6f;
            }
            if(timeLeft == 0)
            {
                active = false;
            }

            foreach (IParticleModule Module in Modules)
            {
                Module.Update(this);
            }
        }

        public void Draw()
        {
            foreach (IParticleModule Module in Modules)
            {
                Module.Draw(this);
            }
            Vector2 positionDraw = position.ForDraw();
            Main.spriteBatch.Draw(texture, positionDraw,new Rectangle(0, 0,1, 1), colour * alpha, rotation, new Rectangle(0, 0, 1, 1).Size()/2, varScale, SpriteEffects.None, 0f);
            OnDraw();
        }
    }
    class TestModule : IParticleModule
    {
        public void Update(in Particle particle)
        {
            particle.position.X++;
        }
        public void Draw(in Particle particle) {; }
    }
    class SlowDown : IParticleModule
    {
        float slowDownFactor;
        public SlowDown(float slowDownFactor)
        {
            this.slowDownFactor = slowDownFactor;
        }
        public void Update(in Particle particle)
        {
            particle.velocity *= slowDownFactor;
        }
        public void Draw(in Particle particle) {; }
    }
    class RotateTexture : IParticleModule
    {
        float rotationSpeed;
        public RotateTexture(float rotationSpeed)
        {
            this.rotationSpeed = rotationSpeed;
        }
        public void Update(in Particle particle)
        {
            particle.rotation += rotationSpeed;
        }
        public void Draw(in Particle particle) {; }
    }
    class SimpleBrownianMotion : IParticleModule
    {
        float intensity;
        public SimpleBrownianMotion(float intensity)
        {
            this.intensity = intensity;
        }
        public void Update(in Particle particle)
        {
            particle.velocity.X += Main.rand.NextFloat(-1,1)*intensity;
            particle.velocity.Y += Main.rand.NextFloat(-1,1)*intensity;
        }
        public void Draw(in Particle particle) {; }
    }
    class AdditiveCircularMotion : IParticleModule
    {
        float width;
        float height;
        float speed;
        float timer;
        public AdditiveCircularMotion(float width, float height, float speed)
        {
            this.width = width;
            this.height = height;
            this.speed = speed;
        }
        public void Update(in Particle particle)
        {
            timer += speed;
            Vector2 rotVec = new Vector2((float)Math.Sin(timer) * width, (float)Math.Cos(timer) * height);
            particle.position.X += rotVec.X;
            particle.position.Y += rotVec.Y;
        }
        public void Draw(in Particle particle) {; }
    }
    class AfterImageTrail : IParticleModule
    {
        float alphaFallOff;
        public AfterImageTrail(float alphaFallOff)
        {
            this.alphaFallOff = alphaFallOff;
        }
        public void Draw(in Particle particle)
        {
            for(int i = 0; i<particle.PositionCache.Length; i++)
            {
                float globalFallOff = 1 - (i/(float)particle.PositionCache.Length)*alphaFallOff;
                Main.spriteBatch.Draw(Main.magicPixel, particle.PositionCache[i].ForDraw(), new Rectangle(0, 0, 1, 1), particle.colour* particle.alpha* globalFallOff, particle.rotation, new Rectangle(0, 0, 1, 1).Size() / 2, particle.varScale* globalFallOff, SpriteEffects.None,0f);
            }
        }
        public void Update(in Particle particle) {; }
    }
    class Spew : IParticleModule
    {
        float randomAngle;
        float randomSpeed;
        Vector2 initialSpeed;
        float airResistance;
        bool initial;
        public Spew(float randomAngle, float randomSpeed, Vector2 initialSpeed, float airResistance)
        {
            this.randomAngle = randomAngle;
            this.randomSpeed = randomSpeed;
            this.initialSpeed = initialSpeed;
            this.airResistance = airResistance;
        }
        public void Update(in Particle particle)
        {
            if (!initial)
            {
                initial = true;
                float randVel = 1 + Main.rand.NextFloat(-randomSpeed / 2, randomSpeed / 2);
                float randAngle = Main.rand.NextFloat(-randomAngle / 2, randomAngle / 2);
                particle.velocity = new Vector2(initialSpeed.X, initialSpeed.Y).RotatedBy(randAngle)*randVel;
            }
            particle.velocity *= airResistance;
        }
        public void Draw(in Particle particle) {; }
    }
    class AddVelocity : IParticleModule
    {
        Vector2 velocity;
        public AddVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }
        public void Update(in Particle particle)
        {
            particle.velocity += velocity;
        }
        public void Draw(in Particle particle) {; }
    }
    class RotateVelocity : IParticleModule
    {
        float rotFac;
        public RotateVelocity(float rotFac)
        {
            this.rotFac = rotFac;
        }
        public void Update(in Particle particle)
        {
            particle.velocity = particle.velocity.RotatedBy(rotFac);
        }
        public void Draw(in Particle particle) {; }
    }

    class CircularMotion : IParticleModule
    {
        float width;
        float height;
        float speed;
        float timer;
        Entity orbitPoint;
        float rotation;
        public CircularMotion(float width, float height, float speed, Entity orbitPoint,float rotation = 0f)
        {
            this.width = width;
            this.height = height;
            this.speed = speed;
            this.orbitPoint = orbitPoint;
            this.rotation = rotation;
        }
        public void Update(in Particle particle)
        {
            timer += speed;
            Vector2 rotVec = new Vector2((float)Math.Sin(timer) * width, (float)Math.Cos(timer) * height).RotatedBy(rotation);
            particle.position.X = orbitPoint.Center.X + rotVec.X;
            particle.position.Y = orbitPoint.Center.Y + rotVec.Y;
        }
        public void Draw(in Particle particle) {; }
    }
    class CircularMotionSin : IParticleModule
    {
        float width;
        float height;
        float speed;
        float timer;
        Entity orbitPoint;
        float rotation;
        float intensity;
        float period;
        bool disapearFromBack;
        public CircularMotionSin(float width, float height, float speed, Entity orbitPoint, float rotation = 0f,float intensity = 0f, float period = 0f,bool disapearFromBack = false)
        {
            this.width = width;
            this.height = height;
            this.speed = speed;
            this.orbitPoint = orbitPoint;
            this.rotation = rotation;
            this.intensity = intensity;
            this.disapearFromBack = disapearFromBack;
        }
        public void Update(in Particle particle)
        {
            timer += speed * (1 + (float)Math.Sin(timer*period) * intensity);
            Vector2 rotVec = new Vector2((float)Math.Sin(timer) * width, (float)Math.Cos(timer) * height).RotatedBy(rotation);
            particle.position.X = orbitPoint.Center.X + rotVec.X;
            particle.position.Y = orbitPoint.Center.Y + rotVec.Y;
            if(disapearFromBack)
            {
               if(timer % (float)Math.PI*4 < (float)Math.PI)
                {
                    particle.alpha = 0f;
                }
               else
                {
                    particle.alpha = 1f;
                }
            }
        }
        public void Draw(in Particle particle) {; }
    }
    class BaseModule : IParticleModule
    {
        public void Update(in Particle particle) { ; }
        public void Draw(in Particle particle) {; }
    }
    public interface IParticleModule
    {
        void Update(in Particle particle);
        void Draw(in Particle particle);
    }
}