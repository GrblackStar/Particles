﻿using System.Collections;
using System.Collections.Generic;
using Emotion.Common;
using Emotion.Graphics;
using Emotion.Primitives;
using Emotion.Scenography;

namespace Particles;

public static class Program
{
    public static void Main()
    {
        Engine.Start(new Configurator()
        {
            DebugMode = true,
            HostTitle = "Particles!"
        }, StartRoutineAsync);
    }

    public static IEnumerator StartRoutineAsync()
    {
        yield return Engine.SceneManager.SetScene(new ParticlesTestScene());
    }
}

public class ParticlesTestScene : SceneWithMap
{
    public ParticleSystem ParticleSystem = null!;

    protected override IEnumerator InternalLoadSceneRoutineAsync()
    {
        ParticleSystem = new ParticleSystem();
        yield break;
    }

    public override void UpdateScene(float dt)
    {
        base.UpdateScene(dt);

        ParticleSystem.Update(dt);
    }

    public override void RenderScene(RenderComposer c)
    {
        base.RenderScene(c);

        ParticleSystem.Render(c);
    }
}