using UnityEngine;
using Zenject;

namespace SpaceShooter.Controllers
{
    public class GameController : GameElement
    {
        [field: SerializeField]
        public ShipController ShipController { get; private set; }
        [field: SerializeField]
        public ObstacleSpawnerController ObstacleSpawnerController { get; private set; }
        [Inject]
        public LevelController LevelController { get; private set; }
        [field: SerializeField]
        public UIController UIController { get; private set; }
    }
}