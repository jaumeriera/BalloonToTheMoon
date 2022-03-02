using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pidgeon : BaseEnemy
{
    [SerializeField] PidgeonScriptable _pidgeon;
    private float finalX;
    private bool changeDir;

    void Start()
    {
        StartCoroutine(GoAndWaitCoroutine());
    }

    private void OnEnable()
    {
        finalX = Random.Range(_pidgeon.minDistanceX, _pidgeon.maxDistanceX);
        // check for random initial direction
        if (Random.value < 0.5f)
        {
            finalX = -finalX;
        }
    }

    private IEnumerator GoAndWaitCoroutine()
    {
        float targetX;
        float step;
        bool arrived = false;
        while (true)
        {
            targetX = finalX + transform.position.x;
            while (!arrived && !changeDir)
            {
                step = _pidgeon.lateralSpeed * Time.deltaTime;
                transform.position += new Vector3(finalX * step, 0, 0);
                arrived = HasArrived(targetX);
                yield return null;
            }
            yield return new WaitForSeconds(_pidgeon.waitingTime);
            arrived = false;
            changeDir = false;
            finalX = -finalX;
        }
    }

    private bool HasArrived(float target)
    {
        return finalX > 0 ? transform.position.x >= target : transform.position.x <= target; 
    }
}
