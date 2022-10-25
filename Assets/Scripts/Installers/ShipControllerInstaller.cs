using SpaceShooter.Controllers;
using UnityEngine;
using Zenject;

public class ShipControllerInstaller : MonoInstaller
{
    [SerializeField]
    private ShipController _shipController;

    public override void InstallBindings()
        => Container.Bind<ShipController>().FromInstance(_shipController).AsSingle();
}