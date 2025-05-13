using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        print(life);  // Exibe a vida atual no console
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            player.GetComponent<Player>().enemiesDefeat += 1;
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attackHitbox")
        {
           life = life -1; // Dano recebido pelo inimigo
           print(life);  // Exibe a vida atual no console
        }
        else if (collision.gameObject.tag == "damageHitbox")
        {
        collision.GetComponentInParent<Player>().hp -= 10;  // Dano causado ao player
        print(collision.GetComponentInParent<Player>().hp);
        }
    }
    
}
