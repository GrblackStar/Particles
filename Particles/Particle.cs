﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats.Png;

namespace Particles
{
    public class Particle
    {
        public Vector3 Position;
        public float AliveTime;
        public Vector3 Direction;
        public float CurrentSpeed;
    }
}
