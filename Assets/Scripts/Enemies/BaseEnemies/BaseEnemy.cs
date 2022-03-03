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

    protected virtual void OnDisable()
    {
        if (IsSideEnemy())
        {
            EnemySpawnerManager.spawnedInSide -= 1;
        }
    }
    private bool IsSideEnemy()
    {
        return type == BaseEnemy.enemyType.side;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // TODO call to game over pannel
            print("GameOver");
        }
    }

}
