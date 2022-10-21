using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private int _speed;
        [SerializeField]
        private Projectile _currentProjectile;
        private Transform _firePoint;

        private Controls _controls;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _firePoint = transform.GetChild(0);
            _controls = new Controls();
            _controls.Enable();
            _controls.Main.Fire.performed += FirePerformed;
        }

        private void FirePerformed(InputAction.CallbackContext obj)
        {
            Instantiate(_currentProjectile, _firePoint.position, Quaternion.identity).Fire();
        }

        private void FixedUpdate()
        {
            var direction = _controls.Main.Movement.ReadValue<Vector2>();
            if (direction == Vector2.zero) return;

            _rb.AddForce(direction * _speed, ForceMode2D.Force);
        }

        public void Collision()
        {
            print("health--");
        }
    }
}