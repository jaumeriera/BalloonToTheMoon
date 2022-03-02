using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerScriptable", menuName = "Scriptables/EnemySpawnerScriptable", order = 4)]
public class EnemySpawnerScriptable : ScriptableObject
{
    [Range(0, 30)]
    public int maxSideSpawnAtTime;

    // Offset for spawners
    [Range(-30, 30)]
    public float minSideXOffset;
    [Range(-30, 30)]
    public float maxSideXOffset;
    [Range(-30, 30)]
    public float minCenterXOffset;
    [Range(-30, 30)]
    public float maxCenterXOffset;

    // Variables to control spawn times
    [Range(0, 1)]
    public float minTime;
    [Range(0, 1)]
    public float decrementTime;
    [Range(0, 5)]
    public float initialTime;

}