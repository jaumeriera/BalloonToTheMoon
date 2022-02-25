using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollision: MonoBehaviour
{
    [SerializeField] PlayerScriptable _player;
    private Coroutine doBounceCorroutine;
    private PlayerMovement movement;
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "wall")
        {
            float bounceForce = collision.gameObject.GetComponent<WallProperties>().bounceForce;
            if (doBounceCorroutine == null)
            {
                print("docoroutine");
                movement.bounce = true;
                doBounceCorroutine = StartCoroutine(DoBounce(bounceForce));
            }
        }
    }

    private IEnumerator DoBounce(float bounceForce)
    {
        Vector3 destination = new Vector3(transform.position.x + bounceForce, 0, 0);
        while (MustBounce(bounceForce, destination))
        {
            transform.position += new Vector3(bounceForce * _player.bounceSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
        movement.bounce = false;
        doBounceCorroutine = null;
    }

    private bool MustBounce(float bounceForce, Vector3 destination)
    {
        return bounceForce >= 0 ? destination.x >= transform.position.x : destination.x <= transform.position.x;
    }
}
