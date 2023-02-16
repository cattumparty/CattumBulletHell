using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public static List<GameObject> bullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }
    public static GameObject GetBulletFromPool(List<GameObject> pool) {

        for (int i = 0; i < pool.Count; i++) {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return null;
    }
}
