using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rb;
        [SerializeField]
        private float _speed;

        public void Move(Vector2 direction)
            => _rb.AddForce(direction * _speed, ForceMode2D.Force);
    }
}