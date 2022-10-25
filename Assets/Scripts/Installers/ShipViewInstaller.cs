using SpaceShooter.Views;
using UnityEngine;
using Zenject;

public class ShipViewInstaller : MonoInstaller
{
    [SerializeField]
    private ShipView _shipView;
    [SerializeField]
    private Transform _gameView;

    public override void InstallBindings()
    {
        var shipInstance = Container.InstantiatePrefabForComponent<ShipView>(
            _shipView, transform.position, Quaternion.identity, _gameView);

        Container.Bind<ShipView>().FromInstance(shipInstance).AsSingle();
    }
}