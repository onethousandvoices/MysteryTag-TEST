using System;
using UnityEngine;

namespace SpaceShooter
{
    public abstract class Projectile : MonoBehaviour
    {
        public abstract void Fire();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<Obstacle>())
                Destroy(col.gameObject);

            Destroy(gameObject);
        }
    }
}