using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //normalise the movement input (this means cattum will move at same speed in any direction)
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
        //move player in the input direction, speed is multiplied by 1 or 0.5 if shift is up or down
        transform.Translate(inputDirection * speed * (Input.GetKey("left shift") ? 0.5f : 1.0f) * Time.deltaTime);
    }
}

