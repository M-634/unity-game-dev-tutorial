using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    
    [SerializeField]
    private float _spawnInterval = 2f;
    
    [SerializeField]
    private Transform[] _spawnPoints;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= _spawnInterval)
        {
            int rand = Random.Range(0, _spawnPoints.Length);
            Instantiate(_enemyPrefab, _spawnPoints[rand].position, Quaternion.identity);
            timer = 0f;
        }
    }
}
