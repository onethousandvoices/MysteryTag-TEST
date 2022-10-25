using UnityEngine;

namespace SpaceShooter.Views
{
    public class ObstacleSpawnerView : MonoBehaviour
    {
        public BoxCollider2D Collider { get; private set; }

        private void Start()
            => Collider = GetComponent<BoxCollider2D>();
    }
}