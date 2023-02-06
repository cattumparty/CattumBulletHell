using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int startHp;
    int hp;
    public float bulletCooldown;
    float bulletTimer;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = hp.ToString();
        bulletTimer -= Time.deltaTime;
        if (hp <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" && bulletTimer <= 0) {
            hp -= 1;
            bulletTimer = bulletCooldown;
        }
    }
}
