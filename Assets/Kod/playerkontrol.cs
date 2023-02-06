using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class playerkontrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audiosrc;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform[] groundTransform;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private float attackcooldown;
    [SerializeField] private Collider2D attackCollider;
    [SerializeField] private GameObject levelfinish, deadmenu;
    private bool attack;
    private float attacktimer;
    private bool grounded;
    private bool birKereZipla= true;
    private bool facingRight;
    public float zaman = 0, zaman2 =0;
    public float can;
    public AudioClip deathV, jumpV, levelcompleteV, turnedV, attackV;

   

    public GameObject door;
    public float xDuvar, yDuvar;

    void Start()
    {
        Time.timeScale = 1;
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audiosrc = GetComponent<AudioSource>();
        attack = false;
        attackCollider.enabled = false;
        anim.SetBool("deadcheck", false);
        if(SceneManager.GetActiveScene().buildIndex> PlayerPrefs.GetInt("kacincilevel"))
        {
            PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex);
        }
        levelfinish.SetActive(false);
        deadmenu.SetActive(false);
        can = 5;

    }

    void Update()
    {
        Attack();

        if (grounded && Input.GetKeyDown(KeyCode.Space) || grounded && Input.GetKeyDown(KeyCode.UpArrow) || grounded && Input.GetKeyDown(KeyCode.W))
        {
            if (birKereZipla)
            {
                GetComponent<AudioSource>().PlayOneShot(jumpV, 0.6f);
                grounded = false;
                anim.SetBool("groundcheck", grounded);
                rb.AddForce(new Vector2(0, jumpForce));
                birKereZipla = false;
            }
            
        }
        
        
    }

    void FixedUpdate()
    {
        grounded = isgrounded();
        anim.SetBool("groundcheck", grounded);
        anim.SetFloat("yAxisSpeed", rb.velocity.y);
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);
        Flip(horizontal);
        if (can == 0)
        {
            
            anim.SetBool("deadcheck", true);
            zaman += Time.deltaTime;
            if (zaman > 1.05f)
            {
                GetComponent<AudioSource>().PlayOneShot(deathV, 0.8f);
                Time.timeScale = 0;
                deadmenu.SetActive(true);
            }
        }
        
    }

    void Movement(float horizontal)
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("speed",Mathf.Abs(horizontal));
        



    }

    void Flip(float horizontal)
    {
        if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            
        }
        
    }

    private bool isgrounded()
    {
        if ( rb.velocity.y <= 0)
        {
            foreach (Transform trans in groundTransform)
            {
                Collider2D [] colliders = Physics2D.OverlapCircleAll(trans.position, groundRadius, groundlayer);

                for(int i=0; i < colliders.Length; i++)
                {
                    if ( colliders[i].gameObject!= gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void Attack()
    {
        if (Input.GetKeyDown("z") && !attack)
        {
            GetComponent<AudioSource>().PlayOneShot(attackV, 0.8f);
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sopa")
        {
            collision.GetComponent<mizrak>().enabled = true;

        }
        if (collision.gameObject.tag == "dead")
        {
            if (attackCollider.enabled)
            {
                can++;

            }
            else if(!attackCollider.enabled)
            {
                can = 0;
            }
            

        }
        if (collision.gameObject.tag == "turned")
        {
            if (attackCollider.enabled)
            {
                GetComponent<AudioSource>().PlayOneShot(turnedV, 0.8f);
                collision.GetComponent<turned>().enabled = true;
                door.transform.position = new Vector3(xDuvar, yDuvar, 0);
            }
            
        }
        if(collision.gameObject.tag == "mushroom")
        {
            GetComponent<AudioSource>().PlayOneShot(jumpV, 0.6f);
            grounded = false;
            anim.SetBool("groundcheck", grounded);
            rb.AddForce(new Vector2(0, 1200));
        }
        if(collision.gameObject.tag == "levelfinish")
        {
            GetComponent<AudioSource>().PlayOneShot(levelcompleteV, 0.8f);
            levelfinish.SetActive(true);
            
            
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        birKereZipla = true;
        
    }




}
