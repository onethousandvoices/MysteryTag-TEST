using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SpaceShooter
{
    public class Ship : MonoBehaviour
    {
        [Inject]
        private Level _level;

        [SerializeField, Range(0.2f, 0.5f)]
        private float _activityDelay;
        [SerializeField]
        private int _speed;
        [SerializeField]
        private Projectile _currentProjectile;
        private Transform _firePoint;

        private Controls _controls;
        private Rigidbody2D _rb;
        private int _health = 3;
        private SpriteRenderer _renderer;

        public bool IsVulnerable { get; private set; } = true;

        public event Action CollisionEvent;
        public event Action DeadEvent;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _firePoint = transform.GetChild(0);
            _controls = new Controls();
            _controls.Enable();
            _controls.Main.Fire.performed += FirePerformed;
        }

        private void FirePerformed(InputAction.CallbackContext obj)
        {
            Instantiate(_currentProjectile, _firePoint.position, Quaternion.identity).Init(_level.ScreenHeight);
        }

        private void FixedUpdate()
        {
            var direction = _controls.Main.Movement.ReadValue<Vector2>();
            if (direction == Vector2.zero) return;

            _rb.AddForce(direction * _speed, ForceMode2D.Force);
        }

        public void Respawn(Vector3 spawnPoint, float invulnerabilityTime)
        {
            transform.position = spawnPoint;
            StartCoroutine(Invulnerable(invulnerabilityTime));
        }

        private IEnumerator Invulnerable(float invulnerabilityTime)
        {
            IsVulnerable = false;
            var rendererActivityDelay = _activityDelay;

            while (invulnerabilityTime > 0)
            {
                invulnerabilityTime -= Time.deltaTime;
                rendererActivityDelay -= Time.deltaTime;

                if (rendererActivityDelay <= 0f)
                {
                    _renderer.enabled = !_renderer.enabled;
                    rendererActivityDelay = _activityDelay;
                }

                yield return null;
            }
            _renderer.enabled = true;
            IsVulnerable = true;
        }

        public void Collision()
        {
            _health--;
            if (_health <= 0)
            {
                DeadEvent?.Invoke();
                return;
            }
            CollisionEvent?.Invoke();
        }
    }
}