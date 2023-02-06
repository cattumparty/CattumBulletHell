using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    public float hp;
    public Text hpText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = hp.ToString();
        if (hp <= 0) {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer") {
            hp -= 1;
        }
    }
}
