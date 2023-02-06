using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnedkontrol : MonoBehaviour
{
    public GameObject door2, door3, door4;
    [SerializeField] private Collider2D attackCollider;
    public float x2Duvar, y2Duvar, x3Duvar, y3Duvar, x4Duvar, y4Duvar;
    public AudioClip turnedV;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "turned2")
        {
            if (attackCollider.enabled)
            {
                GetComponent<AudioSource>().PlayOneShot(turnedV, 0.8f);
                collision.GetComponent<turned2>().enabled = true;
                door2.transform.position = new Vector3(x2Duvar, y2Duvar, 0);
            }

        }
        if (collision.gameObject.tag == "turned3")
        {
            if (attackCollider.enabled)
            {
                GetComponent<AudioSource>().PlayOneShot(turnedV, 0.8f);
                collision.GetComponent<turned3>().enabled = true;
                door3.transform.position = new Vector3(x3Duvar, y3Duvar, 0);
            }

        }
        if (collision.gameObject.tag == "turned4")
        {
            if (attackCollider.enabled)
            {
                GetComponent<AudioSource>().PlayOneShot(turnedV, 0.8f);
                collision.GetComponent<turned4>().enabled = true;
                door4.transform.position = new Vector3(x4Duvar, y4Duvar, 0);
            }

        }
    }
}
