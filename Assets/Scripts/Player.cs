using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp = 100;
    [SerializeField]  float moveSpeed;
    private float moveX, moveY;
    [SerializeField]  Rigidbody2D rig2D;
    private bool isMoving;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Preencher o vetor de movimentação com os inputs dos eixos horizontal e
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        
        // Chama o método Move
        Move();
        // Chama o método Animation
        Animation();
        // Chama o método Attack
        Attack();
        print(hp);
    }

   void Move()
    {
        Vector3 direction = new Vector3(moveX, moveY, 0);
        rig2D.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        
    }

void Animation()
{
    if (moveX == 0 && moveY == 0)
    {
        isMoving = false;
    }
    else
    {
        isMoving = true;
    }

    anim.SetBool("isMoving", isMoving);

    anim.SetFloat("Horizontal", moveX);
    anim.SetFloat("Vertical", moveY);
}

 void Attack()
 {
    if(Input.GetKeyDown(KeyCode.Space))
    {
        anim.SetTrigger("isAttack");
    }
 }



}