using System;
using System.Collections;
using SpaceShooter.Models;
using SpaceShooter.Views;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Controllers
{
    public class ShipController : GameElement
    {
        [Inject]
        private ShipView _shipView;
        [Inject]
        private LevelController _levelController;

        private int _health;
        private Projectile _currentProjectile;
        private ShipModel _shipModel;
        private UIController _uiController;

        private Vector3 _spawnPoint;

        private float _activityDelay;
        private float _invulnerabilityTime;

        public event Action PlayerDeadEvent;

        private void Start()
        {
            _shipModel = App.Model.ShipModel;
            _spawnPoint = _levelController.SpawnPoint;

            _uiController = App.Controller.UIController;

            _activityDelay = App.Model.ShipModel.ActivityDelay;
            _invulnerabilityTime = App.Model.ShipModel.InvulnerabilityTime;

            _shipView.transform.position = _spawnPoint;
            _shipView.Input.FirePerformedEvent += OnFirePerformed;
            _health = _shipModel.Health;
            _currentProjectile = _shipModel.CurrentProjectile;
        }

        private void OnFirePerformed()
        {
            Instantiate(_currentProjectile, _shipView.FirePoint.position, Quaternion.identity)
                .Init(_uiController,_levelController.LevelView.ScreenHeight, Vector2.up);
        }

        public void Collision()
        {
            _health--;
            if (_health <= 0)
            {
                PlayerDeadEvent?.Invoke();
                return;
            }
            Respawn();
        }

        private void Respawn()
        {
            _shipView.transform.position = _spawnPoint;
            StartCoroutine(Invulnerable());
        }

        private IEnumerator Invulnerable()
        {
            _shipView.SetVulnerabilityState(false);
            var rendererActivityDelay = _activityDelay;
            var invulnerabilityTime = _invulnerabilityTime;

            while (invulnerabilityTime > 0)
            {
                invulnerabilityTime -= Time.deltaTime;
                rendererActivityDelay -= Time.deltaTime;

                if (rendererActivityDelay <= 0f)
                {
                    _shipView.Renderer.enabled = !_shipView.Renderer.enabled;
                    rendererActivityDelay = _activityDelay;
                }

                yield return null;
            }
            _shipView.Renderer.enabled = true;
            _shipView.SetVulnerabilityState(true);
        }

        private void OnDestroy()
            => _shipView.Input.FirePerformedEvent -= OnFirePerformed;
    }
}