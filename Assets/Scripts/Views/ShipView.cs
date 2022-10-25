using UnityEngine;

namespace SpaceShooter.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ShipView : GameElement
    {
        [field: SerializeField]
        public Input Input { get; private set; }

        public SpriteRenderer Renderer { get; private set; }
        public Transform FirePoint { get; private set; }
        public bool IsVulnerable { get; private set; } = true;

        private void Start()
        {
            Renderer = GetComponent<SpriteRenderer>();
            FirePoint = transform.GetChild(0);
        }

        public void OnCollision()
            => App.Controller.ShipController.Collision();

        public void SetVulnerabilityState(bool state)
            => IsVulnerable = state;
    }
}