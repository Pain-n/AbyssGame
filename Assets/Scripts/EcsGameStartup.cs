using Assets.Scripts.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsGameStartup : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;

    void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddSystems();
        Addinjections();
        AddOneFrames();

        systems.Init();
    }

    void Update()
    {
        systems.Run();
    }

    private void AddSystems()
    {
        systems.Add(new PlayerInputSystem()).
            Add(new PlayerMovementSystem());
    }

    private void Addinjections()
    {

    }

    private void AddOneFrames()
    {

    }
    private void OnDestroy()
    {
        if (systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
}
