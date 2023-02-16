using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLevel1 : MonoBehaviour
{

    //this script essentially manages phases of the boss
    //this being, multiple phases with time durations, each corresponding to a weapon in a list
    //I will make a component for this
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

        if (TimeManager.isTime(1f, ref tasks[0])) {
            enemyBoss.phaseIndex = 0;
            enemyBoss.bulletSpawner.SpawnBullets();
        }
        if (TimeManager.isTime(2f, ref tasks[1])) {
            enemyBoss.phaseIndex = 1;
            enemyBoss.bulletSpawner.SpawnBullets();
        }
        if (TimeManager.isTime(3f, ref tasks[2])) {
            enemyBoss.phaseIndex = 2;
            enemyBoss.bulletSpawner.SpawnBullets();
        }
    }*/
}
