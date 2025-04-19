using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        print(life);  // Exibe a vida atual no console
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attackHitbox")
        {
           life = life -1;
           print(life);  // Exibe a vida atual no console
        }
    }
    
}
