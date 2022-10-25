using System;
using Data;
using UnityEngine;

namespace SpaceShooter.Models
{
    public class LevelModel : GameElement
    {
        [field: SerializeField]
        public float ObstaclesTimeSpawnMin { get; private set; }
        [field: SerializeField]
        public float ObstaclesTimeSpawnMax { get; private set; }

        public float ObstacleSpawnTime { get; private set; }

        [field: SerializeField]
        public Color LevelColor { get; private set; }
        [field: SerializeField]
        public int DestroyObstaclePoints { get; private set; }
        [field: SerializeField]
        public int TargetScore { get; private set; }
        [field: SerializeField]
        public string ModelID { get; private set; }

        [ContextMenu("Generate ID")]
        private void GenerateId() => ModelID = Guid.NewGuid().ToString();

        public void Construct(DataManager dataManager)
        {
            dataManager.GameData.GeneratedParameters.TryGetValue(ModelID, out float parameter);

            if (parameter == 0)
            {
                var newParameter = UnityEngine.Random.Range(ObstaclesTimeSpawnMin, ObstaclesTimeSpawnMax);
                dataManager.GameData.GeneratedParameters.Add(ModelID, newParameter);
                ObstacleSpawnTime = newParameter;
            }
            else
                ObstacleSpawnTime = parameter;
        }
    }
}