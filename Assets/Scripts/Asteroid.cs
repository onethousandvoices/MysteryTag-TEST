using UnityEngine;

namespace SpaceShooter
{
    public class Asteroid : Obstacle
    {
        [SerializeField]
        private Rigidbody2D _rb;
        [SerializeField]
        private float _speed;

        protected override void Fly()
        {
            _rb.AddForce(Vector2.down * _speed, ForceMode2D.Force);
        }
    }
}