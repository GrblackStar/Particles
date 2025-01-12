using System.Collections;
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

public struct Cone
{

}

public class ParticlesTestScene : SceneWithMap
{
    public ParticleSystem ParticleSystem = null!;
    public ParticleSystem FireParticleSystem = null!;

    protected override IEnumerator InternalLoadSceneRoutineAsync()
    {
        ParticleSystem = new ParticleSystem();
        ParticleSystem.ColorAtTime.Add(new ColorAtTime(0f, new Color(255, 255, 255, 0)));
        ParticleSystem.ColorAtTime.Add(new ColorAtTime(0.2f, new Color(255, 255, 255, 255)));
        ParticleSystem.ColorAtTime.Add(new ColorAtTime(0.8f, new Color(255, 255, 255, 255)));
        ParticleSystem.ColorAtTime.Add(new ColorAtTime(1f, new Color(255, 255, 255, 0)));
        ParticleSystem.Init();

        FireParticleSystem = new ParticleSystem();
        FireParticleSystem.ColorAtTime.Add(new ColorAtTime(0f, new Color(255, 255, 255, 0)));
        FireParticleSystem.ColorAtTime.Add(new ColorAtTime(0.13f, new Color("FFD563").SetAlpha(125)));
        FireParticleSystem.ColorAtTime.Add(new ColorAtTime(0.22f, new Color("FFD563")));
        FireParticleSystem.ColorAtTime.Add(new ColorAtTime(0.31f, new Color("FF5D15")));
        FireParticleSystem.ColorAtTime.Add(new ColorAtTime(1f, new Color("FF1A00").SetAlpha(0)));
        FireParticleSystem.LifeTime = 5000;
        FireParticleSystem.SpawnShape = new Circle(new Vector2(0, 0), 10);

        FireParticleSystem.Init();
        yield break;
    }

    public override void UpdateScene(float dt)
    {
        base.UpdateScene(dt);

        ParticleSystem.Update(dt);
        FireParticleSystem.Update(dt);
    }

    public override void RenderScene(RenderComposer c)
    {
        base.RenderScene(c);

        ParticleSystem.Render(c);
        FireParticleSystem.Render(c);
    }
}