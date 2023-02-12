using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletSpawnData[] spawnDatas;
    public int index = 0;
    public bool isSequenceRandom;
    public bool spawningAutomatically;
    private float angle = 0f;
    BulletSpawnData GetSpawnData() {
        return spawnDatas[index];
    }


    float timer;

    float [] rotations;
    // Start is called before the first frame update
    void Start()
    {

        rotations = new float[GetSpawnData().numberOfBullets];

        timer = GetSpawnData().cooldown;

        if (!GetSpawnData().isRandom) {

            DistributedRotations();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnDatas == null) return;
        if (spawningAutomatically) {
            if (timer <= 0) {
                SpawnBullets();
                timer = GetSpawnData().cooldown;
                if(isSequenceRandom) {
                    index = Random.Range(0, spawnDatas.Length);
                } else {
                    index += 1;
                    if (index >= spawnDatas.Length) index = 0;
                }
            }

            timer -= Time.deltaTime;
        }
    }

    public float[] RandomRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++) {
            rotations[i] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;
    }

    public float[] DistributedRotations() 
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++) {
            var fraction = (float)i / ((float)GetSpawnData().numberOfBullets-1);
            var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + GetSpawnData().minRotation;
        }

        return rotations;
    }

    bool isOne = false;

    public GameObject[] SpawnBullets()
    {



        if (GetSpawnData().isRandom) {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++) {

            spawnedBullets[i] = BulletManager.GetBulletFromPool();
            if (spawnedBullets[i] == null) {
                spawnedBullets[i] = Instantiate(GetSpawnData().bulletResource, transform);
                BulletManager.bullets.Add(spawnedBullets[i]);
                spawnedBullets[i].transform.SetParent(transform);
                spawnedBullets[i].transform.localPosition = Vector2.zero;
            } else {
                spawnedBullets[i].transform.SetParent(transform);
                spawnedBullets[i].transform.localPosition = Vector2.zero;
            }
            if (GetSpawnData().isParent) {
                spawnedBullets[i].transform.SetParent(null);
            }

            var b = spawnedBullets[i].GetComponent<Bullet>();

            if (GetSpawnData().pattern == "DoubleSpiral") {
                //awfulness done to make bullets shoot in both directions
                if (isOne) {
                    PatternDoubleSpiral(b, 1);
                    isOne = false;
                } else {
                    PatternDoubleSpiral(b, 0);
                    isOne = true;
                }
            }

            else {
                b.velocity = GetSpawnData().bulletVelocity;
                b.rotation = rotations[i];
            }

            b.speed = GetSpawnData().bulletSpeed;

        }

        return spawnedBullets;
    }

    private void PatternDoubleSpiral(Bullet bullet, int x) {
        float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * x) * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * x) * Mathf.PI) / 180f);
       
        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;


        bullet.velocity = bulDir;
        
        angle += 10f;

        if (angle >= 360f) angle = 0f;
    }
}
