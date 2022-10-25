using UnityEngine;

namespace SpaceShooter.Models
{
    public class GameModel : GameElement
    {
        [field: SerializeField]
        public ShipModel ShipModel { get; private set; }
        [field: SerializeField]
        public ObstacleSpawnerModel ObstacleSpawnerModel { get; private set; }

        public LevelModel LevelModel { get; private set; }

        public void SetLevelModel(LevelModel model)
            => LevelModel = model;
    }
}