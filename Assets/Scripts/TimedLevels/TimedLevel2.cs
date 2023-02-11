using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLevel2 : MonoBehaviour
{
    private bool[] tasks = new bool[100];
    private bool[] repeatedTasks = new bool[100];
    public BulletSpawner bulletSpawner;
    public void Start() {
        Time.fixedDeltaTime = 0.001f;
    }

    public void FixedUpdate() {

        if (bulletSpawner == null) return;

        for (int i = 0; i < 100; i += 1) {
            if (TimeManager.isTime((float)i/100f, ref repeatedTasks[i])) {
                bulletSpawner.index = 0;
                bulletSpawner.SpawnBullets();
            }
        }

    }
}
