using Data;
using UnityEngine;
using Zenject;

public class DataManagerInstaller : MonoInstaller
{
    [SerializeField]
    private DataManager _dataManager;

    public override void InstallBindings()
    {
        var dataManager = Container.InstantiatePrefabForComponent<DataManager>(
            _dataManager, transform.position, Quaternion.identity, null);

        Container.Bind<DataManager>().FromInstance(dataManager).AsSingle().NonLazy();
    }
}