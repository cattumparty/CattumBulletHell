using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    Rigidbody2D rigidbodyComponent;

    private void Start()
    {
        direction = Random.insideUnitCircle;
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direction += (Vector3)Random.insideUnitCircle*0.05f;
        //bias towards the upper middle of the scene
        direction += (Vector3.up*2-transform.position)/1000;
        direction.Normalize();
        rigidbodyComponent.velocity = direction*speed;
    }
}
