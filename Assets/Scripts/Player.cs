using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]  float moveSpeed;
    private float moveX, moveY;
    [SerializeField]  Rigidbody2D rig2D;
    private bool isMoving;
    private Animator anim;
    public Image heart;
    public float hp;
    public float maxHp = 100;
    public int enemiesDefeat = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //Preencher o vetor de movimentação com os inputs dos eixos horizontal e Vertical
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        
        Move(); // Chama o método Move
        Animation(); // Chama o método Animation
        Attack();// Chama o método Attack
        UpdateUI(); // Atualiza a barra de vida 

        if(hp < 0)
        {
            SceneManager.LoadScene("SceneGameOver");
        }

    }

    void UpdateUI()
    {
        heart.fillAmount = hp / maxHp;
    }

    void Move()
    {
        Vector3 direction = new Vector3(moveX, moveY, 0).normalized;
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