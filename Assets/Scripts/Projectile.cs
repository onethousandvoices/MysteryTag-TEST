using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : NonInputFlying
    {
        public override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Obstacle>())
            {
                UIController.ProjectileHit();
                Destroy(col.gameObject);
            }
            Destroy(gameObject);
        }

        public override void Update()
        {
            if (transform.position.y < ScreenHeight) return;
            Destroy(gameObject);
        }
    }
}