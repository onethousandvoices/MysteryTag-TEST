using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class Level : MonoBehaviour
    {
        [Inject]
        private Camera _cam;
        public float ScreenWidth { get; private set; }

        private void Start()
        {
            PolygonCollider2D poly = gameObject.AddComponent<PolygonCollider2D>();
            Vector2[] points = poly.points;

            EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
            edge.points = points;
            Destroy(poly);

            var sr = GetComponent<SpriteRenderer>();

            var width = sr.sprite.bounds.size.x;
            var height = sr.sprite.bounds.size.y;

            var worldScreenHeight = _cam.orthographicSize * 2.0;
            var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            ScreenWidth = (float)worldScreenWidth / 2;

            var scaleX = (float)worldScreenWidth / width;
            var scaleY = (float)worldScreenHeight / height;

            transform.localScale = new Vector3(scaleX, scaleY, 0);
        }
    }
}