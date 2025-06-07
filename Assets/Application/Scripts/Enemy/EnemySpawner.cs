using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    
    [SerializeField]
    private float _spawnInterval = 2f;
    
    [SerializeField]
    private Transform[] _spawnPoints;

    private float _timer;
    
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(_player == null) return;
        
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            int rand = Random.Range(0, _spawnPoints.Length);
            Instantiate(_enemyPrefab, _spawnPoints[rand].position, Quaternion.identity);
            _timer = 0f;
        }
    }
}
