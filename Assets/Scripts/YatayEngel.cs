using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YatayEngel : MonoBehaviour
{
    
    Rigidbody Rb;
    
    public Vector3 Sol;
    public Vector3 Sag;
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        
       
        
    }
   
    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
    }
    
    //private void FixedUpdate()
    //{

    //}

    void HorizontalMove()
    {
        if (transform.position.z<Sol.z)
        {
            Rb.velocity = transform.forward * 5f;
        }
        if (transform.position.z>Sag.z)
        {
            Rb.velocity = -(transform.forward * 5f);
        }
    }
}
