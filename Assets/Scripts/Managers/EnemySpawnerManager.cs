using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] EnemySpawnerScriptable _spawner;

    // Game objects with all the information
    [SerializeField] List<GameObject> EnemySpawners;
    [SerializeField] List<GameObject> SideSpawners;

    // Transform list build based on provided GameObjects lists of spawners
    private List<Transform> EnemyTransformSpawners = new List<Transform>();
    private List<Transform> SideTransformSpawners = new List<Transform>();

    // Pool list build based on provided GameObjects lists of spawners
    private List<ObjectPool> EnemyPoolSpawners = new List<ObjectPool>();
    private List<ObjectPool> SidePoolSpawners = new List<ObjectPool>();

    Coroutine spawnerCoroutineReference;

    float timeFromLastSpawn;
    float currentSpawnTime;

    
    public static int spawnedInSide;

    private void Start()
    {
        SplitEnemySpawnerComponents();
        SplitSideSpawnerComponents();
        spawnerCoroutineReference = StartCoroutine(SpawnCoroutine());
        // Spawn inmediately
        timeFromLastSpawn = _spawner.initialTime;
        currentSpawnTime = _spawner.initialTime;
    }

    private void SplitEnemySpawnerComponents()
    {
        foreach(GameObject go in EnemySpawners){
            EnemyTransformSpawners.Add(go.transform);
            EnemyPoolSpawners.Add(go.GetComponent<ObjectPool>());
        }
    }

    private void SplitSideSpawnerComponents()
    {
        foreach(GameObject go in SideSpawners){
            SideTransformSpawners.Add(go.transform);
            SidePoolSpawners.Add(go.GetComponent<ObjectPool>());
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return null;
            timeFromLastSpawn += Time.deltaTime;
            if (timeFromLastSpawn > currentSpawnTime)
            {
                SpawnEnemy();
                NextSpawnTime();
                timeFromLastSpawn = 0f;
            }
        }
    }

    private void SpawnEnemy()
    {
        if (MustSpawnOnSide())
        {
            SpawnOnSide();
        } else
        {
            SpawnOnCenter();
        }
    }

    private bool MustSpawnOnSide()
    {
        BaseEnemy.enemyType enemy = (BaseEnemy.enemyType) UnityEngine.Random.Range(0, (int)BaseEnemy.enemyType.COUNT);
        return spawnedInSide < _spawner.maxSideSpawnAtTime && enemy == BaseEnemy.enemyType.side;
    }

    private void SpawnOnSide()
    {
        DoSpawn(SideTransformSpawners, SidePoolSpawners);
    }

    private void SpawnOnCenter()
    {
        DoSpawn(EnemyTransformSpawners, EnemyPoolSpawners);
    }

    private void DoSpawn(List<Transform> transforms, List<ObjectPool> pools)
    {
        // select random center and get components
        int spawnerIndex = ChoseRandomSpawnerIndex(transforms);
        Transform spawnAt = transforms[spawnerIndex];
        ObjectPool spawnerPool = pools[spawnerIndex];
        BaseEnemy enemy = (BaseEnemy)spawnerPool.GetNext();
        enemy.gameObject.transform.position = spawnAt.position + GetTransformOffset(enemy.type);
        enemy.gameObject.SetActive(true);
    }

    private int ChoseRandomSpawnerIndex<T>(List<T> spawnerList)
    {
        return UnityEngine.Random.Range(0, spawnerList.Count);
    }

    private Vector3 GetTransformOffset(BaseEnemy.enemyType enemyType)
    {
        float x;
        switch (enemyType)
        {
            case BaseEnemy.enemyType.side:
                x = UnityEngine.Random.Range(_spawner.minSideXOffset, _spawner.maxSideXOffset);
                return new Vector3(x, 0f, 0f);
            case BaseEnemy.enemyType.center:
                x = UnityEngine.Random.Range(_spawner.minCenterXOffset, _spawner.maxCenterXOffset);
                return new Vector3(x, 0f, 0f);
            default:
                #if UNITY_EDITOR
                throw new Exception("Calling to unknown type for enemy");
                #endif
                return new Vector3(0f, 0f, 0f);
        }
    }

    private void NextSpawnTime()
    {
        // This mathod could be improve to improve the player experience
        if (currentSpawnTime > _spawner.minTime)
        {
            currentSpawnTime -= _spawner.decrementTime;
        }

    }
}
