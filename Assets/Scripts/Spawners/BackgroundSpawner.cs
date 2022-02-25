using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] BackgroundSpawnerScriptable _spawner;

    private float timeFromLastSpawn;
    private float nextSpawnTime;
    ObjectPool backgroundPool;
    void Awake()
    {
        backgroundPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
        nextSpawnTime = GetNewSpawnTime();
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return null;
            timeFromLastSpawn += Time.deltaTime;
            if (timeFromLastSpawn > nextSpawnTime)
            {
                SpawnElement();
                timeFromLastSpawn = 0f;
                nextSpawnTime = GetNewSpawnTime();
            }
        }
    }

    private float GetNewSpawnTime()
    {
        return Random.Range(_spawner.MinSpawnTime, _spawner.MaxSpawnTime);
    }

    private void SpawnElement()
    {
        FallingMovement element = (FallingMovement) backgroundPool.GetNext();
        element.transform.position = GetRandomPoint();
        element.gameObject.SetActive(true);
    }

    private Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(_spawner.MinXSpawn, _spawner.MaxXSpawn), gameObject.transform.position.y, 0);
    }

}
