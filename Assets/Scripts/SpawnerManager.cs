using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] _powerUps;
    [SerializeField]
    private GameObject _enemyContainer;
    

    private bool _stopSpawner = false;
    void Start()
    {
        StartCoroutine(EnemySpawner());
        StartCoroutine(PowerUpSpawner());
    }

    void Update()
    {
        
    }

    IEnumerator EnemySpawner()
    {

        while (_stopSpawner == false)
        {
            Vector3 enemyOffSet = new(Random.Range(-6.0f, 6.0f), 5, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, enemyOffSet, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(3);
        }
        
    }
    IEnumerator PowerUpSpawner()
    {

        while (_stopSpawner == false)
        {
            Vector3 powerUpOffSet = new(Random.Range(-6.0f, 6.0f), 5, 0);
            int randomPowerUp = Random.Range(0, 3);
            GameObject newPowerUP = Instantiate(_powerUps[randomPowerUp], powerUpOffSet, Quaternion.identity);
            yield return new WaitForSeconds(10);
        }

    }

    public void OnPlayerDead()
    {
        _stopSpawner = true;
    }

}
