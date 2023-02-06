using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftcamera : MonoBehaviour
{
    public Camera cameraa;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraa.transform.position = new Vector3(-16.4f, 0, -10);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraa.transform.position = new Vector3(0, 0, -10);

        }
    }
}
