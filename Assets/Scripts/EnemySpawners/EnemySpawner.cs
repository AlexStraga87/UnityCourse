using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyTargetMovement _template;
    [SerializeField] private Transform _enemyTarget;
    [SerializeField] private List<Transform> _spawnersPoints;    
    [SerializeField] private float _timeSpawn = 2;
    [SerializeField] private bool _isRandomSpawnPoint;
    private int _indexSpawner = 0;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void SpawnEnemy(Vector3 position)
    {
        EnemyTargetMovement newEnemy = Instantiate(_template, position, Quaternion.identity);
        newEnemy.SetTarget(_enemyTarget);
    }
    
    private IEnumerator SpawnCoroutine()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeSpawn);

        while (true)
        {
            yield return waitForSeconds;
            if (_isRandomSpawnPoint)
            {
                SpawnEnemy(_spawnersPoints[Random.Range(0, _spawnersPoints.Count)].position);
            }
            else
            {
                SpawnEnemy(_spawnersPoints[_indexSpawner].position);
                _indexSpawner++;
                if (_indexSpawner >= _spawnersPoints.Count)
                    _indexSpawner = 0;
            }
        }
    }
}
