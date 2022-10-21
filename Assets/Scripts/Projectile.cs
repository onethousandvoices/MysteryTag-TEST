using UnityEngine;

namespace SpaceShooter
{
    public abstract class Projectile : MonoBehaviour
    {
        private float _screenHeight;

        public void Init(float screenHeight)
        {
            _screenHeight = screenHeight;
            Fire();
        }

        protected abstract void Fire();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Obstacle>())
                Destroy(col.gameObject);
            Destroy(gameObject);
        }

        private void Update()
        {
            if (transform.position.y < _screenHeight) return;
            Destroy(gameObject);
        }
    }
}