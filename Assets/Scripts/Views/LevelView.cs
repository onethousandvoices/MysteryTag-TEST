using UnityEngine;
using Zenject;

namespace SpaceShooter.Views
{
    public class LevelView : MonoBehaviour
    {
        [Inject]
        private Camera _cam;

        [field: SerializeField]
        public SpriteRenderer Renderer { get; private set; }

        public float ScreenWidth { get; private set; }
        public float ScreenHeight { get; private set; }

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
            ScreenHeight = (float)worldScreenHeight / 2;

            var scaleX = (float)worldScreenWidth / width;
            var scaleY = (float)worldScreenHeight / height;

            transform.localScale = new Vector3(scaleX, scaleY, 0);
        }
    }
}