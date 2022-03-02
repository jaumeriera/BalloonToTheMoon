using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsSideEnemy(collision))
        {
            EnemySpawnerManager.spawnedInSide -= 1;
        }
        collision.gameObject.SetActive(false);
    }

    private bool IsSideEnemy(Collider2D collision)
    {
        BaseEnemy enemy = collision.GetComponent<BaseEnemy>();
        return enemy != null && enemy.type == BaseEnemy.enemyType.side;
    }
}
