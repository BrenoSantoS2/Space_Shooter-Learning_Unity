using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawner = false;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    void Update()
    {
        
    }

    IEnumerator Spawner()
    {

        while (_stopSpawner == false)
        {
            Vector3 enemyOffSet = new(Random.Range(-6.0f, 6.0f), 5, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, enemyOffSet, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(3);
        }
        
    }

    public void OnPlayerDead()
    {
        _stopSpawner = true;
    }

}
