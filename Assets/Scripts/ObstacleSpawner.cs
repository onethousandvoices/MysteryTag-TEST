using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Inject]
        private Level _level;

        [SerializeField]
        private Obstacle _obstacle;

        private BoxCollider2D _collider;

        private void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.size = new Vector2(_level.ScreenWidth * 2, 1);

            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            while (true)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1.5f));
                Vector3 pos =
                    new Vector3(UnityEngine.Random.Range(-_level.ScreenWidth, _level.ScreenWidth), transform.position.y, 0);
                var obstacle = Instantiate(_obstacle, pos,Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));

                var scale = UnityEngine.Random.Range(0.3f, 0.7f);
                obstacle.transform.localScale = new Vector3(scale, scale, 0);
                obstacle.Fly();
            }
        }
    }
}