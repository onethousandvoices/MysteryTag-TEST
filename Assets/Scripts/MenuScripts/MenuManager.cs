using System.Linq;
using Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace SpaceShooter.MenuScripts
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private Button[] _levelButtons;

        [Inject]
        private DataManager _dataManager;

        private void Start()
        {
            var completedLevels = _dataManager.GameData.LevelsCompleted.Count(kvp => kvp.Value);

            for (int i = 0; i <= completedLevels; i++)
            {
                if (i == 3) break;
                _levelButtons[i].interactable = true;
            }
        }

        public void UnityEvent_LoadLevel(int i)
        {
            _dataManager.GameData.CurrentLevel = i;
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