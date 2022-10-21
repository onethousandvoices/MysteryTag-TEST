using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class LevelControllerInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelController _levelController;

        public override void InstallBindings()
        {
            var controller = Container.
                    InstantiatePrefabForComponent<LevelController>(_levelController, transform.position, Quaternion.identity, null);
            Container.Bind<LevelController>().FromInstance(controller);
        }
    }
}