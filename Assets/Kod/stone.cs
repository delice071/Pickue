using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{

    public int count = 0;
    public GameObject door;
    float zaman = 0;
    public float xDuvar, yDuvar, xyenikonum, yyenikonum;
    public AudioClip button;
    
    
    
    
    void Update()
    {
        if (count == 1)
        {
            zaman += Time.deltaTime;
            if (zaman > 0.5f)
            {
                door.transform.position = new Vector3(xyenikonum, yyenikonum, 0);
            }



        }
        if (count == 0)
        {
            zaman += Time.deltaTime;
            if (zaman > 0.5f)
            {
                door.transform.position = new Vector3(xDuvar, yDuvar, 0);
            }



        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "button")
        {
            GetComponent<AudioSource>().PlayOneShot(button, 1f);
            collision.GetComponent<buttonn>().enabled = true;
            collision.GetComponent<button2>().enabled = false;
            count++;



        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "button")
        {
            GetComponent<AudioSource>().PlayOneShot(button, 1f);
            collision.GetComponent<buttonn>().enabled = false;
            collision.GetComponent<button2>().enabled = true;
            count--;

        }

    }
}
