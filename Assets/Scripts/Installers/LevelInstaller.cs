using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private Level[] _levels;

        public override void InstallBindings()
        {
            var level =
                Container.InstantiatePrefabForComponent<Level>(_levels[0], Vector3.zero, Quaternion.identity, null);
            Container.Bind<Level>().FromInstance(level).AsSingle();
        }
    }
}