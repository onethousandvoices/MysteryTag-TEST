using System.Collections;
using SpaceShooter.Models;
using SpaceShooter.Views;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Controllers
{
    public class ObstacleSpawnerController : GameElement
    {
        [field: SerializeField]
        public ObstacleSpawnerView ObstacleSpawnerView { get; private set; }

        [Inject]
        private LevelView _levelView;

        private LevelModel _levelModel;
        private ObstacleSpawnerModel _obstacleSpawnerModel;
        private UIController _uiController;

        private WaitForSeconds _delay;

        private void Start()
        {
            _levelModel = App.Model.LevelModel;
            _delay = new WaitForSeconds(_levelModel.ObstacleSpawnTime);

            _obstacleSpawnerModel = App.Model.ObstacleSpawnerModel;
            _uiController = App.Controller.UIController;

            ObstacleSpawnerView.transform.position =
                new Vector3(0, _levelView.ScreenHeight + 0.5f, 0);

            ObstacleSpawnerView.Collider.size =
                new Vector2(_levelView.ScreenWidth * 2, 0.5f);

            StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            while (true)
            {
                yield return _delay;

                Vector3 pos = new Vector3(
                    UnityEngine.Random.Range(-_levelView.ScreenWidth, _levelView.ScreenWidth), _levelView.ScreenHeight + 1, 0);

                var obstacle = Instantiate(
                    _obstacleSpawnerModel.CurrentObstacle, pos, Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360)));

                var scale = UnityEngine.Random.Range(0.3f, 0.7f);

                obstacle.transform.localScale = new Vector3(scale, scale, 0);
                obstacle.Init(_uiController, _levelView.ScreenHeight, Vector2.down);
            }
        }
    }
}