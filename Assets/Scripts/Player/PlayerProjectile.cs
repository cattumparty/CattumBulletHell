using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    [SerializeField]
    private GameObject projectilePrefab;
    private float cooldown = 0.1f;

    float timer;

    void Start() {
        timer = cooldown;
    }


    void Update()
    {
        if(Input.GetKey("z"))
        {
            if (timer <= 0.0f) {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                timer = cooldown;
            }
        }

        timer -= Time.deltaTime;
    }


}
