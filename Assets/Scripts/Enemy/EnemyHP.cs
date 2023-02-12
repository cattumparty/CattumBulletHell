using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    public float hp;
    public Text hpText;
    public string type;
    GameObject[] text;

    public GameObject deathParticle;

    void Start()
    {
        text = GameObject.FindGameObjectsWithTag("BossHP");
        hpText = text[0].GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (type == "Boss") {

            hpText.text = hp.ToString();
        }
        if (hp <= 0) {
            if (type == "Boss") {
                SceneManager.LoadScene("Level2");
            }
            else Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer") {
            hp -= 1;
        }
    }



}
