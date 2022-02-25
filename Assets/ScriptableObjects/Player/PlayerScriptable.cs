using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptable", menuName = "Scriptables/PlayerScriptable", order = 1)]
public class PlayerScriptable : ScriptableObject
{
    [Range(0, 30)]
    public float speed;

    [Range(0, 30)]
    public float bounceSpeed;
}