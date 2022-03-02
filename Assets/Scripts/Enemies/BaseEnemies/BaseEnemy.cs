using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : FallingMovement
{
    public enum enemyType
    {
        side = 0,
        center = 1,
        COUNT // Just for count the length of enum
    }

    public enemyType type;

}
