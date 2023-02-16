using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FiringPattern
{
    None,
    Spin,
    Sine,
    Helix
}

public class BulletSpawner : MonoBehaviour
{
    public Quaternion shootingRotation;
    
    //firing cooldown timer
    float timer;
    //could actually just store the time last fired so you don't have to increment this every frame?


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0) timer -= Time.deltaTime;
    }

    public void SpawnBullets(BulletSpawnData weapon,List<GameObject> bulletPool)
    {
        if (timer > 0) return;
        timer = weapon.cooldown;

        for(int b = 0; b < weapon.numberOfBullets; b++)
        {
            //get bullet from pool or spawn new
            GameObject bullet = BulletManager.GetBulletFromPool(bulletPool);
            if (!bullet)
            {
                bullet = Instantiate(weapon.bulletResource);
                bulletPool.Add(bullet);
            }
            

            //initialise the bullet transform
            bullet.transform.position = transform.position;

            //apply aiming rotation
            bullet.transform.rotation = shootingRotation;

            //calculate angle to spread the bullet to (random or distributed)
            float bulletAngle = weapon.isRandom ? 
                Random.Range(-weapon.maxRotation, weapon.maxRotation) 
                : 
                (2 * b + 1) * (weapon.maxRotation / weapon.numberOfBullets) - weapon.maxRotation;
            

            switch (weapon.pattern)
            {
                case FiringPattern.Spin:
                    bullet.transform.Rotate(Vector3.forward, Time.time * 180f);
                    break;
                case FiringPattern.Sine:
                    bullet.transform.Rotate(Vector3.forward, Mathf.Sin(Time.time*2f) * 90);
                    break;
                case FiringPattern.Helix:
                    bulletAngle *= Mathf.Sin(Time.time * 4f);
                    break;
                default:
                    break;
            }

            //apply spread rotation
            bullet.transform.Rotate(Vector3.forward, bulletAngle);

            bullet.SetActive(true);

        }

        
    }
    
}
