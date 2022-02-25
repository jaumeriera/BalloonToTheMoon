using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FallingScriptable", menuName = "Scriptables/FallingScriptable", order = 3)]
public class FallingScriptable : ScriptableObject
{
    [Range(0, 30)]
    public float speed;

}