using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    private bool movingLeft;
    public float movingSpeed = 5;
    public float minX = -10.0f;
    public float maxX = 10.0f;
    void start() {
        movingLeft = true;
    }

    void Update() {
        if (movingLeft) {
            transform.Translate(Vector2.left * movingSpeed * Time.deltaTime);
            if (transform.position.x <= minX) {
                movingLeft = false;
            }
        } else {
            transform.Translate(Vector2.right * movingSpeed * Time.deltaTime);
            if (transform.position.x >= maxX) {
                movingLeft = true;
            }
        }
    }
}