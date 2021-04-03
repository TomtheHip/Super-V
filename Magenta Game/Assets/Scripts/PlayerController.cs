using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
   public static PlayerController instance; 
    public float MoveSpeed;
    public Rigidbody2D TheRB;

    public float JumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public float hangTime = .1f;
    private float hangCounter;

    private Animator anim;
    private SpriteRenderer theSR;

    public float knockBackLenght, knockBackForce; 
    private float knockBackCounter;

    private void Awake()
    {
        instance = this; 
    }



   // Start is called before the first frame update

    public ParticleSystem Dust;


    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(knockBackCounter <= 0)
      {  
        TheRB.velocity = new Vector2(MoveSpeed * Input.GetAxisRaw("Horizontal"), TheRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .335f, whatIsGround); 

        if(isGrounded)
        {
            hangCounter = hangTime;
        } else
        {
            hangCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump"))
        {
            CreateDust();
            if (hangCounter > 0f)
            TheRB.velocity = new Vector2(TheRB.velocity.x, JumpForce);
        }

        if(Input.GetButtonUp("Jump") && TheRB.velocity.y>0)
        {
            TheRB.velocity = new Vector2(TheRB.velocity.x, TheRB.velocity.y * .5f);
        }

        if (TheRB.velocity.x < 0)
        {
            theSR.flipX = true;
        } 
        else if (TheRB.velocity.x > 0) 
        {
            theSR.flipX = false;
        }
      }else
       {
           knockBackCounter -= Time.deltaTime;
            if(!theSR.flipX)
            {
                TheRB.velocity = new Vector2(-knockBackForce, TheRB.velocity.y);  
            }else
            {
                TheRB.velocity = new Vector2(knockBackForce, TheRB.velocity.y);  
            }
       } 
        
        anim.SetFloat("moveSpeed", Mathf.Abs(TheRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded); 
      
    }

    void CreateDust()
    {
        Dust.Play(); 
    } 
    public void knockBack()
    {
        knockBackCounter = knockBackLenght;
    
        anim.SetTrigger("Hurt");
    }

}

