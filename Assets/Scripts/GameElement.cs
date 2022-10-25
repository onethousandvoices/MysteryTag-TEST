using UnityEngine;
using Zenject;

namespace SpaceShooter
{
    public class GameElement : MonoBehaviour
    {
        [Inject]
        protected App App;
    }
}