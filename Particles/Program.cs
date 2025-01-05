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

public class ParticlesTestScene : SceneWithMap
{
    protected override IEnumerator InternalLoadSceneRoutineAsync()
    {
        yield break;
    }

    public override void UpdateScene(float dt)
    {
        base.UpdateScene(dt);


    }

    public override void RenderScene(RenderComposer c)
    {
        base.RenderScene(c);

        c.RenderSprite(new System.Numerics.Vector3(0, 0, 0), new System.Numerics.Vector2(10, 10), Color.PrettyYellow);
    }
}