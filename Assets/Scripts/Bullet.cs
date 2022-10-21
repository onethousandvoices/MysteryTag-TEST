using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : Projectile
    {
        [SerializeField]
        private Rigidbody2D _rb;
        [SerializeField]
        private int _speed;

        public override void Fire()
            => _rb.AddForce(Vector2.up * _speed, ForceMode2D.Force);

        private void Update()
        {
            if (transform.position.y < 5) return;
            Destroy(gameObject);
        }
    }
}