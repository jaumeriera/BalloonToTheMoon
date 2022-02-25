using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundSpawnerScriptable", menuName = "Scriptables/BackgroundSpawnerScriptable", order = 4)]
public class BackgroundSpawnerScriptable : ScriptableObject
{
    public float MaxXSpawn;
    public float MinXSpawn;
    public float MinSpawnTime;
    public float MaxSpawnTime;
}