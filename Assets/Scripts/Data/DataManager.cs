using UnityEngine;

namespace Data
{
    public class DataManager : MonoBehaviour
    {
        private bool _encrypt;
        private DataFileHandler _dataHandler;

        public GameData GameData { get; private set; }

        private void Awake()
        {
            _dataHandler = new DataFileHandler(_encrypt);
            LoadGame();
        }

        private void NewGame()
            => GameData = new GameData();

        private void LoadGame()
        {
            GameData = _dataHandler.Load();

            if (GameData is null)
                NewGame();
        }

        private void SaveGame()
            => _dataHandler.Save(GameData);

        private void OnApplicationQuit()
            => SaveGame();
    }
}