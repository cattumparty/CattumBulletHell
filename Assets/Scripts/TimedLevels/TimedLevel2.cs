using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLevel2 : MonoBehaviour
{
    private bool[] tasks = new bool[100];
    private bool[] repeatedTasks = new bool[100];
    public EnemyBehaviourComponent enemyBoss;
    public void Start() {
        Time.fixedDeltaTime = 0.001f;
    }

    /*public void FixedUpdate() {

        for (int i = 0; i < 100; i += 1) {
            if (TimeManager.isTime(i/100f, ref repeatedTasks[i])) {
                enemyBoss.phaseIndex = 0;
                enemyBoss.bulletSpawner.SpawnBullets();
            }
        }

    }*/
}
