using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] duckSpawnPoints;
    [SerializeField] private Transform[] duckTargetTransforms;
    [SerializeField] private Duck duckPrefab;
    private int lastRandNum;
    private void Start()
    {
        GameManager.onGameStarted += SpawnDuck;
    }
    private void OnDisable()
    {
        GameManager.onGameStarted -= SpawnDuck;
    }
    private void SpawnDuck()
    {
        Duck newDuck=Instantiate(duckPrefab);
        newDuck.transform.position = GetDuckSpawnPoint();
        newDuck.SetDuckTarget(GetDuckTarget());
        StartCoroutine(DuckSpawnDelay());
    }
    private Vector3 GetDuckSpawnPoint()
    {
        lastRandNum = Random.Range(0, duckSpawnPoints.Length);
        return duckSpawnPoints[lastRandNum].position;
    }
    private Transform GetDuckTarget()
    {
        if (lastRandNum == 1 || lastRandNum == 0 || lastRandNum == 6)
        {
            return duckTargetTransforms[Random.Range(3, 6)];
        }
        else
        {
            return duckTargetTransforms[Random.Range(0, 4)];
        }
        
    }
    private IEnumerator DuckSpawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        SpawnDuck();
    }
}
