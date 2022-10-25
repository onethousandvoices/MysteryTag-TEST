using SpaceShooter.Controllers;
using UnityEngine;
using SpaceShooter.Views;
using SpaceShooter.Models;

namespace SpaceShooter
{
    public class App : MonoBehaviour
    {
        [field: SerializeField]
        public GameModel Model { get; private set; }
        [field: SerializeField]
        public GameView View { get; private set; }
        [field: SerializeField]
        public GameController Controller { get; private set; }
    }
}