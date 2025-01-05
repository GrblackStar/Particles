using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotion.Common.Serialization;

namespace Particles
{
    public class ParticleSystem
    {
        public List<Particle> Particles = new();
        public float Periodicity = 300;
        public float LifeTime = 1000;
        //public ENUM MovementMode
        public Vector3 Direction = new(0, -1, 0); // up 2d
        public float Speed = 500f;
        public Circle SpawnShape = new Circle(new Vector2(0, 0), 200);
        
        private float _timer = 0;

        public void Update(float dt)
        {
            var initialPos = SpawnShape.GetRandomPointInsideCircle();
            _timer += dt;
            while (_timer > Periodicity)
            { 
                var particle = new Particle();
                particle.Position = initialPos.ToVec3();
                Particles.Add(particle);
                _timer -= Periodicity;
            }

            for (int i = Particles.Count - 1; i >= 0; i--) 
            {
                Particle? particle = Particles[i];
                particle.AliveTime += dt;
                if (particle.AliveTime > LifeTime)
                {
                    Particles.Remove(particle);
                }
            }


            var speedPerMS = Speed / 1000f;
            var speedPerDt = speedPerMS * dt;
            Vector3 change = Direction * speedPerMS;
            foreach (var particle in Particles)
            {
                particle.Position += change;
            }
        }

        public void Render(RenderComposer c)
        {
            c.RenderCircleOutline(SpawnShape, Color.PrettyYellow, 5, 100);
            foreach (var particle in Particles)
            {
                c.RenderCircle(particle.Position, 10, Color.White * 0.3f, true);
            }
        }
    }
}
