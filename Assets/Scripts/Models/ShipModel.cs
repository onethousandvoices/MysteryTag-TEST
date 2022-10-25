using UnityEngine;

namespace SpaceShooter.Models
{
    public class ShipModel : GameElement
    {
        [field: SerializeField]
        public Projectile CurrentProjectile { get; private set; }
        [field: SerializeField]
        public int Health { get; private set; }

        [field: SerializeField, Range(0.2f, 0.5f)]
        public float ActivityDelay { get; private set; }
        [field: SerializeField, Range(1, 3)]
        public float InvulnerabilityTime { get; private set; }
    }
}