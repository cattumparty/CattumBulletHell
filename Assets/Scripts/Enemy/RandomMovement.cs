using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 2f;
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private float timeLeft;
     
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            timeLeft += accelerationTime;
        }
    }
     
    void FixedUpdate()
    {
        transform.position += new Vector3(Random.Range(-1f, 1f) * speed * Time.deltaTime, Random.Range(-1f, 1f) * speed * Time.deltaTime, 0);
    }
}
