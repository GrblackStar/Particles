using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Particles.ParticleShape;

public class ParticleConstantDirection : IParticleDirectionShape
{
    private Vector3 _direction;

    public ParticleConstantDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void SetParticleDirection(Particle particle)
    {
        particle.Direction = _direction;
    }
}
