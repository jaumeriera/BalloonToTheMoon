using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PidgeonScriptable", menuName = "Scriptables/PidgeonScriptable", order = 6)]
public class PidgeonScriptable : ScriptableObject
{
    [Range(0, 10)]
    public float minDistanceX;
    [Range(0, 10)]
    public float maxDistanceX;
    [Range(0, 10)]
    public float lateralSpeed;
    [Range(0, 5)]
    public int waitingTime;

}
