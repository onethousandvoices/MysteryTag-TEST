using Data;
using SpaceShooter.Models;
using UnityEngine;
using SpaceShooter.Views;
using Zenject;

namespace SpaceShooter.Controllers
{
    public class LevelController : GameElement
    {
        [Inject]
        public LevelView LevelView { get; private set; }
        [Inject]
        private ShipController _shipController;
        [Inject]
        private DataManager _dataManager;

        private UIController _uiController;
        private LevelModel _model;

        public Vector3 SpawnPoint { get; private set; }

        private void Start()
        {
            Time.timeScale = 1f;

            _model = App.Model.LevelModel;
            LevelView.Renderer.color = _model.LevelColor;

            Debug.Log($"Reach {_model.TargetScore} points");

            _uiController = App.Controller.UIController;
            _shipController.PlayerDeadEvent += PlayerDead;

            SpawnPoint = new Vector3(
                LevelView.transform.position.x, LevelView.transform.position.y - 4, LevelView.transform.position.z);
        }

        private void PlayerDead()
            => _uiController.GameOver(false);

        public void LevelCompleted()
        {
            _dataManager.GameData.LevelsCompleted[_dataManager.GameData.CurrentLevel] = true;
            _uiController.GameOver(true);
        }

        private void OnDestroy()
            => _shipController.PlayerDeadEvent -= PlayerDead;
    }
}