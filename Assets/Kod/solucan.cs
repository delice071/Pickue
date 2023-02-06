using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solucan : MonoBehaviour
{
    
    private Animator anim;
    [SerializeField] private float speed;

    private bool facingRight;

    [SerializeField]private Transform[] spots;

    private float waittime;
    [SerializeField]private float starttime;

    
    public GameObject solucann;
    


    private void Start()
    {
        anim = GetComponent<Animator>();
        
        waittime = starttime;
        Flip();
    }
    private void Update()
    {
        if (facingRight)
        {
            if (waittime <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, spots[0].position, speed * Time.deltaTime);
                anim.SetBool("speed", true);
                if (Vector2.Distance(transform.position, spots[0].position) < .5f)
                {
                    Flip();
                    waittime = starttime;
                }
            }
            else
            {
                waittime -= Time.deltaTime;
                anim.SetBool("speed", false);
            }
            
        }
        else
        {
            if (waittime <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, spots[1].position, speed * Time.deltaTime);

                anim.SetBool("speed", true);
                if (Vector2.Distance(transform.position, spots[1].position) < .5f)
                {
                    Flip();
                    waittime = starttime;
                }
            }
            else
            {
                waittime -= Time.deltaTime;
                anim.SetBool("speed", false);
            }
        }
        


    }
    void Flip()
    {
        
        
            facingRight = !facingRight;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "kilic")
        {
            Destroy(solucann);

        }
    }




}
