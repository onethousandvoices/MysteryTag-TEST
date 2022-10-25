using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter.Views
{
    public class UIView : GameElement
    {
        [field: SerializeField]
        public TextMeshProUGUI ScorePoints;
        [field: SerializeField]
        public GameObject PauseMenu;
        [field: SerializeField]
        public GameObject EndGameMenu;
        [field: SerializeField]
        public Button EndGameMenuNextButton;
    }
}