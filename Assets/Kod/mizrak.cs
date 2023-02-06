using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mizrak : MonoBehaviour
{
    
    public GameObject mizrakk;
    public float mizrakhiz = -0.06f;

    void Start()
    {
       
        

    }

    void Update()
    {

        
            mizrakk.transform.position += new Vector3(0, mizrakhiz, 0);
        

    }


}
