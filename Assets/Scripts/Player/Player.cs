using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int startHp;
    int hp;
    //Invincibility duration when hit
    public float bulletCooldown;
    //countdown until vulnerable again
    float bulletTimer;
    public Text hpText;

    //tbf maybe an instance of a weapon should just store its bullet pool
    public BulletSpawnData weapon;
    List<GameObject> bulletPool;

    BulletSpawner bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
        bulletSpawner = GetComponent<BulletSpawner>();
        bulletPool = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        hpText.text = hp.ToString();

        if (hp <= 0) {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKey("z"))
        {
            bulletSpawner.SpawnBullets(weapon,bulletPool);
        }

        if(bulletTimer > 0) bulletTimer -= Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletTimer > 0) return;
        
        if (collision.tag == "Bullet") {
            hp -= 1;
            bulletTimer = bulletCooldown;
        }
    }
}
