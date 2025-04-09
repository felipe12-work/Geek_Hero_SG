using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private float moveX, moveY;
    public Rigidbody2D rig2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Preencher o vetor de movimentação com os inputs dos eixos horizontal e
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Move();
        
    }

   void Move()
    {
        Vector3 direction = new Vector3(moveX, moveY, 0);
        rig2D.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }

}
