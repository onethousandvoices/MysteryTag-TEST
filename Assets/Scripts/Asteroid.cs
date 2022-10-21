using UnityEngine;

namespace SpaceShooter
{
    public class Asteroid : Obstacle
    {
        [SerializeField]
        private Rigidbody2D _rb;
        [SerializeField]
        private float _speed;

        public override void Fly()
        {
            _rb.AddForce(Vector2.down * _speed, ForceMode2D.Force);
        }
    }
}