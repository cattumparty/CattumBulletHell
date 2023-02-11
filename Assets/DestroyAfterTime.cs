using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeLeft;
    // Start is called before the first frame update
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f) Destroy(gameObject);
    }

}
