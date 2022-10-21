using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private Level _level;

        public override void InstallBindings()
        {
            var level =
                Container.InstantiatePrefabForComponent<Level>(_level, Vector3.zero, Quaternion.identity, null);
            Container.Bind<Level>().FromInstance(level).AsSingle();
        }
    }
}