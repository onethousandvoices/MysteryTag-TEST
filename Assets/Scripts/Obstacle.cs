using UnityEngine;

namespace SpaceShooter
{
    public abstract class Obstacle : MonoBehaviour
    {
        private float _screenHeight;

        public void Init(float screenHeight)
        {
            _screenHeight = screenHeight;
            Fly();
        }

        protected abstract void Fly();

        private void OnTriggerEnter2D(Collider2D col)
        {
            var ship = col.gameObject.GetComponent<Ship>();
            if (!ship || ship.IsVulnerable == false) return;
            ship.Collision();
            Destroy(gameObject);
        }

        private void Update()
        {
            if (transform.position.y > - (_screenHeight + 1)) return;
            Destroy(gameObject);
        }
    }
}