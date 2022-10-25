using SpaceShooter.Views;
using UnityEngine;
using Zenject;

public class LevelViewInstaller : MonoInstaller
{
    [SerializeField]
    private LevelView _levelView;
    [SerializeField]
    private Transform _gameView;

    public override void InstallBindings()
    {
        var levelInstance = Container.InstantiatePrefabForComponent<LevelView>(
            _levelView, transform.position, Quaternion.identity, _gameView);

        Container.Bind<LevelView>().FromInstance(levelInstance).AsSingle();
    }
}