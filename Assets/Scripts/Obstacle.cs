using System;
using UnityEngine;

namespace SpaceShooter
{
    public abstract class Obstacle : MonoBehaviour
    {
        public abstract void Fly();

        private void OnTriggerEnter2D(Collider2D col)
        {
            var ship = col.gameObject.GetComponent<Ship>();
            if (!ship) return;
            ship.Collision();
        }
    }
}