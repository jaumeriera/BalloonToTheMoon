using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMovement : MonoBehaviour
{
    [SerializeField] FallingScriptable _falling;
    void Update()
    {
        transform.position -= new Vector3(0, _falling.speed * Time.deltaTime, 0);
    }
}
