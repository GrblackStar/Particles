using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles
{
    public class Particle
    {
        public Vector3 Position { get; set; }
        public float AliveTime { get; set; }
        public Vector3 Direction { get; set; }

    }
}
