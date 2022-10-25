using UnityEngine;

namespace SpaceShooter.Models
{
    public class ObstacleSpawnerModel : GameElement
    {
        [field: SerializeField]
        public Obstacle CurrentObstacle { get; private set; }
    }
}