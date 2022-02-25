using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesScriptable", menuName = "Scriptables/EnemiesScriptable", order = 2)]
public class EnemiesScriptable : ScriptableObject
{
    [Range(0, 30)]
    public float speed;

}