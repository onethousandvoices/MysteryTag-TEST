using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    [RequireComponent(typeof(Movement))]
    public class Input : MonoBehaviour
    {
        [SerializeField]
        private Movement _movement;

        private Controls _controls;

        public event Action FirePerformedEvent;

        private void Start()
        {
            _controls = new Controls();
            _controls.Enable();
            _controls.Main.Fire.performed += FirePerformed;
        }

        private void FirePerformed(InputAction.CallbackContext obj)
        {
            FirePerformedEvent?.Invoke();
        }

        private void FixedUpdate()
        {
            var direction = _controls.Main.Movement.ReadValue<Vector2>();
            if (direction == Vector2.zero) return;

            _movement.Move(direction);
        }

        private void OnDestroy()
        {
            _controls.Main.Fire.performed -= FirePerformed;
            _controls.Disable();
        }
    }
}