using SpaceShooter;
using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    [SerializeField]
    private App app;

    public override void InstallBindings()
        => Container.Bind<App>().FromInstance(app).AsSingle();
}