using UnityEngine;

namespace SpaceShooter.Views
{
    public class ProjectileView : GameElement
    {
        [field: SerializeField]
        public Projectile Projectile { get; private set; }
    }
}