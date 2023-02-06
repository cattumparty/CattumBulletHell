using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;


    void Update()
    {
        Vector2 move = new Vector2(0.0f, 1.0f);
        transform.Translate(move * speed * Time.deltaTime);
    }
}
