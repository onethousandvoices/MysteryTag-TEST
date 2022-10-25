using UnityEngine;
using SpaceShooter.Views;

namespace SpaceShooter
{
    public class Obstacle : NonInputFlying
    {
        public override void OnTriggerEnter2D(Collider2D col)
        {
            var ship = col.gameObject.GetComponent<ShipView>();
            if (!ship || ship.IsVulnerable == false) return;
            ship.OnCollision();
            Destroy(gameObject);
        }

        public override void Update()
        {
            if (transform.position.y > - (ScreenHeight + 1)) return;
            Destroy(gameObject);
        }
    }
}