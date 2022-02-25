using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerScriptable _player;
    public bool bounce;

    private void Start()
    {
        bounce = false;
    }
    void Update()
    {
        if (!bounce)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * _player.speed * Time.deltaTime, 0, 0);
        }
    }
}
