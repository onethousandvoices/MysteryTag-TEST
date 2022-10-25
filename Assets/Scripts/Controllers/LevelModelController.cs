using Data;
using SpaceShooter.Models;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Controllers
{
    public class LevelModelController : GameElement
    {
        [SerializeField]
        private LevelModel[] _models;
        [SerializeField]
        private Transform _gameModel;

        [Inject]
        private DataManager _dataManager;

        private void Awake()
        {
            var model = Instantiate(
                _models[_dataManager.GameData.CurrentLevel], transform.position, Quaternion.identity, _gameModel);

            model.Construct(_dataManager);

            App.Model.SetLevelModel(model);
        }
    }
}