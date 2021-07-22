using UnityEngine;

[System.Serializable]
public class EnemyStage
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int enemyCount;

    public Enemy EnemyPrefab { get => enemyPrefab; }
    public int EnemyCount { get => enemyCount; }
}
