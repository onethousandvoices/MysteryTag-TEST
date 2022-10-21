using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class ShipInstaller : MonoInstaller
    {
        [SerializeField]
        private Ship _ship;

        public override void InstallBindings()
        {
            var shipInstance =
                Container.InstantiatePrefabForComponent<Ship>(_ship, transform.position, Quaternion.identity, null);
            Container.Bind<Ship>().FromInstance(shipInstance).AsSingle();
        }
    }
}