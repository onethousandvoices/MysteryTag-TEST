using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class LevelController : MonoBehaviour
    {
        [Inject]
        private Ship _ship;
        [Inject]
        private Level _level;

        private Vector3 _spawnPoint;

        private void Start()
        {
            _spawnPoint = new Vector3(_level.transform.position.x, _level.transform.position.y - 4, _level.transform.position.z);
            _ship.transform.position = _spawnPoint;

            _ship.CollisionEvent += ShipCollision;
            _ship.DeadEvent += ShipDead;
        }

        private void ShipDead()
        {
            print("dead");
        }

        private void ShipCollision()
        {
            _ship.Respawn(_spawnPoint, _level.InvulnerabilityTime);
        }


        private void OnDestroy()
        {
            _ship.CollisionEvent -= ShipCollision;
            _ship.DeadEvent -= ShipDead;
        }
    }
}