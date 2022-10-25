namespace Data
{
    [System.Serializable]
    public class GameData
    {
        public SerializableDictionary<string, float> GeneratedParameters;
        public SerializableDictionary<int, bool> LevelsCompleted;
        public int CurrentLevel;

        public GameData()
        {
            GeneratedParameters = new SerializableDictionary<string, float>();
            LevelsCompleted = new SerializableDictionary<int, bool>
            {
                {0, false},
                {1, false},
                {2, false},
            };
            CurrentLevel = 0;
        }
    }
}