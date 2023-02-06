using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterKontrol : MonoBehaviour
{
    public Sprite[] beklemeAnim;
    public Sprite[] ziplamaAnim;
    public Sprite[] yurumeAnim;
    public Sprite[] deadAnim;
    

    
    SpriteRenderer spriteRendere;

    int beklemeAnimsayac=0;
    int yurumeAnimsayac=0;
    int deadAnimsayac = 0;

    Animator anim;
    Rigidbody2D fizik;
    public float speed;
   
    
    Vector3 vec;

    float horizontal;
    float beklemezaman=0;
    float yurumezaman = 0;
    float deadzaman = 0;
   
    float can = 10;

    bool birKereZipla = true;
    bool birKeredash = true;
    bool oyundevam = true;

    public float DashForce;
    public float StartDashTimer;

    float CurrentDashTimer;
    float Dashdirection;

    bool isDashing;


    private bool attack;
    private float attacktimer;
    [SerializeField]
    private float attackcooldown;
    [SerializeField] private Collider2D attackCollider;


    void Start()
    {
        
        spriteRendere = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attack = false;
        attackCollider.enabled = false;

    }

    void Update()
    {
        Attack();
        
        if (oyundevam)
        {
           
            horizontal = Input.GetAxis("Horizontal");
            fizik.velocity = new Vector2(horizontal * speed, fizik.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (birKereZipla)
                {
                    fizik.AddForce(new Vector2(0, 500));
                    birKereZipla = false;
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && horizontal != 0)
            {
                if (birKeredash)
                {
                    isDashing = true;
                    CurrentDashTimer = StartDashTimer;
                    fizik.velocity = Vector2.zero;
                    Dashdirection = (int)horizontal;
                    birKeredash = false;
                }

            }

            if (isDashing)
            {
                fizik.velocity = transform.right * Dashdirection * DashForce;

                CurrentDashTimer -= Time.deltaTime;

                if (CurrentDashTimer <= 0)
                {
                    isDashing = false;
                }


            }
            
            
           
               

        } 
        else
        {
            fizik.velocity = Vector2.zero;
        }
        
       
        



    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        

        Animasyon();
    }

    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        birKereZipla = true;
        birKeredash = true;
    }


    void Animasyon()
    {
        if (birKereZipla)
        {
            if (horizontal == 0)
            {
                beklemezaman += Time.deltaTime;
                if (beklemezaman > 0.1f)
                {
                    spriteRendere.sprite = beklemeAnim[beklemeAnimsayac++];
                    if (beklemeAnimsayac == beklemeAnim.Length)
                    {
                        beklemeAnimsayac = 0;
                    }
                    beklemezaman = 0;
                }


            }
            else if (horizontal > 0)
            {
                yurumezaman += Time.deltaTime;
                if (yurumezaman > 0.1f)
                {
                    spriteRendere.sprite = yurumeAnim[yurumeAnimsayac++];
                    if (yurumeAnimsayac == yurumeAnim.Length)
                    {
                        yurumeAnimsayac = 0;
                    }
                    yurumezaman = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if (horizontal < 0)
            {
                yurumezaman += Time.deltaTime;
                if (yurumezaman > 0.1f)
                {
                    spriteRendere.sprite = yurumeAnim[yurumeAnimsayac++];
                    if (yurumeAnimsayac == yurumeAnim.Length)
                    {
                        yurumeAnimsayac = 0;
                    }
                    yurumezaman = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (fizik.velocity.y> 0)
            {
                spriteRendere.sprite = ziplamaAnim[0];
                spriteRendere.sprite = ziplamaAnim[1];
                spriteRendere.sprite = ziplamaAnim[2];
               
                
            }
            else
            {
                spriteRendere.sprite = ziplamaAnim[3];
                spriteRendere.sprite = ziplamaAnim[4];
                spriteRendere.sprite = ziplamaAnim[5];

            }
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if(can == 0)
        {
            deadzaman += Time.deltaTime;
            if (deadzaman > 0.1f)
            {
                spriteRendere.sprite = deadAnim[deadAnimsayac++];
                if (deadAnimsayac == deadAnim.Length)
                {
                    deadAnimsayac = deadAnim.Length - 1;
                }
               
            }
        }
        
        


    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sopa")
        {
            collision.GetComponent<mizrak>().enabled = true;
           
        }
        if (collision.gameObject.tag == "dead")
        {
            can = 0;
            oyundevam = false;
        }

    }

    private void Attack()
    {
        if (Input.GetKeyDown("z") && !attack)
        {
            attack = true;
            anim.SetTrigger("attack");
            attacktimer = attackcooldown;
            attackCollider.enabled = true;
        }
        if (attack)
        {
            if (attacktimer > 0)
            {
                attacktimer -= Time.deltaTime;
            }
            else
            {
                attack = false;
                attackCollider.enabled = false;
            }
        }
        

    }




}
