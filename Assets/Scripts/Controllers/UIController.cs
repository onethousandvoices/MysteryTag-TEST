using Data;
using SpaceShooter.Models;
using SpaceShooter.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace SpaceShooter.Controllers
{
    public class UIController : GameElement
    {
        [SerializeField]
        private UIView _view;

        [Inject]
        private LevelController _levelController;
        [Inject]
        private DataManager _dataManager;

        private LevelModel _model;

        private void Start()
        {
            _model = App.Model.LevelModel;

            _view.EndGameMenu.SetActive(false);
            _view.PauseMenu.SetActive(false);
            _view.ScorePoints.text = "0";
        }

        public void ProjectileHit()
        {
            var points = int.Parse(_view.ScorePoints.text);
            points += _model.DestroyObstaclePoints;

            _view.ScorePoints.text = points.ToString();

            if (points >= _model.TargetScore)
                _levelController.LevelCompleted();
        }

        public void GameOver(bool isWin)
        {
            Time.timeScale = 0f;
            _view.EndGameMenu.SetActive(true);

            if (isWin && _dataManager.GameData.CurrentLevel < 2)
                _view.EndGameMenuNextButton.interactable = true;
            else
                _view.EndGameMenuNextButton.interactable = false;
        }

        public void UnityEvent_OnPause()
        {
            Time.timeScale = 0f;
            _view.PauseMenu.SetActive(true);
        }

        public void UnityEvent_OnResume()
        {
            Time.timeScale = 1f;
            _view.PauseMenu.SetActive(false);
        }

        public void UnityEvent_OnRestart()
            => SceneManager.LoadScene(1);

        public void UnityEvent_OnNextLevel()
        {
            _dataManager.GameData.CurrentLevel++;
            SceneManager.LoadScene(1);
        }

        public void UnityEvent_OnQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN
            Application.Quit();
#endif
        }
    }
}