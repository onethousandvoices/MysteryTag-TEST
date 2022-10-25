using SpaceShooter.Controllers;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Movement))]
    public abstract class NonInputFlying : GameElement
    {
        [SerializeField]
        private Movement _movement;

        protected float ScreenHeight;
        protected UIController UIController;

        public void Init(UIController uiController, float screenHeight, Vector2 direction)
        {
            UIController = uiController;
            ScreenHeight = screenHeight;
            _movement.Move(direction);
        }

        public abstract void OnTriggerEnter2D(Collider2D col);

        public abstract void Update();
    }
}