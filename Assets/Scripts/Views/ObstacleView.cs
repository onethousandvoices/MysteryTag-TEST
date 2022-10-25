using UnityEngine;

namespace SpaceShooter.Views
{
    public class ObstacleView : GameElement
    {
        [field: SerializeField]
        public Obstacle Obstacle { get; private set; }
    }
}